using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConfirmationBattle : MonoBehaviour
{
    public int playerHealth = 5;
    public int confirmationHealth = 5;

    public Image playerHealthImage;
    public Image confirmationHealthImage;
    public Text countdownText;
    public Animator animator;
    public Animator playerAnimator;

    public AudioSource sfxSource;
    public AudioClip hitClip;

    public Question[] questions;

    private int currentIndex = 0;
    private int previousIndex = 0;

    private float timeRemaining = 20;

    private void Start()
    {
        previousIndex = Random.Range(0, questions.Length);
        StartCoroutine(ShowAnswers());

        PickQuestion();
    }

    private void Update()
    {
        timeRemaining -= Time.deltaTime;
        countdownText.text = Mathf.CeilToInt(timeRemaining).ToString();

        if (timeRemaining <= 0)
        {
            WrongAnswer();
            timeRemaining = 20;
        }
    }

    private IEnumerator ShowAnswers()
    {
        questions[currentIndex].ShowAnswer(Random.Range(0, 6));
        yield return new WaitForSeconds(1.2f);
        StartCoroutine(ShowAnswers());
    }

    private void CheckHealth()
    {
        playerHealthImage.fillAmount = playerHealth / 5.0f;
        confirmationHealthImage.fillAmount = confirmationHealth / 5.0f;

        if (confirmationHealth <= 0)
        {
            SceneManager.LoadScene("Basement_Win", LoadSceneMode.Single);
            return;
        }
        else if (playerHealth <= 0)
        {
            SceneManager.LoadScene("Game_Over", LoadSceneMode.Single);
            return;
        }
    }

    private void PickQuestion()
    {
        questions[currentIndex].HideAllAnswers();
        questions[currentIndex].HideQuestion();
        timeRemaining = 20;

        while (currentIndex == previousIndex)
        {
            currentIndex = Random.Range(0, questions.Length);
        }

        previousIndex = currentIndex;
        questions[currentIndex].ShowQuestion();
    }

    public void RightAnswer()
    {
        confirmationHealth--;
        animator.Play("Hurt");
        sfxSource.PlayOneShot(hitClip);
        CheckHealth();
        PickQuestion();
    }

    public void WrongAnswer()
    {
        playerHealth--;
        playerAnimator.Play("Hurt");
        sfxSource.PlayOneShot(hitClip);
        CheckHealth();
        PickQuestion();
    }
}

[System.Serializable]
public class Question
{
    public GameObject questionContainer;
    public GameObject[] answers;

    private int previousIndex;

    public void ShowQuestion()
    {
        questionContainer.SetActive(true);
    }

    public void HideQuestion()
    {
        questionContainer.SetActive(false);
    }

    public void ShowAnswer(int index)
    {
        answers[previousIndex].SetActive(false);
        answers[index].SetActive(true);

        previousIndex = index;
    }

    public void HideAllAnswers()
    {
        foreach (GameObject answer in answers)
        {
            answer.SetActive(false);
        }
    }
}
