using UnityEngine;
using Leopotam.Ecs;

namespace ECSGuide.ECS
{
    public class PlayerMoveSystem : IEcsRunSystem
    {
        EcsFilter<Movable, InputEvent> playerMoveFilter;

        public void Run()
        {
            foreach (var i in playerMoveFilter)
            {
                var movableComponent = playerMoveFilter.Get1[i];
                var inputComponent = playerMoveFilter.Get2[i];

                movableComponent.transform.position += (Vector3)inputComponent.direction * (Time.deltaTime * movableComponent.moveSpeed);

                movableComponent.isMoving = inputComponent.direction.sqrMagnitude > 0;
            }
        }
    }
}
