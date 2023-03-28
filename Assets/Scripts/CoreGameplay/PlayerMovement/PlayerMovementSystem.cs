using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace CoreGameplay.PlayerMovement
{
    public class PlayerMovementSystem : Singleton<PlayerMovementSystem>
    {
        [SerializeField] private GameObject _mainCamera;
        [SerializeField] private GameObject _target;
        [SerializeField] private float _moveThreshold = 2f;

        public List<PlayerMover> Components;

        private void FixedUpdate()
        {
            foreach (var component in Components)
            {
                Move(component);
            }
        }

        public void Move(PlayerMover mover)
        {
            float y = mover.PlayerRb.velocity.y;

            Vector3 moveDirection = new Vector3(0, y, mover.Direction.y);
            moveDirection = _mainCamera.transform.TransformDirection(moveDirection);
            moveDirection.x += mover.Direction.x;
            moveDirection.y = y;
            moveDirection *= mover.Speed;
            mover.PlayerRb.velocity = moveDirection;

            Vector3 lookAtPos = _mainCamera.transform.forward * 10;
            lookAtPos.y = mover.transform.position.y;
            _target.transform.position = lookAtPos;
            
            if(moveDirection.magnitude * 10f > _moveThreshold)
            {
                Vector3 relativePos = _target.transform.position - mover.transform.position;
                Quaternion newRotation = Quaternion.LookRotation(relativePos, Vector3.up);
                mover.transform.rotation = newRotation;
            }
        }
    }
}