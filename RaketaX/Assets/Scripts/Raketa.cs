using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raketa : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;
    public MeterScript healthMeter;
    public int currentHealth;
    public int maxHealth = 80;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth; 
        healthMeter.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        playerDirection = new Vector2(0, directionY).normalized;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, playerDirection.y * playerSpeed);
        healthMeter.SetHealth(currentHealth); 
    }
}
