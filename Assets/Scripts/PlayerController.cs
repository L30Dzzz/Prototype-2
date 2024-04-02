using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public float xRange = 10;
    public float yRange = 10;
    public float zRange = 16;
    public int score = 0;
    public GameObject projectilePrefab; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() 
    {
       //keeps player inbounds
        if (transform.position.x < -xRange)
        {
           transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z); 
        }

        if (transform.position.z < 0)
        {
           transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange); 
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Launch a projectile from the player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }

        //horizontal movement
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        //vertical movement
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
    
    }
        
        private void OnTriggerEnter(Collider other)
    {
        // if player collides with animal, death
        if (other.gameObject.CompareTag("Animal"))
        {
            Destroy(other.gameObject);
        }
    }

}
