using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CharacterState : State
{
    [Inject]
    private SignalBus m_signalBus;

    public Transform target;
    public Rigidbody body;

    private bool m_locked = false;
    public bool Locked => m_locked;
    private int m_lockPriority = -1;
    public int LockPriority => m_lockPriority;

    private PlayerAction m_currentAction;

    public bool CanPerform(PlayerAction action)
    {
        if (m_locked)
        {
            if(action.Priority <= m_lockPriority)
            {
                return false;
            }
        }

        return true;
    }

    public void Perform(PlayerAction action)
    {
        if (m_currentAction)
        {
            CompleteAction(m_currentAction);
        }

        m_locked = true;
        m_lockPriority = action.Priority;
        m_currentAction = action;
        action.StartAction();

        m_signalBus.Fire<OnChangeStateSignal>();
    }


    public void CompleteAction(PlayerAction action)
    {
        if(m_currentAction != action)
        {
            return;
        }

        CompleteCurrentAction();
    }

    public void CompleteCurrentAction()
    {
        m_lockPriority = -1;
        m_locked = false;
        m_currentAction.OnActionComplete();
        m_currentAction = null;

        m_signalBus.Fire<OnChangeStateSignal>();
    }

}
