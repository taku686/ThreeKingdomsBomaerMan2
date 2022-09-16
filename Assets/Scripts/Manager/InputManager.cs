using UniRx;
using UnityEngine;

namespace Manager
{
    public class InputManager : MonoBehaviour
    {
        private readonly ReactiveProperty<Vector3>
            _moveDirection = new ReactiveProperty<Vector3>(Vector3.zero);

        public ReactiveProperty<Vector3> MoveDirection => _moveDirection;

        private void Update()
        {
            _moveDirection.SetValueAndForceNotify(
                new Vector3Int((int)Input.GetAxisRaw("Horizontal"), 0, (int)Input.GetAxisRaw("Vertical")));
        }
    }
}