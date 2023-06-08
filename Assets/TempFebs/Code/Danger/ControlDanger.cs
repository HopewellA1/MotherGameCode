using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControlDanger : MonoBehaviour
{
    // Settings
    public float MoveSpeed = 7;
    public float SteerSpeed = 90;
    public float BodySpeed = 5;
    public int Gap = 10;
    float speedHold;
    private float timer = 0f;
    private float Dangertimer = 0f;
    private float driveInterval = 5f;
    private float DangerInterval = 7f;
    private Renderer floorRenderer;
    // References
    public GameObject BodyPrefab;
    public GameObject floorObject;
    private float numInerval = 0;

    // Lists
    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        speedHold = MoveSpeed;
        DanderGrowSnake();
        DanderGrowSnake();
        DanderGrowSnake();
        DanderGrowSnake();
        DanderGrowSnake();
        DanderGrowSnake();
        DanderGrowSnake();
        DanderGrowSnake();
        DanderGrowSnake();
        DanderGrowSnake();
        floorRenderer = floorObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

        // Move forward
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        gameObject.name = "DangerSnake";
        // Steer

        //float steerDirection = Input.GetAxis("Horizontal"); // Returns value -1, 0, or 1
        // Increment the timer
        timer += Time.deltaTime;
        Dangertimer += Time.deltaTime;
        Debug.Log("The Timer: " + timer);
        // Check if the specified interval has passed
        float steerDirection =  Random.Range(-1, 1);
        if (timer >= driveInterval)
        {
            // Returns value -1, 0, or 1numInerval
            numInerval++;
            Debug.Log("Direction: " + timer.ToString());
            
            Debug.Log("Direction: " + steerDirection.ToString());
            timer = 0;
        }
        if (Dangertimer >= DangerInterval)
        {
            // Returns value -1, 0, or 1numInerval
            DanderGrowSnake();
            DanderGrowSnake();
            DanderGrowSnake();
            Dangertimer = 0;
        }
        if (numInerval == 1)
        {
            transform.Rotate(Vector3.up * -1f * SteerSpeed * Time.deltaTime);
        }
        if (numInerval == 2)
        {
            transform.Rotate(Vector3.up * 0f * SteerSpeed * Time.deltaTime);
        }
        if (numInerval == 3)
        {
            transform.Rotate(Vector3.up * 1f * SteerSpeed * Time.deltaTime);
            numInerval = 0;
        }

        Debug.Log("Interval: " + numInerval.ToString());

        // transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);

        // Store position history
        PositionsHistory.Insert(0, transform.position);

        // Move body parts
        int index = 0;
        foreach (var body in BodyParts)
        {
            Vector3 point = PositionsHistory[Mathf.Clamp(index * Gap, 0, PositionsHistory.Count - 1)];

            // Move body towards the point along the snakes path
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * BodySpeed * Time.deltaTime;

            // Rotate body towards the point along the snakes path
            body.transform.LookAt(point);

            index++;
        }
        preventSnakeOutBound();
    }

    public void DanderGrowSnake()
    {
        // Instantiate body instance and
        // add it to the list
        GameObject body = Instantiate(BodyPrefab);
        BodyParts.Add(body);
        body.gameObject.name = "DangerBody";
    }
    private void preventSnakeOutBound()
    {
        // Get the current position of the snake
        Vector3 currentPosition = transform.position;

        // Calculate the bounds of the floor object
        Vector3 floorBounds = floorRenderer.bounds.size;
        float minX = floorObject.transform.position.x - floorBounds.x / 2f;
        float maxX = floorObject.transform.position.x + floorBounds.x / 2f;
        float minZ = floorObject.transform.position.z - floorBounds.z / 2f;
        float maxZ = floorObject.transform.position.z + floorBounds.z / 2f;

        // Restrict the snake's position within the floor bounds
        float clampedX = Mathf.Clamp(currentPosition.x, minX, maxX);
        float clampedZ = Mathf.Clamp(currentPosition.z, minZ, maxZ);

        // Update the snake's position within the restricted bounds
        transform.position = new Vector3(clampedX, currentPosition.y, clampedZ);
    }

}
