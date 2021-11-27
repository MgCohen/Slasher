using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputBuffer
{

    [Inject]
    private SignalBus m_signalBus;

    private List<PlayerInput> m_inputs = new List<PlayerInput>();
    private int m_maxInputSequence = 5;
    private float m_comboDelay = 0.45f;
    private float m_inputBufferingTime = 0.2f;
    private float m_lastInput;

    public PlayerInput LastInput => m_inputs[0];

    [Inject]
    private void Init()
    {
        m_signalBus.Subscribe<OnChangeStateSignal>(CheckBuffer);
    }

    public void AddInput(PlayerInput input)
    {
        if (Time.time - m_lastInput > m_comboDelay)
        {
            FlushInputs();
        }

        input.UpdateValues();

        m_lastInput = Time.time;
        m_inputs.Insert(0, input);

        if (m_inputs.Count > m_maxInputSequence)
        {
            m_inputs.RemoveAt(m_inputs.Count - 1);
        }

        m_signalBus.Fire(new OnInputBufferedSignal(input));
    }

    public bool CheckCombo(List<InputRequirement> combo)
    {
        if (combo.Count > m_inputs.Count)
        {
            return false;
        }

        for (int i = 0; i < combo.Count; i++)
        {
            if (!combo[i].ValidateInput(m_inputs[i]))
            {
                return false;
            }
        }

        return true;
    }

    private void FlushInputs()
    {
        m_inputs.Clear();
        m_signalBus.Fire<OnInputsFlushedSignal>();
    }

    private void RefreshInputs()
    {
        m_lastInput = Time.time;
    }

    private void CheckBuffer()
    {
        if(Time.time - m_lastInput <= m_inputBufferingTime)
        {
            m_signalBus.Fire(new OnInputBufferedSignal(LastInput));
        }
    }
}
