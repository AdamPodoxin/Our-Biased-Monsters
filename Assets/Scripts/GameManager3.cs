using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager3 : MonoBehaviour
{
    public string interactingWith = "";

    public void CheckEndText()
    {
        if(interactingWith == "Anchoring_Bias_Speech_Battle")
        {
            SceneManager.LoadScene("Anchoring_Bias_Battle", LoadSceneMode.Single);
        }
    }
}
