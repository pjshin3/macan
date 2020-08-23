using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maincamera_action : MonoBehaviour
{
    public GameObject player;
    public GameObject Maincamera;

    public float offsetX = 0f;
    public float offsetY = 0f;
    public float offsetZ = 0f;
    public int followspeed = 0;

    public bool Shake = false;
    public float shakeTime = 0.3f;
    Vector3 cameraPosition;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Master");
        Maincamera = GameObject.Find("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    private void LateUpdate()
    {

    }

    private void FixedUpdate()
    {
        MoveCamera();
        shakeCamera();
    }


    void MoveCamera()
    {
        if(player.transform.localScale.x == -1)
        {
            cameraPosition.x = player.transform.position.x -offsetX;
        }
        else
        {
            cameraPosition.x = player.transform.position.x + offsetX;
        }
        cameraPosition.y = player.transform.position.y + offsetY;
        cameraPosition.z = player.transform.position.z + offsetZ;

        transform.position = Vector3.Lerp(transform.position, cameraPosition, followspeed * Time.deltaTime);
    }

   void shakeCamera()
    {
        if (Shake)
        {
            if(shakeTime > 0)
            {
                transform.position = Random.insideUnitSphere * 0.05f + transform.position;
                shakeTime -= Time.deltaTime;
            }
            else
            {
                shakeTime = 0;
                Shake = false;
            }
        }
    }
}
