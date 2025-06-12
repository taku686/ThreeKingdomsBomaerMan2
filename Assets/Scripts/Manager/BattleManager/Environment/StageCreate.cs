using Common.Data;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Manager.BattleManager.Environment
{
    public class StageCreate : MonoBehaviour
    {
        [SerializeField] private GameObject[] _stages;

        public StartPointsRepository StageGenerate()
        {
            var stageIndex = Random.Range(0, _stages.Length);
            var candidateStage = _stages[stageIndex];
            for (var i = 0; i < _stages.Length; i++)
            {
                if (i != stageIndex)
                {
                    _stages[i].SetActive(false);
                    continue;
                }

                candidateStage = _stages[stageIndex];
                candidateStage.SetActive(true);
                Setup(candidateStage);
            }

            var startPointsRepository = candidateStage.GetComponentInChildren<StartPointsRepository>();
            return startPointsRepository;
        }

        private static void Setup(GameObject stage)
        {
            var children = stage.GetComponentsInChildren<Transform>(true);
            var breakingWall = new GameObject("BreakingWall");
            var floor = new GameObject("Floor");
            var props = new GameObject("Props");
            var walls = new GameObject("Walls");
            var rocks = new GameObject("Rocks");
            var grass = new GameObject("Grass");
            var bush = new GameObject("Bush");
            var water = new GameObject("Water");
            breakingWall.transform.SetParent(stage.transform);
            floor.transform.SetParent(stage.transform);
            props.transform.SetParent(stage.transform);
            walls.transform.SetParent(stage.transform);
            rocks.transform.SetParent(stage.transform);
            grass.transform.SetParent(stage.transform);
            bush.transform.SetParent(stage.transform);
            water.transform.SetParent(stage.transform);

            foreach (var child in children)
            {
                if (child == stage.transform) continue;

                if (child.name.Contains("Grass"))
                {
                    child.tag = GameCommonData.BushTag;
                }

                if (child.name.Contains("Crystal"))
                {
                    child.tag = GameCommonData.BreakingWallTag;
                }

                if (child.CompareTag("BreakingWall"))
                {
                    SetupObstacles(child.gameObject);
                    child.gameObject.tag = GameCommonData.BreakingWallTag;
                    child.SetParent(breakingWall.transform);
                }
                else if (child.CompareTag("Floor"))
                {
                    child.SetParent(floor.transform);
                }
                else if (child.CompareTag("Props"))
                {
                    child.SetParent(props.transform);
                }
                else if (child.CompareTag("Wall"))
                {
                    SetupObstacles(child.gameObject);
                    child.SetParent(walls.transform);
                }
                else if (child.CompareTag("Rock"))
                {
                    child.SetParent(rocks.transform);
                }
                else if (child.CompareTag("Grass"))
                {
                    child.SetParent(grass.transform);
                }
                else if (child.CompareTag("Bush"))
                {
                    child.gameObject.tag = GameCommonData.BushTag;
                    child.SetParent(bush.transform);
                }
                else if (child.CompareTag("Water"))
                {
                    child.SetParent(water.transform);
                }
            }
        }

        private static void SetupObstacles(GameObject obstacle)
        {
            var collider = obstacle.GetComponent<Collider>();
            if (collider != null)
            {
                collider.isTrigger = false;
            }
            else
            {
                obstacle.AddComponent<BoxCollider>().isTrigger = false;
            }

            obstacle.layer = LayerMask.NameToLayer(GameCommonData.ObstacleLayer);
            var rigidBody = obstacle.AddComponent<Rigidbody>();
            rigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
            rigidBody.isKinematic = false;
            rigidBody.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}