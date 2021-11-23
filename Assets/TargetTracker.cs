using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TargetTracker : MonoBehaviour
{
    [Inject]
    private SignalBus m_signalBus;
    [Inject]
    private CharacterState m_state;

    [SerializeField]
    private Transform m_model;
    [SerializeField]
    private Transform Target => m_state.target;

    [SerializeField]
    private Vector3 m_defaultDirection;
    private Vector3? m_focusDirection;

    private Vector3 m_targetDirection
    {
        get
        {
            if (m_focusDirection.HasValue)
            {
                return m_focusDirection.Value;
            }

            if (Target)
            {
                return Target.position - m_model.position;
            }

            return m_defaultDirection;
        }
    }

    private void Start()
    {
        m_signalBus.Subscribe<OnFocusDirectionSignal>(FocusDirection);
        m_signalBus.Subscribe<OnReleaseFocusDirectionSignal>(ReleaseFocus);
    }

    private void Update()
    {
        var rot = Vector3.SignedAngle(Vector3.forward, m_targetDirection, Vector3.up);
        Vector3 rotation = new Vector3(0, rot, 0);
        //m_model.transform.localRotation = Quaternion.Euler(rotation);
        m_model.LookAt(transform.position + m_targetDirection);
    }

    private void FocusDirection(OnFocusDirectionSignal signal)
    {
        m_focusDirection = signal.Direction;
    }

    private void ReleaseFocus()
    {
        m_focusDirection = null;
    }
}
