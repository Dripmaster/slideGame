using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRig : MonoBehaviour
{
    public Transform iceTransform;
    public Transform goalTransform;
    public float cameraSpeed;
    bool ready = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(0,goalTransform.position.y-10);
        StartCoroutine("timer");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(ready)
        transform.position = Vector2.Lerp(transform.position,iceTransform.position,Time.deltaTime*cameraSpeed);
    }

    IEnumerator timer() {

        yield return new WaitForSeconds(1);
        ready = true;

        yield return null;
    }
}
