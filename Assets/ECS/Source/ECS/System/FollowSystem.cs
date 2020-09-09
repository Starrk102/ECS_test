using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using UnityEngine;

namespace ECSGuide.ECS
{
    public class FollowSystem : IEcsRunSystem
    {
        EcsFilter<Follow, Movable, TargetPosition> enemyFollowFilter = null;

        public void Run()
        {
            foreach(var i in enemyFollowFilter)
            {
                var followComponent = enemyFollowFilter.Get1[i];
                var movableComponent = enemyFollowFilter.Get2[i];
                var targetPosition = enemyFollowFilter.Get3[i];
                //var direction = movableComponent.transform.position.normalized;
                //movableComponent.transform.position = Vector2.MoveTowards(direction, targetPosition.Target1.position, movableComponent.moveSpeed * Time.deltaTime);
                
                if(targetPosition.Target1)
                {
                    var direction = (targetPosition.Target1.position - movableComponent.transform.position).normalized;
                    movableComponent.transform.position += direction * (Time.deltaTime * movableComponent.moveSpeed);
                    movableComponent.isMoving = direction.sqrMagnitude > 0;
                }
            }
        }
    }
}
