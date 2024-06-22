using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    public CharacterDatabase characterDB;
    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;

    void Start()
    {
        // Check if characterDB is assigned
        if (characterDB == null)
        {
            UnityEngine.Debug.LogError("Character Database is not assigned in the inspector.");
            return;
        }

        if (artworkSprite == null)
        {
            UnityEngine.Debug.LogError("Artwork Sprite is not assigned in the inspector.");
            return;
        }

        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }

        UpdateCharacter(selectedOption);
    }

    public void NextOption()
    {
        selectedOption++;

        if (selectedOption >= characterDB.CharacterCount)
        {
            selectedOption = 0;
        }

        UpdateCharacter(selectedOption);
        Save();
    }

    public void BackOption()
    {
        selectedOption--;

        if (selectedOption < 0)
        {
            selectedOption = characterDB.CharacterCount - 1;
        }

        UpdateCharacter(selectedOption);
        Save();
    }

    private void UpdateCharacter(int selectedOption)
    {
        if (characterDB == null)
        {
            UnityEngine.Debug.LogError("Character Database is not assigned.");
            return;
        }

        Character character = characterDB.GetCharacter(selectedOption);
        if (character == null)
        {
            UnityEngine.Debug.LogError("Character not found in the database.");
            return;
        }

        if (artworkSprite == null)
        {
            UnityEngine.Debug.LogError("Artwork Sprite is not assigned.");
            return;
        }

        artworkSprite.sprite = character.characterSprite;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }

    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void QuitGame()
    {
        UnityEngine.Debug.Log("Quitting game...");
        UnityEngine.Application.Quit();
    }
}