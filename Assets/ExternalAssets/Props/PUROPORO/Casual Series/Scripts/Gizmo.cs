using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PUROPORO
{
    public class Gizmo : MonoBehaviour
    {
        [SerializeField] private Color m_GizmosColor;

        void OnDrawGizmos()
        {
            Gizmos.color = m_GizmosColor;
            Gizmos.DrawWireSphere(transform.position, .25f);
        }
    }
}
