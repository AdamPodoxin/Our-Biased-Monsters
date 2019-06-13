using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{
    public string interactingWith = "";

    public void CheckEndText()
    {
        if (interactingWith == "Confirmation_Bias_Speech_Battle")
        {
            SceneManager.LoadScene("Confirmation_Bias_Battle", LoadSceneMode.Single);
        }
    }
}
