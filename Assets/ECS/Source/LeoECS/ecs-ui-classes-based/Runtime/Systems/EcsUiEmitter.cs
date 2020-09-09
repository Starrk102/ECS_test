// ----------------------------------------------------------------------------
// The MIT License
// Ui extension https://github.com/Leopotam/ecs-ui
// for ECS framework https://github.com/Leopotam/ecs
// Copyright (c) 2017-2020 Leopotam <leopotam@gmail.com>
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Leopotam.Ecs.Ui.Systems {
    /// <summary>
    /// Emitter system for uGui events to ECS world.
    /// </summary>
    public class EcsUiEmitter : MonoBehaviour, IEcsRunSystem {
        internal EcsWorld World = null;
        readonly Dictionary<int, GameObject> _actions = new Dictionary<int, GameObject> (64);

        /// <summary>
        /// Creates ecs entity with T component on it.
        /// </summary>
        public T CreateMessage<T> () where T : class, new () {
            ValidateEcsFields ();
            World.NewEntityWith<T> (out var msg);
            return msg;
        }

        /// <summary>
        /// Sets link to named GameObject to use it later from code. If GameObject is null - unset named link.
        /// </summary>
        /// <param name="widgetName">Logical name.</param>
        /// <param name="go">GameObject link.</param>
        public void SetNamedObject (string widgetName, GameObject go) {
            if (!string.IsNullOrEmpty (widgetName)) {
                var id = widgetName.GetHashCode ();
                if (_actions.ContainsKey (id)) {
                    if (!go) {
                        _actions.Remove (id);
                    } else {
                        throw new Exception ($"Action with \"{widgetName}\" name already registered");
                    }
                } else {
                    if ((object) go != null) {
                        _actions[id] = go.gameObject;
                    }
                }
            }
        }

        /// <summary>
        /// Gets link to named GameObject to use it later from code.
        /// </summary>
        /// <param name="widgetName">Logical name.</param>
        public GameObject GetNamedObject (string widgetName) {
            _actions.TryGetValue (widgetName.GetHashCode (), out var retVal);
            return retVal;
        }

        void IEcsRunSystem.Run () {
#if DEBUG
            Debug.LogWarning ("[EcsUiEmitter] Obsoleted behaviour - no need to add EcsEmitter to EcsSystems.");
#endif
        }

        [System.Diagnostics.Conditional ("DEBUG")]
        void ValidateEcsFields () {
#if DEBUG
            if (World == null) {
                throw new Exception ("[EcsUiEmitter] Call EcsSystems.InjectUi() first.");
            }
#endif
        }
    }
}