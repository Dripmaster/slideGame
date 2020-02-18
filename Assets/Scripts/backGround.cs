using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backGround : MonoBehaviour
{
    public Transform cameraT;
    float tempY;
    // Start is called before the first frame update
    void Awake()
    {
        tempY = cameraT.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraT.position.y > tempY) {
            if (cameraT.position.y - transform.position.y > 22.5f)
            {
                transform.Translate(new Vector2(0, 38.4f * 2f));
            }
        }
        else if(cameraT.position.y < tempY)
        {
            if (transform.position.y - cameraT.position.y > 40f)
            {
                transform.Translate(new Vector2(0, -38.4f * 2f));
            }
        }

        tempY = cameraT.position.y;
    }

    void makeBackGround() {
        
    }
}
