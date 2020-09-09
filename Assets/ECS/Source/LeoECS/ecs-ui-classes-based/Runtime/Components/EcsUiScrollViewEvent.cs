// ----------------------------------------------------------------------------
// The MIT License
// Ui extension https://github.com/Leopotam/ecs-ui
// for ECS framework https://github.com/Leopotam/ecs
// Copyright (c) 2017-2020 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;

namespace Leopotam.Ecs.Ui.Components {
    public sealed class EcsUiScrollViewEvent : IEcsAutoReset {
        public string WidgetName;
        public ScrollRect Sender;
        public Vector2 Value;

        void IEcsAutoReset.Reset () {
            Sender = null;
        }
    }
}