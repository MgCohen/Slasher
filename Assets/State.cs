using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class State : MonoBehaviour
{

    private const string ACTION_STRING = "Action";
    private const string STATE_STRING = "State";

    [SerializeField]
    private AnimatorOverrideController m_animController;
    [SerializeField]
    private Animator anim;

    public void PlayState(AnimationClip animation)
    {
        m_animController[ACTION_STRING] = animation;
        anim.Play(STATE_STRING);
    }
}
