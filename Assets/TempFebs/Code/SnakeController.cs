using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;



public class SnakeController : MonoBehaviour {

    // Settings
    public float MoveSpeed = 5;
    public float SteerSpeed = 180;
    public float BodySpeed = 5;
    public int Gap = 10;
    float speedHold;
    public GameObject applePrefab;
    public GameObject floorObject;
    public int numApples = 0;
    private Renderer floorRenderer;
    public ControlDanger ControlDanger;
    public GameManager1 gameManager;
    public SpikeEat spikeEat;
    public Text deciderText;
    public Text ScoreText;
    private int Level;


    // References
    public GameObject BodyPrefab;

    // Lists
    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();

    // Start is called before the first frame update
    void Start() {
        

        speedHold = MoveSpeed;
        GrowSnake2();
        GrowSnake2();
        GrowSnake2();
        GrowSnake2();
        GrowSnake2();
        GrowSnake2();
        GrowSnake2();
        GrowSnake2();
        GrowSnake2();
        GrowSnake2();




        Level = SceneManager.GetActiveScene().buildIndex;
        CreateAppleObject();

        floorRenderer = floorObject.GetComponent<Renderer>();
        

    }

    // Update is called once per frame
    void Update() {
        preventSnakeOutBound();
        if (Input.GetKey("up"))
        {
            MoveSpeed += 1;
            BodySpeed += 1; 

        }
        if ( Input.GetKey("space"))
        {
            MoveSpeed = 1;
            BodySpeed = 1;

        }
        if (Input.GetKey("down"))
        {
            if(MoveSpeed> speedHold)
            {
                MoveSpeed -= 1;
                BodySpeed -= 1;
            }
            
        }

        // Move forward
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        // Steer
        float steerDirection = Input.GetAxis("Horizontal"); // Returns value -1, 0, or 1
        transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);

        // Store position history
        PositionsHistory.Insert(0, transform.position);

        // Move body parts
        int index = 0;
        foreach (var body in BodyParts) {
            Vector3 point = PositionsHistory[Mathf.Clamp(index * Gap, 0, PositionsHistory.Count - 1)];

            // Move body towards the point along the snakes path
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * BodySpeed * Time.deltaTime;

            // Rotate body towards the point along the snakes path
            body.transform.LookAt(point);

            index++;
        }
    
        ScoreText.text = "Score: " +numApples.ToString();
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log(collision.gameObject.name);
    //    // Check if the collision involves the "apple" game object
    //    if (collision.gameObject.name == "Spike")
    //    {
    //        // Collision detected with the "apple" game object
    //        Debug.Log("Collision with Spike!");

    //        // Add your desired code to handle the collision here, such as increasing score or destroying the apple object
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.name == "Sphere")
        {
      
            numApples += 1;
            if (Level == 3)
            {
                PlayerPrefs.SetInt("LevelTowScore", numApples);
                PlayerPrefs.Save();
            }

            other.gameObject.name = "NoCount";
           
            Destroy(other.gameObject);

            GrowSnake();
            CreateAppleObject();

        }
        //if (other.gameObject.name == "body")
        //{
        //    Debug.Log("body");
        //    // Trigger game over
        //    gameManager.GameOver();
        //}
        if (other.gameObject.name == "Spike")
        {
            Debug.Log("Spiked!");
            // Trigger game over
            gameManager.GameOver();
            
        }
        if (other.gameObject.name == "DangerSnake" || other.gameObject.name == "DangerBody")
        {
            gameManager.GameOver();
        }
      


    }
    private void GrowSnake() {
        // Instantiate body instance and
        // add it to the list
        GameObject body = Instantiate(BodyPrefab);
        body.name= "body";
        BodyParts.Add(body);
 
        Debug.Log("Done!");
    }
    private void GrowSnake2()
    {
        // Instantiate body instance and
        // add it to the list
        GameObject body = Instantiate(BodyPrefab);
        body.name = "body1";
        BodyParts.Add(body);
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
    public void CreateAppleObject()
    {
        GameObject apple = Instantiate(applePrefab, GetRandomPositionOnFloor(), Quaternion.identity);
        Collider appleCollider = apple.GetComponent<Collider>();
        appleCollider.isTrigger = true;
        apple.gameObject.name = "Sphere";
        spikeEat.CreateSpikeObject();
        spikeEat.CreateSpikeObject();
        spikeEat.CreateSpikeObject();
    }
    //private int CountSpheresOnFloor()
    //{
    //    int sphereCount = 0;
    //    Collider[] colliders = Physics.OverlapBox(floorObject.transform.position, floorObject.transform.localScale / 2f);

    //    foreach (Collider collider in colliders)
    //    {
    //        if (collider.gameObject.name == "Sphere")
    //        {
    //            sphereCount++;
    //        }
    //    }

    //    return sphereCount;
    //}
    
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