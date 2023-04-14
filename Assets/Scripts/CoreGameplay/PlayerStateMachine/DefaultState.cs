using CoreGameplay.PlayerMovement;

namespace CoreGameplay.PlayerStateMachine
{
    public class DefaultState : BaseState
    {
        private PlayerMover mover;

        public DefaultState(PlayerStateMachine owner, PlayerMover playerMover) : base(owner)
        {
            mover = playerMover;
        }

        public override void Finish()
        {
            PlayerMovementSystem.s_Instance.Components.Remove(mover);
        }

        public override void Start()
        {
            mover.RotateAlways = false;
            PlayerMovementSystem.s_Instance.Components.Add(mover);
        }

        public override void Update()
        {
            if(owner.IsAiming)
            {
                owner.ChangeState(new AimingState(owner, mover, owner.AimCamera, owner.MovementAnimationHandler, owner.Crosshair, owner.Rig, owner.AimingRotator));
            }
        }
    }
}