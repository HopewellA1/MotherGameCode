using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBehave : MonoBehaviour
{
    public GameObject floorObject;
    public GameObject SpikePrefab;
    private float timer = 0f;
    private float spikeInterval = 10f; // Time interval in seconds to create a spike object

    void Start()
    {
        // Start the timer
        timer = 0f;
        for(int i= 0; i <= 4; i++)
        {
            CreateSpikeObject();
        }
    }

    // Update is called once per frame
    private int interval = 0;
    void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Check if the specified interval has passed
        if (timer >= spikeInterval)
        {
            // Call the method to create the spike object
           
            interval++;
            for(int i = interval; i<= interval; i++)
            {
                CreateSpikeObject();
            }
            // Reset the timer
            timer = 0f;
        }

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
    private void CreateSpikeObject()
    {
        GameObject Spike = Instantiate(SpikePrefab, GetRandomPositionOnFloor(), Quaternion.identity);
        Collider appleCollider = Spike.GetComponent<Collider>();
        appleCollider.isTrigger = true;
        Spike.gameObject.name = "Spike";
        Debug.Log(Spike.gameObject.name.ToString()+" Added");
    }
}
