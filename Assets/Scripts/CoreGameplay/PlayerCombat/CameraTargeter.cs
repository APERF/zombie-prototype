using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargeter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _target;

    private bool isAiming;

    public void SetAim(bool isAiming)
    {
        this.isAiming = isAiming;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAiming) return;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = _camera.ScreenPointToRay(screenCenterPoint);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity))
        {
            _target.position = raycastHit.point;
        }
    }
}
