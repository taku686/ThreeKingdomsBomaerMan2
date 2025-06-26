using System.Collections.Generic;
using ExitGames.Client.Photon;
using Manager.NetworkManager;
using Photon.Pun;
using UniRx;
using UnityEngine;

namespace Manager.BattleManager
{
    public class SynchronizedValue : MonoBehaviourPunCallbacks
    {
        private readonly Dictionary<string, ReactiveProperty<int>> _intSynchronizedValueDictionary = new();

        private readonly Dictionary<string, ReactiveProperty<float>> _floatSynchronizedValueDictionary = new();

        public static SynchronizedValue Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, Hashtable changedProps)
        {
            foreach (var prop in changedProps)
            {
                if (_intSynchronizedValueDictionary.Count <= 0 && _floatSynchronizedValueDictionary.Count <= 0)
                {
                    return;
                }

                foreach (var keyValuePair in _intSynchronizedValueDictionary)
                {
                    if (keyValuePair.Key.Equals(prop.Key))
                    {
                        keyValuePair.Value.Value = (int)prop.Value;
                    }
                }

                foreach (var keyValuePair in _floatSynchronizedValueDictionary)
                {
                    if (keyValuePair.Key.Equals(prop.Key))
                    {
                        keyValuePair.Value.Value = (float)prop.Value;
                    }
                }
            }
        }

        public void Create(string key, int value)
        {
            if (_intSynchronizedValueDictionary.ContainsKey(key))
            {
                Debug.LogError("すでに生成されています。");
                return;
            }

            _intSynchronizedValueDictionary[key] = new ReactiveProperty<int>(value);
        }

        public ReadOnlyReactiveProperty<int> GetIntValue(string key)
        {
            if (_intSynchronizedValueDictionary.TryGetValue(key, value: out var value)) return value.ToSequentialReadOnlyReactiveProperty();
            Debug.LogError(key + "の値がありません");
            return null;
        }

        public void SetValue(string key, int value)
        {
            if (!_intSynchronizedValueDictionary.TryGetValue(key, value: out var value1))
            {
                Debug.LogError(key + "の値がありません");
                return;
            }

            value1.Value = value;
            PhotonNetwork.LocalPlayer.SetFloatValue(key, value);
        }

        public void Create(string key, float value)
        {
            if (_floatSynchronizedValueDictionary.ContainsKey(key))
            {
                Debug.LogError("すでに生成されています。");
                return;
            }

            _floatSynchronizedValueDictionary[key] = new ReactiveProperty<float>(value);
        }

        public ReadOnlyReactiveProperty<float> GetFloatValue(string key)
        {
            if (_floatSynchronizedValueDictionary.TryGetValue(key, value: out var value)) return value.ToSequentialReadOnlyReactiveProperty();
            Debug.LogError(key + "の値がありません");
            return null;
        }

        public void SetValue(string key, float value)
        {
            if (!_floatSynchronizedValueDictionary.TryGetValue(key, out var value1))
            {
                Debug.LogError(key + "の値がありません");
                return;
            }

            value1.Value = value;
            PhotonNetwork.LocalPlayer.SetFloatValue(key, value);
        }

        private void OnDestroy()
        {
            _intSynchronizedValueDictionary.Clear();
            _floatSynchronizedValueDictionary.Clear();
        }
    }
}