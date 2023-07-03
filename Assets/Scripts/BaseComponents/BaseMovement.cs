using UnityEngine;

namespace Scripts.BaseComponents
{
    public class BaseMovement : MonoBehaviour
    {
        [SerializeField] protected float speedMovement;
        [SerializeField] protected float speedRotation;
        [SerializeField] protected Transform sword;
        protected float SpeedMode = 1;
        protected float RotationMode = 1;
        public Rigidbody Rb;

        public float SpeedModePerson
        {
            get => SpeedMode;
            set => SpeedMode = value;
        }

        public float SpeedRotationModePerson
        {
            get => RotationMode;
            set => RotationMode = value;
        }
        public float Speed
        {
            get => speedMovement;
            set => speedMovement = value;
        }

        public Rigidbody RigidBody => Rb;
        
        

        public float SpeedRotation
        {
            get => speedRotation;
            set => speedRotation = value;
        }

        public Transform Sword
        {
            get => sword;
            set => sword = value;
        }
    }
}