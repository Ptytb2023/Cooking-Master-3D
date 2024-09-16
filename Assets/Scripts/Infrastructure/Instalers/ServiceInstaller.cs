using Assets.Scripts.Infrastructure.Factorys;
using Configs;
using Data;
using Infrastructure.Services.Assets;
using Infrastructure.Services.Coroutines;
using Infrastructure.Services.Input;
using Infrastructure.Services.Scenes;
using UnityEngine;
using Zenject;

namespace Infrastructure.Instalers
{
    public class ServiceInstaller : MonoInstaller
    {
        [SerializeField] private GameConfig _gameConfig;
        [SerializeField] private CoroutineRuner _coroutineRuner;
        [SerializeField] private PrefabConfig _itemConfig;

        public override void InstallBindings()
        {
            GameData gameData = new GameData();

            gameData.TimeServeCustomerCashRegister = _gameConfig.TimeServeCashRegister;
            gameData.MaxCustomer = _gameConfig.MaxCustomers;
            gameData.TimeServePickupCounter = _gameConfig.TimeServePickupCounter;
            gameData.TimeCookForGrill= _gameConfig.TimeCookForGrill;
            gameData.PlayerMoveSpeed = _gameConfig.SpeedMovePlayer;
            gameData.TimeBeetwenSpawn = _gameConfig.TimeBeetwenSpawn;

            Container.Bind<GameData>().To<GameData>().FromInstance(gameData).AsSingle().NonLazy();

            BindSceneLoaderService();
            BindCoroutineService();
            BindInputService();
            AssetProviderBind();
        }



        private void BindSceneLoaderService()
        {
            Container.BindInterfacesAndSelfTo<SceneLoaderService>().AsSingle().NonLazy();
        }

        private void BindCoroutineService()
        {
            ICoroutineService coroutineService = new CoroutineService(_coroutineRuner);
            Container.Bind<ICoroutineService>().FromInstance(coroutineService).AsSingle().NonLazy();
        }

        private void BindInputService()
        {
            if (Application.isEditor)
                Container.BindInterfacesAndSelfTo<MobileInputService>().AsSingle().NonLazy();
            else
                Container.BindInterfacesAndSelfTo<StandaloneInputService>().AsSingle().NonLazy();
        }

        private void AssetProviderBind()
        {
            IAssetProvider assetProvider = new AssetsProvider(_itemConfig);

            Container.BindInterfacesAndSelfTo<AssetsProvider>().FromInstance(assetProvider).AsSingle().NonLazy();
        }
    }
}