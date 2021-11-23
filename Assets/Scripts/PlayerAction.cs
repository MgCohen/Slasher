using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Zenject;

public abstract class PlayerAction: ScriptableObject
{
    [Inject]
    protected SignalBus m_signalBus;
    [Inject]
    protected Character m_character;
    [Inject]
    protected CharacterState m_state;
    [Inject]
    protected InputValues m_values;

    [SerializeField]
    private PlayerAnimation m_animation;

    [SerializeField]
    private float m_cd;
    private float m_lastUse;
    public bool OnCooldown => Time.time - m_lastUse < m_cd;

    public int Priority
    {
        get => m_priority;
    }
    [SerializeField]
    private int m_priority;

    [SerializeField]
    protected List<InputRequirement> m_inputString;
    public List<InputRequirement> Sequence
    {
        get
        {
            return m_inputString.Reverse<InputRequirement>().ToList();
        }
    }
    public int SequenceLength => m_inputString.Count;

    public bool TryStartAction()
    {
        Debug.Log(1);
        if (m_state.CanPerform(this))
        {
            Debug.Log(2);
            m_state.Perform(this);
            return true;
        }
        return false;
    }

    public void StartAction()
    {
        Debug.Log(2);
        m_state.PlayState(m_animation.GetClip());
        OnActionStart();
    }

    protected abstract void OnActionStart();

    public abstract void OnActionComplete();
}
