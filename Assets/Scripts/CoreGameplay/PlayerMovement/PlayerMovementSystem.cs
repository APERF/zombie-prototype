using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace CoreGameplay.PlayerMovement
{
    public class PlayerMovementSystem : Singleton<PlayerMovementSystem>
    {
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
            mover.PlayerRb.velocity = new Vector3(mover.Direction.x, 0, mover.Direction.y) * mover.Speed;
        }
    }
}