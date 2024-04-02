using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{

    PlayerController playerController ;

    // Start is called before the first frame update
    void Awake()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Animal"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            
            
            playerController.score += 1;
            Debug.Log("Score: " + playerController.score);
        }
    }
}
