using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DC.Scanner;

namespace DC.Test
{

    public class TestPlayer : MonoBehaviour
    {
        public TargetScanner scanner;

        Transform nearestTarget;
        Transform firstDetectedTarget;
        List<Transform> targetList;

        // Update is called once per frame
        void FixedUpdate()
        {
            nearestTarget = scanner.GetNearestTarget();
            firstDetectedTarget = scanner.GetTarget();
            targetList = scanner.GetTargetList();

        }

        private void OnDrawGizmos()
        {
            scanner.ShowGizmos();
        }


















    }

}
