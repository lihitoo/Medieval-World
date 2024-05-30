using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform target;
    private float smoothTime = 0.3f;
    [SerializeField] private Vector3 offset;
     private Vector3 velocity = Vector3.zero;

    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 targetPos = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
        //transform.rotation = target.transform.rotation;
    }
}
