using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System.Linq;

public class Character : MonoBehaviour
{
    [Inject]
    private SignalBus m_signalBus;
    [Inject]
    private InputBuffer m_buffer;
    [Inject]
    private CharacterState m_state;

    [Inject]
    private DirectionalInput.Factory directionalFactory;

    public List<PlayerAction> actions;

    private void Start()
    {
        m_signalBus.Subscribe<OnSwipeSignal>(OnSwipe);
        m_signalBus.Subscribe<OnTapSignal>(OnTap);
        Debug.Log(m_state);
    }

    private void OnSwipe(OnSwipeSignal signal)
    {
        m_buffer.AddInput(directionalFactory.Create(signal.Direction));
        CheckActions();
    }

    private void OnTap(OnTapSignal signal)
    {
        m_buffer.AddInput(new TapInput());
        CheckActions();
    }

    private void CheckActions()
    {
        List<PlayerAction> validCombos = new List<PlayerAction>();
        foreach (var action in actions)
        {
            if (action.OnCooldown)
            {
                continue;
            }

            if (m_buffer.CheckCombo(action.Sequence))
            {
                validCombos.Add(action);
            }
        }

        if (validCombos.Count > 0)
        {
            validCombos = validCombos.OrderByDescending(c => c.SequenceLength).ToList();
            foreach (var combo in validCombos)
            {
                if (combo.TryStartAction()) return;
            }

        }
    }

}
