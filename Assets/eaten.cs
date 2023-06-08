using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eaten : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves the "apple" game object
        if (collision.gameObject.name == "Snake")
        {
            // Collision detected with the "apple" game object
            Debug.Log("Collision with apple! from apple.");

            // Add your desired code to handle the collision here, such as increasing score or destroying the apple object
        }
    }
}
