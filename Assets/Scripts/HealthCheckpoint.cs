using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCheckpoint : MonoBehaviour
{
    float personalTimer = 5f;
    public int targetHealth = 0;
    // Start is called before the first frame update
    void Start()
    {
        personalTimer = HealthManager.timeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthManager.currentHealth == targetHealth)
        {
            Debug.Log("health checkpoint reached! Adding " + personalTimer + " time!");
            HealthManager.AddTime(personalTimer);
            Destroy(gameObject);
        }
        personalTimer -= Time.deltaTime;
        if (personalTimer <= 0f)
        {
            Destroy(gameObject);
        }
    }


}
