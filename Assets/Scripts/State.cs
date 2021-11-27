using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class State : MonoBehaviour
{

    private const string ACTION_STRING = "Action ";
    private const string STATE_STRING = "State ";

    private readonly Queue<int> m_stateQueue = new Queue<int>();

    private void Awake()
    {
        m_stateQueue.Enqueue(1);
        m_stateQueue.Enqueue(2);
    }

    [SerializeField]
    private AnimatorOverrideController m_animController;
    [SerializeField]
    private Animator anim;

    public void PlayState(AnimationClip animation)
    {
        int index = m_stateQueue.Dequeue();
        m_stateQueue.Enqueue(index);
        m_animController[ACTION_STRING + index] = animation;
        anim.Play(STATE_STRING + index);
    }
}
