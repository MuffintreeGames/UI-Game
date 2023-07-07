using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerJump : MonoBehaviour
{
    bool desirable = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDesirable(bool input)
    {
        desirable = input;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("AI"))
        {
            int randNum = Random.Range(0, 3);   //1-in-3 chance of making the wrong decision
            bool shouldJump;
            if (randNum == 2)
            {
                shouldJump = !desirable;
            } else
            {
                shouldJump = desirable;
            }
            if (shouldJump)
            {
                Debug.Log("jump!");
                collision.gameObject.GetComponent<AIController>().Jump();
            } else
            {
                Debug.Log("ignoring jump!");
            }
            Destroy(gameObject);
        }
    }
}
