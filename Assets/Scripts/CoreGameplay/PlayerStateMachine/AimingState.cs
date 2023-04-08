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

        public AimingState(PlayerStateMachine owner, PlayerMover mover, GameObject aimCamera, MovementAnimationHandler animationHandler, GameObject crosshair, Rig rig) : base(owner)
        {
            this.mover = mover;
            this.aimCamera = aimCamera;
            this.animationHandler = animationHandler;
            this.crosshair = crosshair;
            this.rig = rig;
        }

        public override void Finish()
        {
            PlayerMovementSystem.s_Instance.Components.Remove(mover);
            aimCamera.SetActive(false);
            animationHandler.SetAim(false);
            crosshair.SetActive(false);
            rig.weight = 0f;
        }

        public override void Start()
        {
            mover.RotateAlways = true;
            PlayerMovementSystem.s_Instance.Components.Add(mover);
            aimCamera.SetActive(true);
            animationHandler.SetAim(true);
            crosshair.SetActive(true);
            rig.weight = 1f;
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