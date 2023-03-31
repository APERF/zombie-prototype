using UnityEngine;

namespace CoreGameplay.PlayerMovement
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private MovementAnimationHandler _animationHandler;
        private Rigidbody playerRb;
        [SerializeField] private float _speed = 5f;

        [SerializeField] private Transform _mainCamera;
        [SerializeField] private Transform _target;

        public Vector2 Direction;

        public Rigidbody PlayerRb { get => playerRb; }
        public float Speed { get => _speed; }
        public Transform MainCamera { get => _mainCamera; }
        public Transform Target { get => _target; }

        #region UnityEvents
        private void Start()
        {
            PlayerMovementSystem.s_Instance.Components.Add(this);
            playerRb = GetComponent<Rigidbody>();
            Direction = Vector2.zero;
        }

        private void Update()
        {
            _animationHandler.SetAnimation(Direction);
        }
        #endregion
    }
}