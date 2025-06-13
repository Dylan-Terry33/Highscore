using UnityEngine;

public class GoalMovement : MonoBehaviour
{
    private float boundry = 3.0f;
    private float speed = 3;
    private SpawnManager spawnManagerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {  spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

    }

    // Update is called once per frame
    void Update()
    {

        if(spawnManagerScript.gameActive == true){
        if(transform.position.z > boundry){
                transform.position = new Vector3(transform.position.x, transform.position.y, boundry);
        }
        if(transform.position.z < -boundry){
                            transform.position = new Vector3(transform.position.x, transform.position.y, -boundry);

        }
         float horizontalInput = Input.GetAxis("Horizontal");

       transform.Translate(Vector3.forward * horizontalInput * speed * Time.deltaTime);
        }

    }
}

    
