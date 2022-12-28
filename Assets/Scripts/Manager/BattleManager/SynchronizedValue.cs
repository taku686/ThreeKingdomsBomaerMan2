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
        private static readonly Dictionary<string, ReactiveProperty<int>> IntSynchronizedValueDictionary =
            new Dictionary<string, ReactiveProperty<int>>();


        public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, Hashtable changedProps)
        {
            foreach (var prop in changedProps)
            {
                if (IntSynchronizedValueDictionary.Count <= 0)
                {
                    return;
                }

                foreach (var keyValuePair in IntSynchronizedValueDictionary)
                {
                    if (keyValuePair.Key.Equals(prop.Key))
                    {
                        keyValuePair.Value.Value = (int)prop.Value;
                    }
                }
            }
        }

        public static void Create(string key, int value)
        {
            if (IntSynchronizedValueDictionary.ContainsKey(key))
            {
                Debug.LogError("すでに生成されています。");
                return;
            }

            IntSynchronizedValueDictionary[key] = new ReactiveProperty<int>(value);
        }

        public static ReadOnlyReactiveProperty<int> GetValue(string key)
        {
            if (!IntSynchronizedValueDictionary.ContainsKey(key))
            {
                Debug.LogError(key + "の値がありません");
                return null;
            }

            return IntSynchronizedValueDictionary[key].ToSequentialReadOnlyReactiveProperty();
        }

        public static void SetValue(string key, int value)
        {
            if (!IntSynchronizedValueDictionary.ContainsKey(key))
            {
                Debug.LogError(key + "の値がありません");
                return;
            }

            IntSynchronizedValueDictionary[key].Value = value;
            PhotonNetwork.LocalPlayer.SetPlayerValue(key, value);
        }
    }
}