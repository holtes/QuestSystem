using _Project.Develop.Runtime.Data.Configs;
using _Project.Develop.Runtime.Startup.Data;
using _Project.Develop.Runtime.Startup.Installers;
using Leopotam.Ecs;
using UnityEngine;

namespace _Project.Develop.Runtime.Startup
{
    public sealed class Startup : MonoBehaviour {
        [SerializeField] private GameConfig _gameConfig;
        [SerializeField] private SceneData _sceneData;

        private EcsWorld _world;
        private EcsSystems _systems;
        private SystemsInstaller _systemsInstaller;
        private ServicesInstaller _servicesInstaller;
        private DataInstaller _dataInstaller;

        void Start () {
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
            _servicesInstaller = new ServicesInstaller();
            _servicesInstaller.Init();

            _dataInstaller = new DataInstaller();
            _dataInstaller.Init(_gameConfig, _sceneData);

            _systemsInstaller = new SystemsInstaller();
            _systemsInstaller.Init(_systems, _sceneData, _servicesInstaller, _dataInstaller);

            _systems.Init();
        }

        void Update () {
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}