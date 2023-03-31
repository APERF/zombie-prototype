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
        [SerializeField] private GameObject _aimCamera;

        public void Move(InputAction.CallbackContext context)
        {
            MovementInputSystem.s_Instance.PlayerMover(context, _playerMover);
        }

        public void Aim(InputAction.CallbackContext context)
        {
            _aimCamera.SetActive(!_aimCamera.activeSelf);
            OnAim?.Invoke(_aimCamera.activeSelf);
            PlayerMovementSystem.s_Instance.AimingState = _aimCamera.activeSelf;
        }
    }
}