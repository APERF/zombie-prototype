using UnityEngine;
using CoreGameplay.PlayerMovement;
using UnityEngine.InputSystem;

namespace CoreGameplay.PlayerInput
{
    public class MovementInputHandler : MonoBehaviour
    {
        [SerializeField] private PlayerMover playerMover;

        public void Move(InputAction.CallbackContext context)
        {
            MovementInputSystem.s_Instance.PlayerMover(context, playerMover);
        }
    }
}