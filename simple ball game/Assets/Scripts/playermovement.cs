using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class playermovement : MonoBehaviour
{

    public  Rigidbody rig;
    public  Transform player;
    public float maxspeed = 300f;
    private  float forwardspeed = 300f;
    private  float backwards = -300f;
    private  float right = 300f;
    private  float left = -300f;
    public GameObject GFX;
    public float jumpower = 60000f;
    public bool isgroundedboi;
    private  float dontjump = 0f;
    public TextMeshPro text;
    
    
    // Start is called before the first frame update
    void Start()
    {// so the i++ adds   a number and it loops again adding untll its 10 bc when the 10 isnt bigger then the i then it stops
        text.color = new Color(0, 0, 0, 0);
        for (int i = 0; i < 10; i++)
        {
            Debug.Log("For loop cycle:" + i);
        }
    }


    void FixedUpdate()
    {
       rig.velocity = Vector3.ClampMagnitude(rig.velocity, maxspeed);
    }
    // Update is called once per frame
    void Update()
    {
        

        transform.position = GFX.transform.position;

        pllayermovement();

    }

    public void OnCollisionEnter(Collision collision)
    {
       
    }



    public void OnTriggerExit(Collider other2)
    {
        isgroundedboi = false;

        text.color = new Color(0, 0, 0, 0);


    }




  

    public void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("appeartext"))
        {
            text.color = new Color(0, 255, 41, 255);
        }


        if (other.gameObject.CompareTag("groundballgame"))
        {
            isgroundedboi = true;
        }

       if (other.gameObject.CompareTag("groundspin"))
        {
            isgroundedboi = true;
           
        }
        if (other.gameObject.CompareTag("Finishedlevel"))
        {
            SceneManager.LoadScene("Menu");
        }

            if (other.gameObject.CompareTag("swingingobject"))
        {
            rig.AddForce(transform.forward * -10000f * Time.deltaTime, ForceMode.Impulse);
            rig.AddForce(transform.up * 4000f * Time.deltaTime, ForceMode.Impulse);
        }


        if (other.gameObject.CompareTag("bouncepad"))
        {
            rig.AddForce(transform.up *  20000f * Time.deltaTime, ForceMode.Impulse);
        }

    }


    public void pllayermovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rig.AddForce(player.forward * forwardspeed * Time.deltaTime, ForceMode.Impulse);


        }






        if (Input.GetKey(KeyCode.S))
        {
            rig.AddForce(player.forward * backwards * Time.deltaTime, ForceMode.Impulse);

        }


        if (Input.GetKey(KeyCode.D))
        {
            rig.AddForce(player.right * right * Time.deltaTime, ForceMode.Impulse);

        }



        if (Input.GetKey(KeyCode.A))
        {
            rig.AddForce(player.right * left * Time.deltaTime, ForceMode.Impulse);

        }




        if (!isgroundedboi)
        {
            rig.AddForce(player.up * dontjump * Time.deltaTime, ForceMode.Impulse);






        }


        if (isgroundedboi && (Input.GetKeyDown(KeyCode.Space)))
        {
            rig.AddForce(player.up * jumpower * Time.deltaTime, ForceMode.Impulse);

        }
    }









}
