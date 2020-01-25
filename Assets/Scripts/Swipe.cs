using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    public float speed = 1.0f;
    Vector2 moveDir = Vector2.zero;
    bool slideChance = true;
    void Update()
    {
        if (slideChance == true && Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                moveDir = new Vector2(transform.position.x, transform.position.y + Input.GetTouch(0).deltaPosition.y * speed);
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                slideChance = false;
            }
        }
        else if (Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Stationary || Input.GetTouch(0).phase == TouchPhase.Moved)) {
            moveDir.y *= 0.995f;
        }
         if(moveDir.y>transform.position.y)
         transform.position = Vector2.Lerp(transform.position, moveDir, Time.deltaTime);
    }

}