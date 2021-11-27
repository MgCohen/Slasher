using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputViewService
{
    private Dictionary<Vector3, Sprite> m_directionalInputs = new Dictionary<Vector3, Sprite>();
    private Sprite m_tapSprite;

    public Sprite GetInputSprite(PlayerInput input)
    {
        if (input is DirectionalInput directional)
        {
            return m_directionalInputs[directional.Direction];
        }
        else if (input is TapInput tap)
        {
            return m_tapSprite;
        }
        return null;
    }

    [Inject]
    private void init()
    {
        m_directionalInputs.Add(Vector3.forward, GetSpriteFromResource("Up"));
        m_directionalInputs.Add(Vector3.back, GetSpriteFromResource("Down"));
        m_directionalInputs.Add(Vector3.left, GetSpriteFromResource("Left"));
        m_directionalInputs.Add(Vector3.right, GetSpriteFromResource("Right"));

        m_tapSprite = GetSpriteFromResource("Tap");
    }

    private Sprite GetSpriteFromResource(string name)
    {
        return Resources.Load<Sprite>("Input/Icons/" + name);
    }
}