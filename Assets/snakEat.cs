using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class snakEat : MonoBehaviour
{
    public GameObject applePrefab;
    private void CreateAppleObject()
    {
        // Get the bounds of the floor object
        Renderer floorRenderer = GetComponent<Renderer>();
        Vector3 floorBounds = floorRenderer.bounds.size;

        // Calculate random position within the bounds of the floor
        float minX = transform.position.x - floorBounds.x / 2f;
        float maxX = transform.position.x + floorBounds.x / 2f;
        float minZ = transform.position.z - floorBounds.z / 2f;
        float maxZ = transform.position.z + floorBounds.z / 2f;

        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), -4.838f, Random.Range(minZ, maxZ));

        // Instantiate the apple object at the random position
        GameObject apple = Instantiate(applePrefab, randomPosition, Quaternion.identity);
        Collider appleCollider = apple.GetComponent<Collider>();
        appleCollider.isTrigger = true;
        apple.gameObject.name = "Sphere";
    }
}
