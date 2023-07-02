using UnityEngine;

namespace Scripts.BaseComponents
{
    public class BaseMovement : MonoBehaviour
    {
        [SerializeField] protected float speedMovement;
        [SerializeField] protected float speedRotation;
        [SerializeField] protected Transform sword;
        public float Speed
        {
            get => speedMovement;
            set => speedMovement = value;
        }
        
        

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