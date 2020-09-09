// ----------------------------------------------------------------------------
// The MIT License
// Ui extension https://github.com/Leopotam/ecs-ui
// for ECS framework https://github.com/Leopotam/ecs
// Copyright (c) 2017-2020 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using UnityEngine;

namespace Leopotam.Ecs.Ui.Components {
    public sealed class EcsUiExitEvent : IEcsAutoReset {
        public string WidgetName;
        public GameObject Sender;

        void IEcsAutoReset.Reset () {
            Sender = null;
        }
    }
}