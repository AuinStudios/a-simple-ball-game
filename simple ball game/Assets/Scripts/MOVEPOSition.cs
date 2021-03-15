using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVEPOSition : MonoBehaviour
{
    
     public Rigidbody rig;
    public float maxspeed = 50f;
    private float backforward = -12f;
    private float forward = 12f;
    private float back = -12f;
    public Transform addforcedirection;
    public Transform addforce2nd;
    // Start is called before the first frame update


    public void OnCollisionExit(Collision collision)
    {
        
        rig.freezeRotation = false;
        rig.velocity = new Vector3 (40,0,0) * Time.deltaTime;
    }

    public void OnCollisionStay(Collision collision)
    {
            if (collision.gameObject.CompareTag("mover2"))
            {
            rig.AddForce(addforce2nd.right * backforward* Time.deltaTime, ForceMode.Impulse);

            rig.freezeRotation = true;
            }


            if (collision.gameObject.CompareTag("mover"))
            {
            rig.AddForce(addforcedirection.right * forward * Time.deltaTime, ForceMode.Impulse);

            rig.freezeRotation = true;




            }
            else
            {
            
            rig.freezeRotation = true;
            rig.AddForce(addforcedirection.forward * back* Time.deltaTime, ForceMode.Impulse);
            }
    }


    public void Update()
    {
        if (rig.velocity.magnitude > maxspeed)
        {
          rig.velocity = Vector3.ClampMagnitude(rig.velocity, maxspeed);
        }



        
    }

}
