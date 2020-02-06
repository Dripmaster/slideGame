using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backGround : MonoBehaviour
{
    public GameObject backGroundPrefab;
    bool once;
    // Start is called before the first frame update
    void Awake()
    {
        once = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!once) {
            once = true;
            makeBackGround();
        }
    }

    void makeBackGround() {
        if (transform.position.y <= 26.6)
            return;
        int index = (int)((transform.position.y-26.6f) / 38.3f);

        for (int i = 0; i <= index; i++) {
            Instantiate(backGroundPrefab, new Vector2(0, 7.5f+38.3f * (i+1)), Quaternion.identity);
        }
    }
}
