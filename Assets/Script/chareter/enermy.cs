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
    void LateUpdate()
    {
        moving();
    }

    void moving()
    {
        string dist = "";
        Vector3 move = Vector3.zero;

        if(masterLocation.position.x < transform.position.x)
        {
            dist = "Left";
        }
        else if(masterLocation.position.x > transform.position.x)
        {
            dist = "Right";
        }
        
        if(dist == "Left")
        {
            move = new Vector3(1, 1, 1);
        }else if(dist == "Right")
        {
            move = new Vector3(-1, 1, 1);
        }

        transform.position = Vector3.Lerp(transform.position, masterLocation.position, speed * Time.deltaTime);
    }
}
