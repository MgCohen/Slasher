using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using DG.Tweening;

public class InputView : MonoBehaviour
{
    [SerializeField]
    private Image m_icon;

    private void Start()
    {
        transform.DOPunchScale(Vector3.one/2, 0.2f);
    }

    public class Factory: PlaceholderFactory<PlayerInput, Transform, InputView>
    {
        [Inject]
        private DiContainer m_container;
        [Inject]
        private InputView m_viewPrefab;
        [Inject]
        private InputViewService m_viewSerivce;

        public override InputView Create(PlayerInput input, Transform holder)
        {
            InputView view =  m_container.InstantiatePrefabForComponent<InputView>(m_viewPrefab, holder);
            view.m_icon.sprite = m_viewSerivce.GetInputSprite(input);
            return view;
        }
    }
}


