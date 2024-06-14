using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raketa : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerDirection;
    public MeterScript healthMeter;
    public float currentHealth;
    public float maxHealth = 80;
    public float healthDecreaseRate = 10;
    
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
         // Smanjite health tokom vremena
        currentHealth -= healthDecreaseRate * Time.deltaTime;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ograničite vrednost između 0 i maxHealth

        // Ažurirajte vrednost slajdera
        //if (healthSlider != null)
        //{
           // healthSlider.value = currentHealth;
       // }

        // Provera da li je health pao na 0
        if (currentHealth <= 0)
        {
            // Ovde možete dodati logiku koja se dešava kada health padne na 0
            Debug.Log("Health je 0!");
        }
         healthMeter.SetHealth(currentHealth);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0, playerDirection.y * playerSpeed);
        
    }
}
