using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

namespace ECSGuide.ECS
{
    public class FollowSystem : IEcsRunSystem
    {
        EcsFilter<Follow, Movable, InputEvent> enemyFollowFilter = null;

        public void Run()
        {
            foreach(var i in enemyFollowFilter)
            {
                var followComponent = enemyFollowFilter.Get1[i];
                var movableComponent = enemyFollowFilter.Get2[i];

                if(followComponent.target)
                {
                    var direction = (followComponent.target.position - movableComponent.transform.position).normalized;
                    movableComponent.transform.position += direction * (Time.deltaTime * movableComponent.moveSpeed);
                    movableComponent.isMoving = direction.sqrMagnitude > 0;
                }
            }
        }
    }
}
