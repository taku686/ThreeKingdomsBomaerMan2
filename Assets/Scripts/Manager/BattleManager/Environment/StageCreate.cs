using System.Collections.Generic;
using System.Linq;
using Common.Data;
using UnityEngine;

namespace Manager.BattleManager.Environment
{
    public class StageCreate : MonoBehaviour
    {
        [SerializeField] GameObject outWall;
        [SerializeField] GameObject breakingWall;
        [SerializeField] float stageWidth;
        [SerializeField] float stageHeight;
        [SerializeField] GameObject stage;
        private const float ModifiedNum = 2.5f;
        private readonly Vector3 _gridUnitSize = Vector3.one;

        private void Start()
        {
            StageGenerate();
        }

        private void StageGenerate()
        {
            OutWallGenerate(Vector3.left, stageWidth, Mathf.PI * (1f / 4f));
            OutWallGenerate(Vector3.back, stageHeight, Mathf.PI * (3f / 4f));
            OutWallGenerate(Vector3.right, stageWidth, Mathf.PI * (5f / 4f));
            OutWallGenerate(Vector3.forward, stageHeight, Mathf.PI * (7f / 4f));
            BreakingWallCreate();
        }

        private void OutWallGenerate(Vector3 direction, float wallLength, float angle)
        {
            Vector3 startPosition = new Vector3(Mathf.Sqrt(2) * Mathf.Cos(angle) * ((stageWidth - 1f) / 2), 0.5f,
                (Mathf.Sqrt(2) * Mathf.Sin(angle)) * ((stageHeight - 1f) / 2));

            for (int i = 1; i < (int)wallLength; i++)
            {
                Instantiate(outWall, startPosition, outWall.transform.rotation, stage.transform);
                startPosition += direction;
            }
        }


        private void BreakingWallCreate()
        {
            Vector3 initPos = new Vector3(-((stageWidth / 2) - ModifiedNum), _gridUnitSize.y / 2,
                (stageHeight / 2) - ModifiedNum);
            List<Vector3> createPoses = new List<Vector3>();
            for (int i = 0; i < stageHeight - 4; i++)
            {
                for (int j = 0; j < stageWidth - 4; j++)
                {
                    createPoses.Add(
                        new Vector3(initPos.x + _gridUnitSize.x * j, initPos.y, initPos.z - _gridUnitSize.z * i));
                }
            }

            foreach (var createPos in createPoses.Where(p => (p.x + p.z) % 2 != 0 && p.x % 2 != 0))
            {
                var obj = Instantiate(breakingWall, createPos, breakingWall.transform.rotation, stage.transform);
                obj.AddComponent<BreakingWall>();
                obj.tag = GameCommonData.BreakingWallTag;
            }
        }
    }
}