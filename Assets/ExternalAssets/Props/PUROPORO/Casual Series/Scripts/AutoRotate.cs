using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PUROPORO
{
    /// <summary>
    /// Automatically rotates object.
    /// </summary>
    public class AutoRotate : MonoBehaviour
    {
        public Vector3 m_Speed = new Vector3(0, 48, 0);

        private void LateUpdate()
        {
            transform.Rotate(
                 m_Speed.x * Time.deltaTime,
                 m_Speed.y * Time.deltaTime,
                 m_Speed.z * Time.deltaTime
            );
        }
    }
}