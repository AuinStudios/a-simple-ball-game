using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class respawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("respawn"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        }
        if (other.gameObject.CompareTag("respawn2"))
        {
            gameObject.transform.position = new Vector3(-232, 1, -10);
        }
    }
// Update is called once per frame
void Update()
    {
        
    }
}
