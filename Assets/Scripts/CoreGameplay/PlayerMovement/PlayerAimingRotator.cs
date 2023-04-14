using UnityEngine;

namespace CoreGameplay.PlayerMovement
{
    public class PlayerAimingRotator : MonoBehaviour
    {
        [SerializeField] private Transform _cameraTarget;
        [SerializeField] private float _threshold;

        public bool Rotate;

        // Start is called before the first frame update
        void Start()
        {
            Rotate = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (!Rotate) return;

            Vector3 cameraPos = _cameraTarget.position;
            Vector3 myPos = transform.position;
            cameraPos.y = 0;
            myPos.y = 0;
            Vector3 direction = cameraPos - myPos;
            Vector3 forward = transform.forward;
            forward.y = 0;
            float angle = Vector3.Angle(direction, forward);

            if(Mathf.Abs(angle) > _threshold)
            {
                Debug.Log("Angle is Greater");
                Quaternion newRotation = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = newRotation;
            }
        }
    }
}