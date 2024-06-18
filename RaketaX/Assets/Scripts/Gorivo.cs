using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gorivo : MonoBehaviour
{
    private GameObject player;
    public float healthGain = 10; // Koliko zdravlja se dobija kada se pokupi gorivo
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Pokupi gorivo
            PokupiGorivo();
        }
    }
    void PokupiGorivo()
    {
         // Povećaj health metar igrača
        Raketa raketaScript = player.GetComponent<Raketa>();
        if (raketaScript != null)
        {
            raketaScript.PovecajZdravlje(healthGain);
        }

        // Obriši gorivo iz igre
        Destroy(gameObject);
    }
}
