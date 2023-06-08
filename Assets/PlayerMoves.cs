using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rg;
    [SerializeReference] float movementSpeed = 6f;

    public int Gap = 10;

    // References
    public GameObject BodyPrefab;

    // Lists
    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();


    void Start()
    {
        rg = GetComponent<Rigidbody>();
        movementSpeed = 15f;
        rg.useGravity = true;
        GrowSnake();
          



    }

    // Update is called once per frame
    void Update()
    {
        motherBasicMoves();
        transform.position += transform.forward * 1 * Time.deltaTime;
        //transform.position = transform.forward * movementSpeed;
        float rotataion = Input.GetAxis("Horizontal") * 180f * Time.deltaTime;
        transform.Rotate(0f, rotataion, 0f);
        //float rotataion2 = Input.GetAxis("Vertical") *0;
        //rg.velocity = new Vector3(rg.velocity.x, rg.velocity.y, movementSpeed);
        // Vector3 movement = new Vector3(rg.velocity.x, 0, 0);
        followParent();
       
    }

    void motherBasicMoves()
    {
        //rg.velocity = new Vector3(rg.velocity.x, rg.velocity.y, 5f);
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");



        //if (Input.GetKey("left"))
        //{
        //    rg.velocity = new Vector3(-30, rg.velocity.y, rg.velocity.z);
        //}
        //if (Input.GetKey("right"))
        //{
        //    rg.velocity = new Vector3(30,rg.velocity.y , rg.velocity.z);
        //}
        if (Input.GetKey("up") || Input.GetKey("space"))
        {
            rg.velocity = new Vector3(rg.velocity.x, rg.velocity.y, movementSpeed);
        }
        if (Input.GetKey("down"))
        {
            rg.velocity = new Vector3(rg.velocity.x, rg.velocity.y, -movementSpeed);
        }
        rg.velocity = new Vector3(horizontal * movementSpeed, 0, rg.velocity.z);
    }

    //follow parent

    private void followParent()
    {
        float steerDirection = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerDirection * movementSpeed * Time.deltaTime);

        // Store position history
        PositionsHistory.Insert(0, transform.position);

        // Move body parts
        int index = 0;
        foreach (var body in BodyParts)
        {
            Vector3 point = PositionsHistory[Mathf.Clamp(index * Gap, 0, PositionsHistory.Count - 1)];

            // Move body towards the point along the snakes path
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * movementSpeed * Time.deltaTime;

            // Rotate body towards the point along the snakes path
            body.transform.LookAt(point);

            index++;
        }
    }

    private void GrowSnake()
    {
        // Instantiate body instance and
        // add it to the list
        GameObject body = Instantiate(BodyPrefab);
        BodyParts.Add(body);
    }
}
