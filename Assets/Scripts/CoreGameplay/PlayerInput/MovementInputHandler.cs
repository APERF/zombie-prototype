using UnityEngine;
using CoreGameplay.PlayerMovement;
using UnityEngine.InputSystem;
using Utils;

namespace CoreGameplay.PlayerInput
{
    public class MovementInputHandler : MonoBehaviour
    {
        public UnityBoolEvent OnAim;

        [SerializeField] private PlayerMover _playerMover;

        public void Move(InputAction.CallbackContext context)
        {
            MovementInputSystem.s_Instance.PlayerMover(context, _playerMover);
        }

        public void Aim(InputAction.CallbackContext context)
        {
            if(context.performed)
            {
                OnAim?.Invoke(true);
            }

            if(context.canceled)
            {
                OnAim?.Invoke(false);
            }
        }
    }
}