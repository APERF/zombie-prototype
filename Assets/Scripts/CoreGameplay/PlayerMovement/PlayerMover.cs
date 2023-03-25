using UnityEngine;

namespace CoreGameplay.PlayerMovement
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private MovementAnimationHandler _animationHandler;
        private Rigidbody playerRb;
        [SerializeField] private float _speed = 5f;

        public Vector2 Direction;

        public Rigidbody PlayerRb { get => playerRb; }
        public float Speed { get => _speed; }

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