using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "Character/Actions/Dash")]
public class Dash : PlayerAction
{
    [SerializeField]
    private float m_force;

    protected override void OnActionStart()
    {
        Vector3 direction = m_values.RawInputDirection;
        m_state.body.AddForce(direction * m_force);
        m_signalBus.Fire(new OnFocusDirectionSignal(direction));
    }

    public override void OnActionComplete()
    {
        m_signalBus.Fire<OnReleaseFocusDirectionSignal>();
    }


}
