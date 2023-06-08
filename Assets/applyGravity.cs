using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class applyGravity : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody rg;
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
