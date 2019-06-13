using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void BonusQuiz()
    {
        SceneManager.LoadScene("Bonus_Quiz", LoadSceneMode.Single);
    }
}
