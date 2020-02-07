using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRig : MonoBehaviour
{
    public Transform iceTransform;
    public Transform goalTransform;
    public float cameraSpeed;
    bool ready = false;


    void Awake() {
        //Screen.SetResolution(Screen.width, (Screen.width * 16) / 9, true);
        ResolutionFix();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(0,goalTransform.position.y-7.5f);
        StartCoroutine("timer");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (ready)
        {
            Vector2 moveDir = new Vector2();
            moveDir = Vector2.Lerp(transform.position, iceTransform.position, Time.deltaTime * cameraSpeed);
            if (moveDir.y >= goalTransform.position.y - 7.5f)
            {
                moveDir.y = goalTransform.position.y - 7.5f;
            }
            moveDir.x = 0;
            transform.position = moveDir;
        }
        
    }
    void ResolutionFix()
    {
        // 가로 세로 비율
        float targetWidthAspect = 9.0f;
        float targetHeightAspect = 16.0f;
       
        Camera.main.aspect = targetWidthAspect / targetHeightAspect;

        float targetWidthAspectPort = targetWidthAspect / targetHeightAspect;
        float targetHeightAspectPort = targetHeightAspect / targetWidthAspect;

        float currentWidthAspectPort = (float)Screen.width / (float)Screen.height;
        float currentHeightAspectPort = (float)Screen.height / (float)Screen.width;

        float viewPortW = targetWidthAspectPort / currentWidthAspectPort;
        float viewPortH = targetHeightAspectPort / currentHeightAspectPort;
            

        Camera.main.rect = new Rect(
            (1-viewPortW)/2,
            (1 - viewPortH) / 2,
            viewPortW,
            viewPortH);
    }


    IEnumerator timer() {

        yield return new WaitForSeconds(1);
        ready = true;

        yield return null;
    }
}
