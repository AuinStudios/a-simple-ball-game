using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVEPOSition : MonoBehaviour
{
    
     public Rigidbody rig;
    public float maxspeed = 50f;
    private float fasterforward = 20f;
    private float upforce = 1000f;
    private float forward = 15f;
    private float back = -12f;
    public Transform addforcedirection;
    // Start is called before the first frame update


   public void OnCollisionExit(Collision collision)
   {
       
       rig.freezeRotation = false;
       
   }



    public void OnCollisionEnter(Collision collision)
    {

            if ((collision.gameObject.CompareTag("mover2")))
            {
            rig.velocity = new Vector3(60, 0, 0) * Time.deltaTime;
            }

            if (collision.gameObject.CompareTag("Untagged"))
            {
            rig.velocity = new Vector3(60, 0, 0) * Time.deltaTime;
            }
            if (collision.gameObject.CompareTag("bouncepad"))
            {
            rig.AddForce(addforcedirection.up *upforce * Time.deltaTime, ForceMode.Impulse);
            rig.AddTorque(addforcedirection.up * upforce * Time.deltaTime, ForceMode.Impulse);
            rig.AddTorque(addforcedirection.right * upforce * Time.deltaTime , ForceMode.Impulse);
            rig.freezeRotation = false;
            }
    }



    public void OnCollisionStay(Collision collision)
    {
         

            if (collision.gameObject.CompareTag("mover"))
            {
            rig.AddForce(addforcedirection.right * forward * Time.deltaTime, ForceMode.Impulse);

            rig.freezeRotation = true;




            }
            else if (collision.gameObject.CompareTag("mover2"))
            {
            rig.freezeRotation = true;
            rig.AddForce(addforcedirection.forward * back* Time.deltaTime, ForceMode.Impulse);
           
        } 
            else if ((collision.gameObject.CompareTag("mover3")))
            {
            rig.AddForce(addforcedirection.right * back * Time.deltaTime, ForceMode.Impulse);
            
            rig.freezeRotation = true;
            }
            else if (collision.gameObject.CompareTag("lastmover"))
            {
            rig.AddForce(addforcedirection.forward * fasterforward * Time.deltaTime, ForceMode.Impulse);
            rig.freezeRotation = true;
            }

        

        
           
    }

    public void FixedUpdate()
    {
        if (rig.velocity.magnitude > maxspeed)
        {
          rig.velocity = Vector3.ClampMagnitude(rig.velocity, maxspeed);
        }
    }
  

}
