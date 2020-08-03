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
      
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        masterLocation = GameObject.Find("Master").transform;

        me.localPosition = new Vector3(masterLocation.localPosition.x * speed * Time.deltaTime, masterLocation.localPosition.y * speed * Time.deltaTime, -1);
    }
}
