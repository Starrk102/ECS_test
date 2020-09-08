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


            var playerInitData = UniversalScriptableObject.CreatePlayerObj();
            var spawnedPlayerPrefab = GameObject.Instantiate(playerInitData.obj, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);

            animationCompanent.animator = spawnedPlayerPrefab.transform.Find("Player").GetComponent<Animator>();
            movableComponent.moveSpeed = UniversalScriptableObject.CreatePlayerObj().objSpeed;
            movableComponent.transform = spawnedPlayerPrefab.transform;

            CreateWaypoint(new Vector2(-40, 20));
            CreateWaypoint(new Vector2(-20, 20));
            CreateWaypoint(new Vector2(-20, 0));
            CreateWaypoint(new Vector2(0, 0));
            CreateWaypoint(new Vector2(20, -20));

            for (int i = 0; i < 3; i++)
            {
                CreateEnemy(new Vector2(-40.0f,5.0f * i), spawnedPlayerPrefab.transform);
            }
        }

        void CreateEnemy(Vector3 atPosition, Transform target)
        {
            var enemy = world.NewEntity();
            var enemyMovableComponent = enemy.Set<Movable>();
            var enemyAnimationComponent = enemy.Set<AnimationCharacter>();
            var followComponent = enemy.Set<Follow>();
            

            var enemyInitData = UniversalScriptableObject.CreateEnemyObj();
            var spawnedEnemyPrefab = GameObject.Instantiate(enemyInitData.obj, atPosition, Quaternion.identity);

            enemyAnimationComponent.animator = spawnedEnemyPrefab.transform.Find("Player").GetComponent<Animator>();
            enemyMovableComponent.moveSpeed = UniversalScriptableObject.CreateEnemyObj().objSpeed;
            enemyMovableComponent.transform = target;

            followComponent.target = target;
        }

        void CreateWaypoint(Vector3 position)
        {
            var wayPointInitDate = UniversalScriptableObject.CreateWayPoint();
            GameObject.Instantiate(wayPointInitDate.WayPoint, position, Quaternion.identity);
        }
    }
}
