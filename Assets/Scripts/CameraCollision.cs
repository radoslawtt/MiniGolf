using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public float minDistance = 1.0f;
    public float maxDistance = 4.0f;
    public float smooth = 10.0f;
    Vector3 dollyDir;
    public float distance;

    // Start is called before the first frame update
    void Awake(){
        dollyDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredCameraPos = transform.parent.TransformPoint(dollyDir*maxDistance);
        RaycastHit hit;

        if(Physics.Linecast(transform.parent.position, desiredCameraPos, out hit)){
            distance = Math.Clamp((hit.distance)*0.9f, minDistance, maxDistance);
        }else{
            distance = maxDistance;
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir*distance, Time.deltaTime*smooth);
    }
}
