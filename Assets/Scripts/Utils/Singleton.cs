using UnityEngine;

namespace Utils
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T s_Instance;

        private void Awake()
        {
            if(s_Instance == null)
            {
                s_Instance = this as T;
            }

            else if(s_Instance != this as T)
            {
                Destroy(this.gameObject);
            }
        }
    }
}