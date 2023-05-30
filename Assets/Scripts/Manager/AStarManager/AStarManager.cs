using System;
using Cysharp.Threading.Tasks;
using Pathfinding;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class AStarManager : MonoBehaviour
{
    [SerializeField] private Button blockGenerateButton;
    [SerializeField] private GameObject block;
    [SerializeField] private Transform blockParent;
    private const int Width = 8;
    private const int Height = 4;

    private void Start()
    {
        DebugOnClickStageGenerate();
    }

    private void CalculateMap()
    {
        for (int i = 0; i < 5; i++)
        {
            var coordinateX = Random.Range(-Width, Width);
            var coordinateZ = Random.Range(-Height, Height);
            var coordinate = new Vector3(coordinateX, -1, coordinateZ);
            var blockClone = Instantiate(block, blockParent, true);
            blockClone.transform.localPosition = coordinate;
            var bounds = blockClone.GetComponentInChildren<Collider>().bounds;
            var guo = new GraphUpdateObject(bounds);
            AstarPath.active.AddWorkItem(ctx => { AstarPath.active.UpdateGraphs(guo); });
        }

        // guo.updatePhysics = true;
    }

    private void DebugOnClickStageGenerate()
    {
        blockGenerateButton.onClick.AsObservable().ThrottleFirst(TimeSpan.FromSeconds(1)).Subscribe(
            _ => { CalculateMap(); }
        ).AddTo(gameObject.GetCancellationTokenOnDestroy());
    }
}