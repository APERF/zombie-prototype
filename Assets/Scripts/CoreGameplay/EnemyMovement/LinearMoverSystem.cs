using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace CoreGameplay.EnemyMovement
{
    public class LinearMoverSystem : Singleton<LinearMoverSystem>
    {
        public List <LinearMoverComponent> Components;

        private void Update()
        {
            foreach(var component in Components)
            {
                Vector3 direction = component.Target.position - component.transform.position;
                direction.Normalize();
                component.transform.Translate(direction * component.Speed * Time.deltaTime);
            }
        }
    }
}