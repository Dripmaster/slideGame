using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRig : MonoBehaviour
{
    public Transform iceTransform;
    public float cameraSpeed;
    // Start is called before the first frame update
    void Awake()
    {
        transform.position = iceTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector2.Lerp(transform.position,iceTransform.position,Time.deltaTime*cameraSpeed);
    }
}
