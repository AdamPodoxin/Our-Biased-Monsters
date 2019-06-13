using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public Animator fade;

    private IEnumerator EndGameCoroutine()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("Bonus_Quiz", LoadSceneMode.Single);
    }

    public void EndGame()
    {
        FindObjectOfType<PlayerMovement>().canMove = false;
        fade.Play("Fade");
        StartCoroutine(EndGameCoroutine());
    }
}
