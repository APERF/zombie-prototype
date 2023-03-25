using CoreGameplay.PlayerMovement;
using UnityEngine;
using UnityEngine.InputSystem;
using Utils;

namespace CoreGameplay.PlayerInput
{
    public class MovementInputSystem : Singleton<MovementInputSystem>
    {
        public void PlayerMover(InputAction.CallbackContext context, PlayerMover playerMover)
        {
            Vector2 inputValue = context.ReadValue<Vector2>();
            playerMover.Direction = inputValue;
        }
    }
}