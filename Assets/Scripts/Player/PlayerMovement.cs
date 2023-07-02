using Scripts.BaseComponents;
using UnityEngine;
using Zenject;

namespace Scripts.Player
{
    public class PlayerMovement : BaseMovement
    {
        [Inject] private VariableJoystick joystick;
        private Rigidbody _rigidbody;
        private bool _isRotateRight = true;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        void Update()
        {
            sword.localEulerAngles =
                Vector3.up * sword.localEulerAngles.y;
            sword.localPosition =
                Vector3.right * sword.localPosition.x +
                Vector3.up * 0 +
                Vector3.forward * sword.localPosition.z;
            
            if (Input.GetMouseButtonDown(0))
            {
                _isRotateRight = !_isRotateRight;
                _rigidbody.velocity = Vector3.zero;
            }

            if (Input.GetMouseButton(0))
            {
                //moving = true;
                _rigidbody.AddForce((Vector3.forward * joystick.Direction.y + Vector3.right * joystick.Direction.x) * Time.deltaTime * 100 * speedMovement);
                //rb.velocity=((Vector3.forward * joystick.Direction.y + Vector3.right * joystick.Direction.x) * Time.deltaTime * 100 * speed);
                if (_isRotateRight) _rigidbody.angularVelocity = Vector3.up * 100 * speedRotation * Time.deltaTime;
                else _rigidbody.angularVelocity = -Vector3.up * 100 * speedRotation * Time.deltaTime;
            }
        }
    }
}