using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class controlIce : MonoBehaviour
{
    

    bool controllable = false;
    Vector2 fromPosition = Vector2.zero;
    float speed;
    public float gyroSpeed=10f;
    public Text t;//임시용
    // Start is called before the first frame update
    void Awake()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (controllable)
            gyroMove();
    }
    void LateUpdate() {
        calcSpeed();
        
    }
    
    void gyroMove() {
        Vector2 moveDir = new Vector2(transform.position.x + Input.gyro.gravity.x, transform.position.y);
        transform.position = Vector2.Lerp(transform.position, moveDir, Time.deltaTime * gyroSpeed);
    }
    void calcSpeed() {
        float distance = Vector2.Distance(fromPosition, transform.position);
        if (speed != Mathf.Round(distance / Time.deltaTime)) {
            speed = Mathf.Round(distance / Time.deltaTime);
            t.text = speed.ToString();
        }
    }
    public bool getControllable() {
        return controllable;
    }
    public void setFrom(Vector2 f) {
        fromPosition = f;
    }

    public void setControllable(bool v)
    {
        controllable = v;
    }
    public float getSpeed()
    {
        return speed;
    }
}
