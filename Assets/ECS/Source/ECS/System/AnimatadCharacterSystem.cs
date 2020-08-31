using ECSGuide.ECS;
using Leopotam.Ecs;
using UnityEngine;

public class AnimatadCharacterSystem : IEcsRunSystem
{
    EcsFilter<AnimationCharacter, Movable> animatedFilter = null;

    public void Run()
    {
        foreach (var i in animatedFilter)
        {
            var animatedCharacter = animatedFilter.Get1[i];
            var movableComponent = animatedFilter.Get2[i];

            animatedCharacter.animator.SetBool("isMoving", movableComponent.isMoving);
        }
    }
}
