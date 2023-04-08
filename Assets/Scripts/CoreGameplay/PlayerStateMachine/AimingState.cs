using UnityEngine;
using CoreGameplay.PlayerMovement;

namespace CoreGameplay.PlayerStateMachine
{
    public class AimingState : BaseState
    {
        private PlayerMover mover;
        private GameObject aimCamera;
        private MovementAnimationHandler animationHandler;
        private GameObject crosshair;

        public AimingState(PlayerStateMachine owner, PlayerMover mover, GameObject aimCamera, MovementAnimationHandler animationHandler, GameObject crosshair) : base(owner)
        {
            this.mover = mover;
            this.aimCamera = aimCamera;
            this.animationHandler = animationHandler;
            this.crosshair = crosshair;
        }

        public override void Finish()
        {
            PlayerMovementSystem.s_Instance.Components.Remove(mover);
            aimCamera.SetActive(false);
            animationHandler.SetAim(false);
            crosshair.SetActive(false);
        }

        public override void Start()
        {
            mover.RotateAlways = true;
            PlayerMovementSystem.s_Instance.Components.Add(mover);
            aimCamera.SetActive(true);
            animationHandler.SetAim(true);
            crosshair.SetActive(true);
        }

        public override void Update()
        {
            if(!owner.IsAiming)
            {
                owner.ChangeState(new DefaultState(owner, mover));
            }
        }
    }
}