using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "InputInstaller", menuName = "Installers/InputInstaller")]
public class InputInstaller : ScriptableObjectInstaller<InputInstaller>
{
    public override void InstallBindings()
    {
        Container.DeclareSignal<OnTapSignal>().OptionalSubscriber();
        Container.DeclareSignal<OnSwipeSignal>().OptionalSubscriber();
        Container.DeclareSignal<OnHoldSignal>().OptionalSubscriber();
        Container.DeclareSignal<OnReleaseSignal>().OptionalSubscriber();

        Container.DeclareSignal<OnInputSignal>().OptionalSubscriber();
        Container.DeclareSignal<OnInputsFlushedSignal>().OptionalSubscriber();

        Container.Bind<Control>().AsSingle().NonLazy();
        Container.Bind<InputBuffer>().AsSingle();
        Container.Bind<InputValues>().AsSingle();

        Container.BindFactory<Vector3, DirectionalInput, DirectionalInput.Factory>().AsSingle();
    }
}