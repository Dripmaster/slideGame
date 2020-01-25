using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalScript : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Awake() { 

        Vector3 posVec = GetComponent<RectTransform>().position;
        posVec.y = Random.Range(10, 100);
        GetComponent<RectTransform>().position = posVec;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
