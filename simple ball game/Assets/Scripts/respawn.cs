
using UnityEngine;
using UnityEngine.SceneManagement;
public class respawn : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("respawn"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        }
        if (other.gameObject.CompareTag("respawn2"))
        {
            gameObject.transform.position = new Vector3(-232, 10, -10);
        }
    }

}
