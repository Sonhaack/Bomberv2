using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookat : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
        // Update is called once per frame
        void LateUpdate()
        {
            // Rotate the camera every frame so it keeps looking at the target
            transform.LookAt(target);
            
        }
}
