using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinboi : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    // Update is called once per frame
    void Update()
    {

       

        if (gameObject.CompareTag("swingingobject"))
        {
          transform.Rotate(0, -8, 0 * Time.deltaTime);
        }
        
    }
}
