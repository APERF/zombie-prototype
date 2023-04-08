using UnityEngine;

namespace CoreGameplay.PlayerMovement
{
    public class MovementAnimationHandler : MonoBehaviour
    {
        private Animator animator;
        [SerializeField] private float _animationTransition = 0.5f;

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
        }

        public void SetAnimation(Vector2 animationDirection)
        {
            animator.SetFloat("Forward", animationDirection.y, _animationTransition, Time.deltaTime);
            animator.SetFloat("Sideways", animationDirection.x, _animationTransition, Time.deltaTime);
        }

        public void SetAim(bool isAiming)
        {
            float weight = isAiming ? 1 : 0;
            animator.SetLayerWeight(1, weight);
            Debug.Log(weight);
        }
    }
}