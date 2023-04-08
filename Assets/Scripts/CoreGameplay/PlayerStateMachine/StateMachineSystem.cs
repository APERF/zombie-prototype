using System.Collections.Generic;
using Utils;

namespace CoreGameplay.PlayerStateMachine
{
    public class StateMachineSystem : Singleton<StateMachineSystem>
    {
        public List<PlayerStateMachine> Components;

        private void Update()
        {
            foreach(var component in Components)
            {
                component.CurrentState.Update();
            }
        }
    }
}