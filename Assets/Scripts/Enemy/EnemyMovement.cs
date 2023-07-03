using DG.Tweening;
using Scripts.BaseComponents;
using UnityEngine;
using UnityEngine.AI;
using Zenject;
using Random = UnityEngine.Random;

namespace Scripts.Enemy
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyMovement : BaseMovement
    {
        [Inject] private PlayerIndex playerObj;
        private NavMeshAgent _agent;
        private bool _isRotateRight = true;

        private Tween _timerRotation;

        private void Start()
        {
            Rb = GetComponent<Rigidbody>();
            _agent = GetComponent<NavMeshAgent>();

            _agent.speed = speedMovement;
            _agent.updateRotation = false;
            RotationTimer();
        }

        private void FixedUpdate()
        {
            _agent.SetDestination(playerObj.transform.position);
            
            var localEulerAngles = Sword.localEulerAngles;
            localEulerAngles =
                Vector3.up * localEulerAngles.y;
            var localPosition = Sword.localPosition;
            localPosition =
                Vector3.right * localPosition.x +
                Vector3.up * 0 +
                Vector3.forward * localPosition.z;
            Sword.localPosition = localPosition;
            localEulerAngles = Vector3.right * localEulerAngles.x + Vector3.up * localEulerAngles.y;
            Sword.localEulerAngles = localEulerAngles;
        }

        private void Rotate()
        {
            if (_isRotateRight) Rb.angularVelocity = Vector3.up * 100 * speedRotation * RotationMode * Time.deltaTime;
            else Rb.angularVelocity = -Vector3.up * 100 * speedRotation * RotationMode * Time.deltaTime;
            RotationTimer();
        }

        private void RotationTimer()
        {
            var time = 0;
            _timerRotation = DOTween.To(() => time, x => time = x, 1, Random.Range(1, 5)).OnComplete(() =>
            {
                if (Random.value > 0.5f) _isRotateRight = !_isRotateRight;
                Rotate();
            });
        }

        private void OnDisable()
        {
            _timerRotation.Kill(false);
        }
        public class Factory : PlaceholderFactory<EnemyMovement>
        {
        }
    }
}