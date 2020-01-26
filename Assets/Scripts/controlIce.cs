using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlIce : MonoBehaviour
{

    bool controllable = false;
    Vector2 fromPosition = Vector2.zero;
    float speed;
    public float gyroSpeed=10f;
    // Start is called before the first frame update
    void Awake()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        fromPosition = transform.position;
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
        speed = distance / Time.deltaTime;
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
