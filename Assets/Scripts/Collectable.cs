using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int pointValue;
    public int healthValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("AI"))
        {
            Debug.Log("gain points!");
            ScoreManager.GainPoints(pointValue);
            HealthManager.GainHealth(healthValue);
            Destroy(gameObject);
        }
    }
}
