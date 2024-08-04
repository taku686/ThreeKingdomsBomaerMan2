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
        private readonly Dictionary<string, ReactiveProperty<int>> intSynchronizedValueDictionary = new();

        private readonly Dictionary<string, ReactiveProperty<float>> floatSynchronizedValueDictionary = new();

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
                if (intSynchronizedValueDictionary.Count <= 0 && floatSynchronizedValueDictionary.Count <= 0)
                {
                    return;
                }

                foreach (var keyValuePair in intSynchronizedValueDictionary)
                {
                    if (keyValuePair.Key.Equals(prop.Key))
                    {
                        keyValuePair.Value.Value = (int)prop.Value;
                    }
                }

                foreach (var keyValuePair in floatSynchronizedValueDictionary)
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
            if (intSynchronizedValueDictionary.ContainsKey(key))
            {
                Debug.LogError("すでに生成されています。");
                return;
            }

            intSynchronizedValueDictionary[key] = new ReactiveProperty<int>(value);
        }

        public ReadOnlyReactiveProperty<int> GetIntValue(string key)
        {
            if (!intSynchronizedValueDictionary.ContainsKey(key))
            {
                Debug.LogError(key + "の値がありません");
                return null;
            }

            return intSynchronizedValueDictionary[key].ToSequentialReadOnlyReactiveProperty();
        }

        public void SetValue(string key, int value)
        {
            if (!intSynchronizedValueDictionary.ContainsKey(key))
            {
                Debug.LogError(key + "の値がありません");
                return;
            }

            intSynchronizedValueDictionary[key].Value = value;
            PhotonNetwork.LocalPlayer.SetPlayerValue(key, value);
        }

        public void Create(string key, float value)
        {
            if (floatSynchronizedValueDictionary.ContainsKey(key))
            {
                Debug.LogError("すでに生成されています。");
                return;
            }

            floatSynchronizedValueDictionary[key] = new ReactiveProperty<float>(value);
        }

        public ReadOnlyReactiveProperty<float> GetFloatValue(string key)
        {
            if (!floatSynchronizedValueDictionary.ContainsKey(key))
            {
                Debug.LogError(key + "の値がありません");
                return null;
            }

            return floatSynchronizedValueDictionary[key].ToSequentialReadOnlyReactiveProperty();
        }

        public void SetValue(string key, float value)
        {
            if (!floatSynchronizedValueDictionary.ContainsKey(key))
            {
                Debug.LogError(key + "の値がありません");
                return;
            }

            floatSynchronizedValueDictionary[key].Value = value;
            PhotonNetwork.LocalPlayer.SetPlayerValue(key, value);
        }

        public void Destroy()
        {
            intSynchronizedValueDictionary.Clear();
            floatSynchronizedValueDictionary.Clear();
        }
    }
}