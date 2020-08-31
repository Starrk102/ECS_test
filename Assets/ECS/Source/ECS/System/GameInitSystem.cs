using Leopotam.Ecs;
using UnityEngine;

namespace ECSGuide.ECS
{
    public class GameInitSystem : IEcsInitSystem
    {
        EcsWorld world = null; 
        public void Init()
        {
            //инициализация мира
            var player = world.NewEntity();
            player.Set<PlayerComponent>();
            var movableComponent = player.Set<Movable>();
            var animationCompanent = player.Set<AnimationCharacter>();
            player.Set<InputEvent>();

            var playerInitData = UniversalScriptableObject.CreateObj();
            var spawnedPlayerPrefab = GameObject.Instantiate(playerInitData.obj, Vector3.zero, Quaternion.identity);

            animationCompanent.animator = spawnedPlayerPrefab.transform.Find("Player").GetComponent<Animator>();
            movableComponent.moveSpeed = UniversalScriptableObject.CreateObj().objSpeed;
            movableComponent.transform = spawnedPlayerPrefab.transform;

        }
    }
}
