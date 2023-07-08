using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class AIController : MonoBehaviour
{
    bool jumping = false;
    public Rigidbody2D rb;
    public CircleCollider2D collider;
    public SpriteRenderer render;
    public float jumpForce = 10f;
    public float invincibilityTime = 1f;
    bool invincible = false;
    float remainingInvincibility = 0f;
    float invincibleAlpha = .5f;
    // Start is called before the first frame update
    void Start()
    {
        jumping = false;
        invincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (invincible) { 
            remainingInvincibility -= TimeController.AdjustedDeltaTime();
            if (remainingInvincibility <= 0f) {
                invincible = false;
                render.color = new Color(render.color.r, render.color.g, render.color.b);
            }
        }
    }

    public void TakeDamage()
    {
        Debug.Log("ai got hurt!");
        invincible = true;
        remainingInvincibility = invincibilityTime;
        render.color = new Color(render.color.r, render.color.g, render.color.b, invincibleAlpha);
        HealthManager.TakeDamage();
    }

    public void Jump()
    {
        if (!jumping)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumping = true;
        }
    }

    public bool CheckInvincibility()
    {
        return invincible;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Debug.Log("hit ground!");
            jumping = false;
        }
    }
}
