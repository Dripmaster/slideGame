using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class goalScript : MonoBehaviour
{
    controlIce ice;
    
    // Start is called before the first frame update
    void Awake() { 

        Vector3 posVec = GetComponent<RectTransform>().position;
        posVec.x = Random.Range(-4, 4);
        posVec.y = Random.Range(10, 100);
        GetComponent<RectTransform>().position = posVec;
        ice = GameObject.Find("ICE").GetComponent<controlIce>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ice.getSpeed() < 1f && Vector2.Distance(transform.position, ice.transform.position) < 1f)
        {//low speed, goal
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (ice.getSpeed() < 0.5f&&ice.getControllable())
        {//low speed, no goal

        }
        else if (Vector2.Distance(transform.position, ice.transform.position) < 1f)
        {//goal, but too fast

        }
    }
}
