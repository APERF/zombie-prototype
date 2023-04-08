using CoreGameplay.PlayerMovement;
using UnityEngine;

namespace CoreGameplay.PlayerStateMachine
{
    public class PlayerStateMachine : MonoBehaviour
    {
        private BaseState currentState;
        
        private bool isAiming;

        [SerializeField] private PlayerMover playerMover;
        [SerializeField] private GameObject aimCamera;
        [SerializeField] private MovementAnimationHandler movementAnimationHandler;
        [SerializeField] private GameObject crosshair;

        public PlayerMover PlayerMover { get => playerMover; }
        public GameObject AimCamera { get => aimCamera;  }
        public MovementAnimationHandler MovementAnimationHandler { get => movementAnimationHandler;  }
        public bool IsAiming { get => isAiming; set => isAiming = value; }
        public GameObject Crosshair { get => crosshair; }
        public BaseState CurrentState { get => currentState; }

        public void ChangeState(BaseState newState)
        {
            currentState?.Finish();
            currentState = newState;
            currentState.Start();
        }

        private void Start()
        {
            ChangeState(new DefaultState(this, playerMover));
        }
    }
}