using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs; //Не забывать добавлять, если нужны библиотеки ECS

namespace ECSGuide.ECS
{
    public class Loader : MonoBehaviour
    {
        EcsWorld world;
        EcsSystems system;

        // Start is called before the first frame update
        void Start()
        {
            world = new EcsWorld();
            system = new EcsSystems(world);

            system.Add(new GameInitSystem());
            system.Add(new PlayerInputSystem());
            system.Add(new PlayerMoveSystem());
            //system.Add(new AnimatadCharacterSystem());
            system.Add(new FollowSystem());

            system.Init();
        }

        // Update is called once per frame
        void Update()
        {
            system.Run();
        }

        void OnDestroy()
        {
            system.Destroy();

            world.Destroy();
        }
    }
}
