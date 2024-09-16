using Assets.Scripts.Infrastructure.Factorys;
using Configs;
using Infrastructure.Pools;
using Interactions;
using UI;
using UnityEngine;
using Zenject;

namespace Infrastructure.Instalers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private ProgressLine _progressLine;

        [SerializeField] private GameConfig _gameConfig;


        public override void InstallBindings()
        {
            BindFactory();

            Container.BindInterfacesTo<ProgressLine>().FromInstance(_progressLine).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<InteractionLoader>().AsTransient().NonLazy();

            Container.BindInterfacesAndSelfTo<ItemPool>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CustomerPool>().AsSingle().NonLazy();
        }

        private void BindFactory()
        {
            Container.BindInterfacesAndSelfTo<FactoryObject>().AsSingle().NonLazy();
        }
    }
}