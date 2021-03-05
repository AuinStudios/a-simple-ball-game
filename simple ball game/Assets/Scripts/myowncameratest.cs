using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myowncameratest : MonoBehaviour
{

    public GameObject player;
    // Update is called once per frame
    void Update()
    {

        Input.GetAxisRaw("Mouse X");
        Input.GetAxisRaw("Mouse Y");



        
        


        transform.position = player.transform.position;
    }
}
