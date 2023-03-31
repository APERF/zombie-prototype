using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace CoreGameplay.PlayerMovement
{
    public class PlayerMovementSystem : Singleton<PlayerMovementSystem>
    {
        [SerializeField] private float _moveThreshold = 2f;

        public List<PlayerMover> Components;
        public bool AimingState;

        private void FixedUpdate()
        {
            foreach (var component in Components)
            {
                Move(component);
            }
        }

        public void Move(PlayerMover mover)
        {
            AlterPosition(mover);
            AlterRotation(mover);
        }

        private void AlterPosition(PlayerMover mover)
        {
            float y = mover.PlayerRb.velocity.y;

            Vector3 moveDirection = new Vector3(mover.Direction.x, y, mover.Direction.y);
            moveDirection = mover.MainCamera.TransformDirection(moveDirection);
            moveDirection.y = y;
            moveDirection *= mover.Speed;
            mover.PlayerRb.velocity = moveDirection;
        }

        private void AlterRotation(PlayerMover mover)
        {
            Vector3 lookAtPos = mover.MainCamera.TransformPoint(new Vector3(0f, 0f, 10f));
            lookAtPos.y = mover.transform.position.y;
            mover.Target.position = lookAtPos;

            if (mover.Direction.magnitude * 10f > _moveThreshold || AimingState)
            {
                Vector3 relativePos = mover.Target.position - mover.transform.position;
                Quaternion newRotation = Quaternion.LookRotation(relativePos, Vector3.up);
                mover.transform.rotation = newRotation;
            }
        }
    }
}