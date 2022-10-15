using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StageCreater : MonoBehaviour
{
    [SerializeField] GameObject _outWall;
    [SerializeField] GameObject _breakingWall;
    [SerializeField] float _stageWidth;
    [SerializeField] float _stageHeight;
    [SerializeField] GameObject _stage;


    private float _modifiedNum = 2.5f;

    private Vector3 _gridUnitSize = Vector3.one;

    private void Start()
    {
        StageGenerate();
    }

    private void StageGenerate()
    {
        OutWallGenerate(Vector3.left, _stageWidth, Mathf.PI * (1f / 4f));
        OutWallGenerate(Vector3.back, _stageHeight, Mathf.PI * (3f / 4f));
        OutWallGenerate(Vector3.right, _stageWidth, Mathf.PI * (5f / 4f));
        OutWallGenerate(Vector3.forward, _stageHeight, Mathf.PI * (7f / 4f));
        WallCreater();
    }

    private void OutWallGenerate(Vector3 direction, float wallLength, float angle)
    {
        Vector3 startPosition = new Vector3(Mathf.Sqrt(2) * Mathf.Cos(angle) * ((_stageWidth - 1f) / 2), 0.5f,
            (Mathf.Sqrt(2) * Mathf.Sin(angle)) * ((_stageHeight - 1f) / 2));

        for (int i = 1; i < (int)wallLength; i++)
        {
            Instantiate(_outWall, startPosition, _outWall.transform.rotation, _stage.transform);
            startPosition += direction;
        }
    }


    private void WallCreater()
    {
        Vector3 initPos = new Vector3(-((_stageWidth / 2) - _modifiedNum), _gridUnitSize.y / 2,
            (_stageHeight / 2) - _modifiedNum);
        List<Vector3> createPoses = new List<Vector3>();
        for (int i = 0; i < _stageHeight - 4; i++)
        {
            for (int j = 0; j < _stageWidth - 4; j++)
            {
                createPoses.Add(
                    new Vector3(initPos.x + _gridUnitSize.x * j, initPos.y, initPos.z - _gridUnitSize.z * i));
            }
        }

        foreach (var createPos in createPoses.Where(p => (p.x + p.z) % 2 != 0 && p.x % 2 != 0))
        {
            Instantiate(_breakingWall, createPos, _breakingWall.transform.rotation, _stage.transform);
        }
    }
}