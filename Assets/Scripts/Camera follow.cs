using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    [SerializeField] Transform playerlocation;
    public float smoothfollow = 1f;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        camerafollow();
    }
    private void camerafollow()
    {
        Vector3 smoothmove = playerlocation.position;
        transform.position = Vector3.SmoothDamp(transform.position, smoothmove,ref velocity , 1f);
    }
}
