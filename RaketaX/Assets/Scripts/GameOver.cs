using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    
    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") == null)
        {
           // Time.timeScale = 0f;
            gameOverPanel.SetActive(true);
            Debug.Log("Udarena kometa!");
        }
    }

    public void Restart()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //Time.timeScale = 1f;
    }
}
