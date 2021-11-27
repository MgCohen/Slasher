using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputWindow : MonoBehaviour
{

    [Inject]
    private SignalBus m_signalBus;
    [Inject]
    private InputView.Factory m_viewFactory;

    [SerializeField]
    private Transform viewHolder;

    private List<InputView> m_inputView = new List<InputView>();

    private void Start()
    {
        m_signalBus.Subscribe<OnInputBufferedSignal>(AddInput);
        m_signalBus.Subscribe<OnInputsFlushedSignal>(ClearInputs);
    }


    private void ClearInputs()
    {
        foreach(InputView view in m_inputView)
        {
            Destroy(view.gameObject);
        }

        m_inputView.Clear();
    }

    private void AddInput(OnInputBufferedSignal signal)
    {
        if (signal.IsCached)
        {
            return;
        }

        InputView newView = m_viewFactory.Create(signal.Input, viewHolder);
        AddView(newView);
    }

    private void AddView(InputView view)
    {
        m_inputView.Add(view);
    }
}
