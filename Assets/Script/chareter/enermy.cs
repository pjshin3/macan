using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enermy : MonoBehaviour
{

    public float speed = 0.5f;
    public Transform me;
    Transform masterLocation;
   


    // Start is called before the first frame update
    void Start()
    {
        masterLocation = GameObject.Find("Master").transform;  
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    void FixedUpdate()
    {
        moving();
    }

    void moving()
    {
        string dist = "";

        if(masterLocation.position.x < me.position.x)
        {
            dist = "Left";
        }
        else if(masterLocation.position.x > me.position.x)
        {
            dist = "Right";
        }
        
        if(dist == "Left")
        {
            me.localScale = new Vector3(1, 1, 1);
        }else if(dist == "Right")
        {
            me.localScale = new Vector3(-1, 1, 1);
        }

        me.position += masterLocation.position * speed * Time.deltaTime;
        Debug.Log("지금 마스터의 위치 " + masterLocation.position + masterLocation.localPosition);
    }
}
