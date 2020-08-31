using UnityEngine;
using Leopotam.Ecs;

namespace ECSGuide.ECS
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        EcsFilter<InputEvent> inputEventsFilter = null;

        public void Run()
        {
            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");

            if (x != 0 || y != 0)
            {
                foreach(var i in inputEventsFilter)
                {
                    var inputEvent = inputEventsFilter.Get1[i];

                    inputEvent.direction = new Vector2(x, y);
                }
            }
        }
    }
}
