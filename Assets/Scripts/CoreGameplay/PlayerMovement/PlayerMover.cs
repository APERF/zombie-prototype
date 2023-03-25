using UnityEngine;

namespace CoreGameplay.PlayerMovement
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMover : MonoBehaviour
    {
        private Rigidbody playerRb;
        [SerializeField] private float speed = 5f;

        public Vector2 Direction;

        public Rigidbody PlayerRb { get => playerRb; }
        public float Speed { get => speed; }

        #region UnityEvents
        private void Start()
        {
            PlayerMovementSystem.s_Instance.Components.Add(this);
            playerRb = GetComponent<Rigidbody>();
            Direction = Vector2.zero;
        }
        #endregion
    }
}