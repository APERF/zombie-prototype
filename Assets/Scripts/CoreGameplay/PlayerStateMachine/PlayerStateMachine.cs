using CoreGameplay.PlayerMovement;
using UnityEngine;
using UnityEngine.Animations.Rigging;

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
        [SerializeField] private Rig rig;

        public PlayerMover PlayerMover { get => playerMover; }
        public GameObject AimCamera { get => aimCamera;  }
        public MovementAnimationHandler MovementAnimationHandler { get => movementAnimationHandler;  }
        public bool IsAiming { get => isAiming; set => isAiming = value; }
        public GameObject Crosshair { get => crosshair; }
        public BaseState CurrentState { get => currentState; }
        public Rig Rig { get => rig; }

        public void ChangeState(BaseState newState)
        {
            currentState?.Finish();
            currentState = newState;
            currentState.Start();
        }

        private void Start()
        {
            ChangeState(new DefaultState(this, playerMover));
            StateMachineSystem.s_Instance.Components.Add(this);
        }

        private void OnDestroy()
        {
            StateMachineSystem.s_Instance.Components.Remove(this);
        }
    }
}