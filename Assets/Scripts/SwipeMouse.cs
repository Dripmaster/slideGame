using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeMouse : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public float speed = 1.0f;
    public float breakPower = 0.5f;
    Vector2 moveDir = Vector2.zero;
    bool slideChance = true;
    float clickPosY = 0f;
    float tempTime = 0f;

    void Update()
    {
        //if (slideChance == true && Input.GetMouseButtonDown(0))
        //{
        //    moveDir = new Vector2(transform.position.x, transform.position.y + Input.GetTouch(0).deltaPosition.y * speed);

        //    if (Input.GetMouseButtonUp(0))
        //    {
        //        slideChance = false;
        //    }
        //}
        //else if (Input.GetMouseButtonDown(0) && (Input.GetTouch(0).phase == TouchPhase.Stationary || Input.GetTouch(0).phase == TouchPhase.Moved))
        //{
        //    moveDir.y *= 0.995f;
        //}
        
        if (slideChance)
            tempTime += Time.deltaTime;
        if (slideChance == false)
        {
            float speedBreak = (Input.GetMouseButton(0) ? breakPower:1f);
            GetComponent<controlIce>().setFrom(transform.position);
            transform.position = Vector2.Lerp(transform.position, moveDir, Time.deltaTime * speed*speedBreak);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (slideChance)
        {
            clickPosY = Input.mousePosition.y;
            tempTime = 0f;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (slideChance)
        {
            float movePosY = (Input.mousePosition.y - clickPosY) * 10 / 1920 / tempTime;
            if (movePosY > 0)
            {
                moveDir = new Vector2(transform.position.x, transform.position.y + movePosY);
                GetComponent<controlIce>().setControllable(true);
                slideChance = false;
            }
        }
    }
}