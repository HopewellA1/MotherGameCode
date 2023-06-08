using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpikeEat2 : MonoBehaviour
{


    public GameObject floorObject;
    public GameObject SpikePrefab;
    //private float timer = 0f;
    //private float spikeInterval = 10f; // Time interval in seconds to create a spike object

    public GameManager2 gameManager;
    public SnakeControllerLevelTwo SnakeController;
    void Start()
    {
        // timer = 0f;


       




    }

    // Update is called once per frame
    
    private void OnTriggerEnter(Collider other)
    {
        

        if(other.gameObject.name == "Snake")
        {
            gameManager.GameOver();
        }
        if (other.gameObject.name == "Sphere")
        {
            Destroy(other.gameObject);
            SnakeController.CreateAppleObject();
            Debug.Log("Done Here");
            SnakeController.numApples += 1;
        }
    }
    
    void Update()
    {
      
        

    }
    private Vector3 GetRandomPositionOnFloor()
    {
        Renderer floorRenderer = floorObject.GetComponent<Renderer>();
        Vector3 floorBounds = floorRenderer.bounds.size;

        // Calculate random position within the bounds of the floor
        float minX = floorObject.transform.position.x - floorBounds.x / 2f;
        float maxX = floorObject.transform.position.x + floorBounds.x / 2f;
        float minZ = floorObject.transform.position.z - floorBounds.z / 2f;
        float maxZ = floorObject.transform.position.z + floorBounds.z / 2f;

        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), -4.838f, Random.Range(minZ, maxZ));

        return randomPosition;
    }
    public void CreateSpikeObject()
    {
        GameObject Spike = Instantiate(SpikePrefab, GetRandomPositionOnFloor(), Quaternion.identity);
        Collider appleCollider = Spike.GetComponent<Collider>();
        appleCollider.isTrigger = true;
        Spike.gameObject.name = "Spike";
        Debug.Log(Spike.gameObject.name.ToString() + " Added");
    }
}
