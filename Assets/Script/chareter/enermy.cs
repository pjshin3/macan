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
        me = this.GetComponent<Transform>();
        masterLocation = GameObject.FindWithTag("Master").GetComponent<Transform>();


       
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
