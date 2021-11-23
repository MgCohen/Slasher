using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/Animations/Single Animation")]
public class SingleAnimation : PlayerAnimation
{
    [SerializeField]
    private AnimationClip m_clip;

    public override AnimationClip GetClip()
    {
        return m_clip;
    }
}
