using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewHitTrigger : MonoBehaviour
{
    public string task = "new task";

    [Header("Game objects")]
    public GameObject TriggerObject;
    public List<GameObject> ExtraTriggerObjects;
    public GameObject MovingObject;
    public List<GameObject> ExtraMovingObjects;

    //public GameObject cubeobject;

    [Header("Movement settings")]
    [SerializeField]
    Vector3 TargetPosition;
    [Range(0.1f, 10.0f)]
    public float MovingSpeed = 1.0f;
    public bool canDropDown = true;

    [Header("Particle settings")]
    public bool canEmmitParticles = false;
    public ParticleSystem Particles;
    [Range(1.0f, 5.0f)]
    public float DropMultiplier = 1.0f;

    [Header("Gizmos settings")]
    public Color DebugGizmoLine;
    public Color DebugWireBoxColor;

    GameObject Player;
    Collider PlayerCollider;
    Collider gameobject;
    Vector3 startPosition;
    Vector3 size = Vector3.zero;
    bool isMovingDown = false;

    float gravityModifier = 1.5f;

    private void Start()
    {
        // find the player automatically
        Player = GameObject.FindGameObjectWithTag("Player");

        // get the collision of the player
        PlayerCollider = Player.GetComponent<Collider>();

        // get the start position and size of the MovingObject
        startPosition = MovingObject.transform.position;
        size = MovingObject.gameObject.transform.localScale;

        float positiveSpeed = Mathf.Abs(MovingSpeed * DropMultiplier);
        gravityModifier = (1 / positiveSpeed) + 1.0f;
        gravityModifier = Mathf.Clamp(gravityModifier, 1.0f, 2.0f);
        Particles.gravityModifier = gravityModifier;
    }

    private void OnDrawGizmos()
    {
        // ------ Drawing path line ------
        Debug.DrawLine(MovingObject.gameObject.transform.position, TargetPosition, DebugGizmoLine);
        // -------------------------------

        // ------ Changing all Gizmos color and size from here and down ------
        // Changing Gizmo color
        Gizmos.color = DebugWireBoxColor;
        // -------------------------------

        // ------ Drawing object start position ------
        // Set the Gizmo position = to the TargetPosition & set the rotation of the Gizmo = to the rotation of the MovingObject rotation 
        Gizmos.matrix = Matrix4x4.TRS(startPosition, Quaternion.Euler(MovingObject.transform.rotation.eulerAngles), Vector3.one);
        // Drawing the Qizmo in a wire box style with the correct size and matrix.
        Gizmos.DrawWireCube(Vector3.zero, size);
        // -------------------------------

        // ------ Drawing object end position ------
        // Set the Gizmo position = to the TargetPosition & set the rotation of the Gizmo = to the rotation of the MovingObject rotation 
        Gizmos.matrix = Matrix4x4.TRS(TargetPosition, Quaternion.Euler(MovingObject.transform.rotation.eulerAngles), Vector3.one);
        // Get the scale of the MovingObject
        Vector3 ObjectSize = MovingObject.gameObject.transform.localScale;
        // Drawing the Qizmo in a wire box style with the correct size and matrix.
        Gizmos.DrawWireCube(Vector3.zero, ObjectSize);
        // -------------------------------

    }

    private void OnTriggerStay(Collider collider)
    {
        foreach (GameObject extraTriggers in ExtraTriggerObjects)
        {
            if (collider == extraTriggers.GetComponent<Collider>())
            {
                // Moving MovingObject to TargetPosition
                MovingObject.transform.position = Vector3.MoveTowards(MovingObject.transform.position, TargetPosition, MovingSpeed * Time.deltaTime);
            }
        }

        if (collider == PlayerCollider)
        {
            // Moving MovingObject to TargetPosition
            MovingObject.transform.position = Vector3.MoveTowards(MovingObject.transform.position, TargetPosition, MovingSpeed * Time.deltaTime);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        foreach (GameObject extra in ExtraTriggerObjects)
        {
            if (collision.collider == extra.GetComponent<Collider>())
            {
                // Moving MovingObject to TargetPosition
                MovingObject.transform.position = Vector3.MoveTowards(MovingObject.transform.position, TargetPosition, MovingSpeed * Time.deltaTime);
            }
        }

        if (collision.collider == PlayerCollider)
        {
            // Moving MovingObject to TargetPosition
            MovingObject.transform.position = Vector3.MoveTowards(MovingObject.transform.position, TargetPosition, MovingSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        foreach (GameObject extra in ExtraTriggerObjects)
        {
            if (collider == extra.GetComponent<Collider>() && canDropDown)
            {
                isMovingDown = true;
            }
        }

        if (collider == PlayerCollider && canDropDown)
        {
            isMovingDown = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        foreach (GameObject extra in ExtraTriggerObjects)
        {
            if (collision.collider == extra.GetComponent<Collider>() && canDropDown)
            {
                isMovingDown = true;
            }
        }

        if (collision.collider == PlayerCollider && canDropDown)
        {
            isMovingDown = true;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        foreach (GameObject extra in ExtraTriggerObjects)
        {
            if (collider == extra.GetComponent<Collider>() && canDropDown)
            {

                isMovingDown = false;
            }
        }

        if (collider == gameobject && canDropDown)
        {
            isMovingDown = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        foreach (GameObject extra in ExtraTriggerObjects)
        {
            if (collision.collider == extra.GetComponent<Collider>() && canDropDown)
            {
                isMovingDown = false;
            }
        }

        if (collision.collider == gameobject && canDropDown)
        {
            isMovingDown = false;
        }
    }

    private void Update()
    {
        if (isMovingDown && canDropDown)
        {
            // Moving TargetPosition to MovingObject
            MovingObject.transform.position = Vector3.MoveTowards(MovingObject.transform.position, startPosition, DropMultiplier * MovingSpeed * Time.deltaTime);

            if (MovingObject.transform.position == startPosition)
            {
                isMovingDown = false;

                if (canEmmitParticles)
                {
                    Particles.Play();
                }
            }
        }
    }
}
