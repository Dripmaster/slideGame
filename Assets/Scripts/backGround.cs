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
        int index = (int)(transform.position.y / 26.6);

        for (int i = 1; i <= index; i++) {
            Instantiate(backGroundPrefab, new Vector2(0, 7.5f+38.3f * i), Quaternion.identity);
        }
    }
}
