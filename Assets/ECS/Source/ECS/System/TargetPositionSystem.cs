using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace ECSGuide.ECS
{
    public class TargetPositionSystem : IEcsRunSystem
    {
        EcsFilter<TargetPosition> targetPositionFilter = null;

        public void Run()
        {
            foreach (var i in targetPositionFilter)
            {
                var targetPositionComponent = targetPositionFilter.Get1[i];
                for (int j = 0; j < 5; j++)
                {
                    targetPositionComponent.targetPosition[j] = GameObject.FindGameObjectWithTag("WayPoint").transform;
                }
            }
        }
    }
}
