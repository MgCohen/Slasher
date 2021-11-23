using UnityEngine;
using Zenject;
using System.Collections.Generic;
public class CharacterInstaller : MonoInstaller
{
    [SerializeField]
    private Character m_character;
    [SerializeField]
    private CharacterState m_state;

    public override void InstallBindings()
    {
        Container.DeclareSignal<OnFocusTargetSignal>().OptionalSubscriber();
        Container.DeclareSignal<OnFocusDirectionSignal>().OptionalSubscriber();
        Container.DeclareSignal<OnReleaseFocusDirectionSignal>().OptionalSubscriber();

        Container.Bind<Character>().FromInstance(m_character).AsSingle();
        Container.Bind<CharacterState>().FromInstance(m_state).AsSingle();

        Container.Bind<PlayerInput>().To(x => x.AllNonAbstractClasses()).AsSingle();

        foreach (var action in m_character.actions)
        {
            Container.QueueForInject(action);
        }
    }
}