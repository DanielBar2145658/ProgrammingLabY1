using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(1, 3)]
    public float smoothfactor;

    // Update is called once per frame
    void Update()
    {
        Follow();  
    }

    void Follow() 
    {
        var targetPos = target.position + offset;
        var smooth = Vector3.Lerp(transform.position, targetPos, smoothfactor * Time.fixedDeltaTime);

        transform.position = targetPos;
    }
}
