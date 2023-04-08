using UnityEngine;

namespace CoreGameplay.PlayerStateMachine
{
    public abstract class BaseState
    {
        protected PlayerStateMachine owner;

        public virtual void Start()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void Finish()
        {

        }

        public BaseState(PlayerStateMachine owner)
        {
            this.owner = owner;
        }
    }
}