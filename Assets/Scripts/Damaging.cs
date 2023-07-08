using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaging : MonoBehaviour
{
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
            AIController ai = collision.gameObject.GetComponent<AIController>();
            if (!ai.CheckInvincibility())
            {
                ai.TakeDamage();
                //PianoController.QueueHitSfx();
                //Debug.Log("get hurt!");
            }
        }
    }
}
