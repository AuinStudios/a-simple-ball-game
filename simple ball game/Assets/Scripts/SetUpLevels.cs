using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables
{
    public GameObject platform;
    [Range(0, 100)]
    public int rowOfPlatforms = 10;
    [Tooltip("x = forward or backwards, y = up or down, z = left or right")]
    public Vector3 spawnOffset;

    public Variables(GameObject platform, int rowOfPlatforms/*, Vector3 startingPosition*/, Vector3 spawnOffset)
    {
        this.platform = platform;
        this.rowOfPlatforms = rowOfPlatforms;
        //this.startingPosition = startingPosition;
        this.spawnOffset = spawnOffset;
    }
}

public class SetUpLevels : MonoBehaviour
{
    [Tooltip("The position to place the first gameobject")]
    public Vector3 startingPosition;

    [SerializeField]
    public Variables[] Levels;
    
    protected List<GameObject> allPlatforms = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnAllPlatforms();

        for (int i = 0; i < allPlatforms.Count; i++)
        {
            if (i % 2 == 0)
            {
                for (int j = 0; j < Levels[i].rowOfPlatforms; j++)
                {
                    Vector3 directions = new Vector3(1, 1, 1);
                    MovePlatform(directions, i);
                }
            }
            else
            {
                for (int j = 0; j < Levels[i].rowOfPlatforms; j++)
                {
                    Vector3 directions = new Vector3(1, 1, -1);
                    MovePlatform(directions, i);
                }
            }
        }
    }

    void SpawnAllPlatforms()
    {
        for (int i = 0; i < Levels[i].rowOfPlatforms; i++)
        {
            allPlatforms.Add(Instantiate(Levels[i].platform, startingPosition, Quaternion.identity));
        }
    }

    void MovePlatform(Vector3 directions, int i)
    {
        if (i == 0)
        {
            allPlatforms[0].transform.position = new Vector3(startingPosition.x, startingPosition.y, startingPosition.z);
        }
        else
        {
            Vector3 previousPlatformPosition = allPlatforms[i - 1].transform.position;
            allPlatforms[i].transform.position = new Vector3(previousPlatformPosition.x + (Levels[i].spawnOffset.x * directions.x),
                                                             previousPlatformPosition.y + (Levels[i].spawnOffset.y * directions.y),
                                                             previousPlatformPosition.z + (Levels[i].spawnOffset.z * directions.z));
        }
    }
}
