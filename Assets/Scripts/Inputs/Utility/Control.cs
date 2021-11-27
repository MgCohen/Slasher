using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using Zenject;

public class Control
{

    [Inject]
    private SignalBus m_signalBus;

    [Inject]
    private void SetupControls()
    {
        LeanTouch.OnFingerTap += OnTap;
        LeanTouch.OnFingerSwipe += OnSwipe;
        LeanTouch.OnFingerUpdate += OnHold;
        LeanTouch.OnFingerUp += OnRelease;
    }

    private void OnTap(LeanFinger finger)
    {
        m_signalBus.Fire(new OnTapSignal());
    }

    private void OnSwipe(LeanFinger finger)
    {
        Vector2 swipe = finger.SwipeScreenDelta;
        swipe = swipe.normalized;
        Vector3 convertedSwipe = swipe.Convert();
        m_signalBus.Fire(new OnSwipeSignal(convertedSwipe));
    }

    private void OnHold(LeanFinger finger)
    {
        if (finger.Old)
        {
            m_signalBus.Fire(new OnHoldSignal(finger.Age));
        }
    }

    private void OnRelease(LeanFinger finger)
    {
        if (finger.Old)
        {
            m_signalBus.Fire(new OnReleaseSignal(finger.Age));
        }
    }
}

public class OnTapSignal
{

}

public class OnSwipeSignal
{
    public OnSwipeSignal(Vector3 direction)
    {
        Direction = direction;
    }

    public Vector3 Direction
    {
        get; private set;
    }
}

public class OnHoldSignal
{
    public OnHoldSignal(float time)
    {
        Time = time;
    }

    public float Time
    {
        get; private set;
    }
}

public class OnReleaseSignal
{
    public OnReleaseSignal(float time)
    {
        Time = time;
    }

    public float Time
    {
        get; private set;
    }
}
