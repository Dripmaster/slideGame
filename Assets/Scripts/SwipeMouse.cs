using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeMouse : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public float speed = 1.0f;
    public float maxbreakPower = 0.5f;
    float breakPower = 1f;
    public float speedChangeDegree = 2f;//속도가 변화하는 정도(커질수록 변화 빠름)
    public float speedDownDegree = 2f;//속도가 점점 하락하는 정도(커질수록 빨리 느려짐)
    public float speedStartPoint = 5f;//속도 첫 시작점(최대속도/n)
    float moveDir = 0;
    float moveDirBreak;
    bool slideChance = true;
    float clickPosY = 0f;
    float tempTime = 0f;

    void Update()
    {
        if (slideChance && Input.mousePosition.y > clickPosY + 10)
        {
            tempTime += Time.deltaTime;
        }
        if (slideChance == false)
        {
            if (Input.GetMouseButton(0))
            {

                breakPower = Mathf.Lerp(breakPower, maxbreakPower, Time.deltaTime);

            }
            else
            {
                maxbreakPower = breakPower / 2f;
            }

            GetComponent<controlIce>().setFrom(transform.position);
            moveDirBreak = Mathf.Lerp(moveDirBreak, moveDir * breakPower, Time.deltaTime * speedChangeDegree);
            transform.Translate(Vector2.up * Time.deltaTime * speed * moveDirBreak);
            moveDir = Mathf.Lerp(moveDir, 0, Time.deltaTime / speedDownDegree);
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
            moveDirBreak = moveDir / speedStartPoint;
            if (moveDir > 0)
            {
                GetComponent<controlIce>().setControllable(true);
                slideChance = false;
            }
        }
    }
}