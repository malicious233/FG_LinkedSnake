using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [Header("CAMERA SETTINGS:")]
    [SerializeField] Transform target;
    [Tooltip("The lower the value, the faster the cameraspeed")]
    [SerializeField] float camDampRate = 1f;


    private Vector3 camVelocity;

    public void LateUpdate()
    {
        Vector3 targetPos = Vector3.SmoothDamp(transform.position, target.position, ref camVelocity, camDampRate);
        Vector3 moveToPos = new Vector3(targetPos.x, targetPos.y, transform.position.z);
        transform.position = moveToPos;
    }
}
