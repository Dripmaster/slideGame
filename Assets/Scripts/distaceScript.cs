using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class distaceScript : MonoBehaviour
{
    public Text t;

    public Transform goal;
    public Transform ice;
    public Transform CameraT;
    Image myImage;
    int dis;
    float screenHeight;
    bool myOn;
    Camera c;
    // Start is called before the first frame update
    void Awake()
    {
        myImage = GetComponent<Image>();
        myOn = true;
        dis = 0;
        c = Camera.main;
        setPos();
        screenHeight = Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (goal.position.y - CameraT.position.y >= 15.5f) {//화면밖으로 나가면
            if (!myOn) myOn = true;
        }
        else
        {
            if (myOn) myOn = false;
        }
        
        setPos();
        setDis();
    }

    void setDis() {

        int disT = (int)Vector2.Distance(goal.transform.position, ice.transform.position);
        
        if (dis != disT)
        {
            t.text = (disT).ToString();
            dis = disT;
        }
    }
    void setPos() {
        Vector2 tempPos = transform.position; 
        if (myOn) {
            tempPos.x = c.WorldToScreenPoint(goal.position).x ;
            tempPos.y = screenHeight;
        }
        if (!myOn) {
            tempPos= c.WorldToScreenPoint(goal.position);
        }
        transform.position = tempPos;
    }
}
