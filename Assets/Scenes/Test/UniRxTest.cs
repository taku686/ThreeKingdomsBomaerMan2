using System;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

public class UniRxTest : MonoBehaviour
{
    void Start()
    {
        Observable.Range(1, 5)
            .Select(x =>
            {
                Debug.Log($"処理1 (メインスレッド): {x}");
                return x * 2;
            })
            .SubscribeOn(Scheduler.ThreadPool) // この時点からの処理はスレッドプールで実行
            .Select(y =>
            {
                Debug.Log($"処理2 (バックグラウンドスレッド): {y}");
                // 時間のかかる処理
                System.Threading.Thread.Sleep(500);
                return $"結果: {y}";
            })
            .ObserveOn(Scheduler.MainThread) // 結果はメインスレッドで処理
            .Subscribe(result => { Debug.Log($"最終結果 (メインスレッド): {result}"); });
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            var time = Random.Range(1f, 5f);
            Observable.Timer(TimeSpan.FromSeconds(time))
                .Subscribe(_ => Debug.Log($"{time}秒後に実行される別の処理"));
        }
    }
}