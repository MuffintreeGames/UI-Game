using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float obstacleSpeed = 5f;

    private float despawnX = -20f;  //x coordinates where we destroy obstacle
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(obstacleSpeed * TimeController.AdjustedDeltaTime(), 0f, 0f);
        if (transform.position.x <= despawnX)
        {
            Destroy(gameObject);
        }
    }
}
