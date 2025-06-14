using Photon.Pun;
using UnityEngine;

namespace Player.Common
{
    public class PlayerDash : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        public void Initialize()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Dash(float dashForce)
        {
            if (!PhotonNetwork.LocalPlayer.IsLocal)
            {
                return;
            }

            var dashDirection = transform.forward;
            _rigidbody.AddForce(dashDirection * dashForce, ForceMode.Impulse);
        }
    }
}