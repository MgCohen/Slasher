using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : State
{

    public Transform target;
    public Rigidbody body;

    private bool m_locked = false;
    private int m_lockPriority = -1;

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
    }


    public void CompleteAction(PlayerAction action)
    {
        if(m_currentAction != action)
        {
            return;
        }

        m_lockPriority = -1;
        m_locked = false;
        m_currentAction.OnActionComplete();
        m_currentAction = null;
    }

}
