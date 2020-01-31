using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRig : MonoBehaviour
{
    public Transform iceTransform;
    public Transform goalTransform;
    public float cameraSpeed;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = goalTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector2.Lerp(transform.position,iceTransform.position,Time.deltaTime*cameraSpeed);
        if (Vector2.Distance(transform.position, iceTransform.position) < 5f) {
            cameraSpeed = 10;
        }
    }
}
