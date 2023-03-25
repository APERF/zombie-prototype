using UnityEngine;

namespace CoreGameplay.EnemyMovement
{
    public class LinearMoverComponent : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        [SerializeField] private float _speed = 2f;

        public Transform Target { get => _target; }
        public float Speed { get => _speed; }

        private void Start()
        {
            LinearMoverSystem.s_Instance.Components.Add(this);
        }
    }
}