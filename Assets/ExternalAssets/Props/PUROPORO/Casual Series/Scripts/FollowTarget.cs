using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PUROPORO
{
    /// <summary>
    /// This can be utilized to direct one object to move in sync with another object (position, rotation and scale).
    /// </summary>
    public class FollowTarget : MonoBehaviour
    {
        [SerializeField] private Transform m_Target;
        [SerializeField] private bool m_FollowPosition;
        [SerializeField] private bool m_FollowRotation;
        [SerializeField] private bool m_FollowScale;

        void LateUpdate()
        {
            if (m_Target != null)
            {
                if (m_FollowPosition)
                    transform.position = m_Target.position;
                if (m_FollowRotation)
                    transform.localRotation = Quaternion.Euler(0, m_Target.eulerAngles.y, 0);
                if (m_FollowScale)
                    transform.localScale = m_Target.localScale;
            }
        }
    }
}
