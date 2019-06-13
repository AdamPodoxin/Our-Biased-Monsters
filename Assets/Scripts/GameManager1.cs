using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public bool readBookshelf;

    public GameObject misinformationSpeechBattle;

    public string interactingWith;

    public void ReadBookshelf()
    {
        readBookshelf = true;
        misinformationSpeechBattle.SetActive(true);
    }

    public void CheckEndText()
    {
        if (interactingWith == "Misinformation_Effect_Speech_Battle")
        {
            SceneManager.LoadScene("Misinformation_Effect_Battle", LoadSceneMode.Single);
        }
    }
}
