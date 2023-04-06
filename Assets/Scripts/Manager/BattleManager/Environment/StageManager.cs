using System.Collections.Generic;
using Common.Data;
using Photon.Pun;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Manager.BattleManager.Environment
{
    public class StageManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> breakingBlocks;
        [SerializeField] private Transform parentTransform;
        [SerializeField] private List<Vector3> prohibitPos;
        private const int GenerateMaxCount = 100;
        private const int Width = 8;
        private const int Height = 5;
        private const string TreeObjName = "Tree";

        public void SetupBreakingBlocks()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                return;
            }

            int count = 0;
            while (count <= GenerateMaxCount)
            {
                float xPos = Random.Range(-Width, Width + 1);
                float zPos = Random.Range(-Height, Height + 1);
                if (zPos % 2 == 0 && xPos % 2 != 0)
                {
                    continue;
                }

                Vector3 createPos = new Vector3(xPos, 0, zPos);
                bool isFind = false;
                foreach (var pos in prohibitPos)
                {
                    if (createPos == pos)
                    {
                        isFind = true;
                        break;
                    }
                }

                if (isFind)
                {
                    continue;
                }

                prohibitPos.Add(createPos);

                var breakingWallObj = PhotonNetwork.InstantiateRoomObject(
                    GameCommonData.StagePrefabPath + TreeObjName,
                    createPos, breakingBlocks[0].transform.rotation);
                breakingWallObj.transform.SetParent(parentTransform);
                breakingWallObj.AddComponent<BreakingWall>();
                breakingWallObj.tag = GameCommonData.BreakingWallTag;
                count++;


                /*var breakingWallObj = Instantiate(breakingBlocks[0], createPos, breakingBlocks[0].transform.rotation,
                    parentTransform);*/
            }
        }
    }
}