using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeMouse : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public float speed = 1.0f;
    public float maxbreakPower = 0.5f;
    float breakPower=1f;
    public float speedUpDegree=2f;
    public float speedDownDegree = 2f;
    float moveDir = 0;
    float moveDirBreak;
    bool slideChance = true;
    float clickPosY = 0f;
    float tempTime = 0f;

    void Update()
    {
        
        
        if (slideChance)
            tempTime += Time.deltaTime;
        if (slideChance == false)
        {
            if (Input.GetMouseButton(0))
            {

                breakPower = Mathf.Lerp(breakPower, maxbreakPower, Time.deltaTime);

            }
            else {
                maxbreakPower = breakPower / 2f;
            }
            
            GetComponent<controlIce>().setFrom(transform.position);
            moveDirBreak = Mathf.Lerp(moveDirBreak,moveDir * breakPower,Time.deltaTime* speedUpDegree);
            transform.Translate(Vector2.up * Time.deltaTime * speed  * moveDirBreak);
            moveDir = Mathf.Lerp(moveDir, 0, Time.deltaTime/ speedDownDegree);
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
            moveDir = (Input.mousePosition.y - clickPosY) * 16 / Screen.height / tempTime;
            moveDirBreak = moveDir / 2f;
            if (moveDir > 0)
            {
                GetComponent<controlIce>().setControllable(true);
                slideChance = false;
            }
        }
    }
}