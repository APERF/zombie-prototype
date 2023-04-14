using UnityEngine;
using CoreGameplay.PlayerMovement;
using UnityEngine.Animations.Rigging;

namespace CoreGameplay.PlayerStateMachine
{
    public class AimingState : BaseState
    {
        private PlayerMover mover;
        private GameObject aimCamera;
        private MovementAnimationHandler animationHandler;
        private GameObject crosshair;
        private Rig rig;
        private PlayerAimingRotator aimingRotator;

        public AimingState(PlayerStateMachine owner, PlayerMover mover, GameObject aimCamera, MovementAnimationHandler animationHandler, GameObject crosshair, Rig rig, PlayerAimingRotator aimingRotator) : base(owner)
        {
            this.mover = mover;
            this.aimCamera = aimCamera;
            this.animationHandler = animationHandler;
            this.crosshair = crosshair;
            this.rig = rig;
            this.aimingRotator = aimingRotator;
        }

        public override void Start()
        {
            mover.RotateAlways = false;
            PlayerMovementSystem.s_Instance.Components.Add(mover);
            aimCamera.SetActive(true);
            animationHandler.SetAim(true);
            crosshair.SetActive(true);
            rig.weight = 1f;
            aimingRotator.Rotate = true;
        }

        public override void Finish()
        {
            PlayerMovementSystem.s_Instance.Components.Remove(mover);
            aimCamera.SetActive(false);
            animationHandler.SetAim(false);
            crosshair.SetActive(false);
            rig.weight = 0f;
            aimingRotator.Rotate = false;
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