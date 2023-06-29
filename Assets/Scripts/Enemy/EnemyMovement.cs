using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;
using Zenject;
using Random = UnityEngine.Random;

namespace Code.Scripts.Enemy
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyMovement : MonoBehaviour
    {
        [Inject] private PlayerIndex playerObj;
        [SerializeField] private float speedMovement;
        [SerializeField] private float speedRotation;
        private NavMeshAgent _agent;
        private Rigidbody _rigidbody;
        private bool _isRotateRight = true;

        private Tween _timerRotation;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _agent = GetComponent<NavMeshAgent>();

            _agent.speed = speedMovement;
            _agent.updateRotation = false;
            RotationTimer();
        }

        private void FixedUpdate()
        {
            _agent.SetDestination(playerObj.transform.position);
        }

        private void Rotate()
        {
            if (_isRotateRight) _rigidbody.angularVelocity = Vector3.up * 100 * speedRotation * Time.deltaTime;
            else _rigidbody.angularVelocity = -Vector3.up * 100 * speedRotation * Time.deltaTime;
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