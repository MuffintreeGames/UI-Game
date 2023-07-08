using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaging : MonoBehaviour
{
    bool wasHit = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -8 && !wasHit)
        {
            Debug.Log("dodged obstacles, gaining points!");
            ScoreManager.GainPoints(50);
            wasHit = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("AI"))
        {
            AIController ai = collision.gameObject.GetComponent<AIController>();
            if (!ai.CheckInvincibility())
            {
                ai.TakeDamage();
                wasHit = true;
            }
        }
    }
}
