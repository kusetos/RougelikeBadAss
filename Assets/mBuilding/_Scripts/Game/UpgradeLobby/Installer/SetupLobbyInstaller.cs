using UnityEngine;
using Zenject;

public class SetupLobbyInstaller : MonoInstaller
{
    [SerializeField] private StatContainer _healthContainer;
    [SerializeField] private StatContainer _armorContainer;
    [SerializeField] private StatContainer _speedContainer;
    [SerializeField] private StatContainer _energyContainer;
    public override void InstallBindings()
    {
        Container.Bind<StatContainer>().WithId("Health").FromInstance(_healthContainer).AsCached();
        Container.Bind<StatContainer>().WithId("Armor").FromInstance(_armorContainer).AsCached();
        Container.Bind<StatContainer>().WithId("Speed").FromInstance(_speedContainer).AsCached();
        Container.Bind<StatContainer>().WithId("Energy").FromInstance(_energyContainer).AsCached();

        Container.BindInterfacesAndSelfTo<CharacterStatSystem>().AsSingle();

        ///Make coins SYSTEM!!!!!!!!!!!!!!!!
        Container.Bind<StatCoin>().AsSingle().WithArguments(10);

        Container.Bind<DashManager>().FromComponentInHierarchy().AsSingle();

    }
}