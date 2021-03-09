using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myowncameratest : MonoBehaviour
{

    public GameObject player;
    public GameObject helderpos;
    public GameObject firstheldpos;
    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    // Update is called once per frame
    void Update()
    {
if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            firstheldpos.transform.position = helderpos.transform.position;
        }


        
        


        transform.position = player.transform.position;
    }
}
