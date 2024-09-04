using System;
using System.Collections.Generic;
using Mono.Collections.Generic;
using UnityEngine;

namespace Repository
{
    public class MotionRepository : MonoBehaviour
    {
        [SerializeField] private Motion[] spearIdleMotions;
        [SerializeField] private Motion[] hammerIdleMotions;
        [SerializeField] private Motion[] swordIdleMotions;
        [SerializeField] private Motion[] knifeIdleMotions;
        [SerializeField] private Motion[] fanIdleMotions;
        [SerializeField] private Motion[] bowIdleMotions;
        [SerializeField] private Motion[] shieldIdleMotions;
        [SerializeField] private Motion[] axeIdleMotions;
        [SerializeField] private Motion[] staffIdleMotions;

        [SerializeField, Space(45)] private Motion[] spearPerformanceMotions;
        [SerializeField] private Motion[] hammerPerformanceMotions;
        [SerializeField] private Motion[] swordPerformanceMotions;
        [SerializeField] private Motion[] knifePerformanceMotions;
        [SerializeField] private Motion[] fanPerformanceMotions;
        [SerializeField] private Motion[] bowPerformanceMotions;
        [SerializeField] private Motion[] shieldPerformanceMotions;
        [SerializeField] private Motion[] axePerformanceMotions;
        [SerializeField] private Motion[] staffPerformanceMotions;

        public Motion[][] GetAllIdleMotions()
        {
            return new[]
            {
                spearIdleMotions,
                hammerIdleMotions,
                swordIdleMotions,
                knifeIdleMotions,
                fanIdleMotions,
                bowIdleMotions,
                shieldIdleMotions,
                axeIdleMotions,
                staffIdleMotions
            };
        }

        public Motion[][] GetAllPerformanceMotions()
        {
            return new[]
            {
                spearPerformanceMotions,
                hammerPerformanceMotions,
                swordPerformanceMotions,
                knifePerformanceMotions,
                fanPerformanceMotions,
                bowPerformanceMotions,
                shieldPerformanceMotions,
                axePerformanceMotions,
                staffPerformanceMotions
            };
        }
    }
}