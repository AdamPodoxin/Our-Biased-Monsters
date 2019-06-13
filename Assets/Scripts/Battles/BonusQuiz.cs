using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BonusQuiz : MonoBehaviour
{
    public int playerHealth = 10;
    public int quizHealth = 10;

    public Image playerHealthImage;
    public Image quizHealthImage;
    public Text questionsRemainingText;
    public Text timeRemainingText;
    public Animator animator;
    public Animator playerAnimator;

    public AudioSource hitSource;

    public List<GameObject> availableQuestions = new List<GameObject>();

    [SerializeField] private int currentIndex = 0;

    private float timeRemaining = 90f;

    private void Update()
    {
        timeRemaining -= Time.deltaTime;
        timeRemainingText.text = Mathf.CeilToInt(timeRemaining).ToString();

        if (timeRemaining <= 0)
        {
            WrongAnswer();
            timeRemaining = 90f;
        }
    }

    private void PickQuestion()
    {
        if (currentIndex < availableQuestions.Count) availableQuestions[currentIndex].SetActive(false);

        if (availableQuestions.Count <= 0)
        {
            if (quizHealth > playerHealth)
            {
                SceneManager.LoadScene("Lose_Bonus_Quiz", LoadSceneMode.Single);
            }
            else
            {
                SceneManager.LoadScene("Menu", LoadSceneMode.Single);
            }
        }

        if (currentIndex >= availableQuestions.Count)
        {
            currentIndex = 0;
        }

        availableQuestions[currentIndex].SetActive(true);
        questionsRemainingText.text = "Questions Remaining: " + availableQuestions.Count;

        timeRemaining = 90f;
    }

    public void RightAnswer()
    {
        quizHealth--;
        quizHealthImage.fillAmount = quizHealth / 10.0f;
        animator.Play("Hurt");
        hitSource.Play();

        if (quizHealth <= 0)
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
            return;
        }

        availableQuestions[currentIndex].SetActive(false);
        availableQuestions.RemoveAt(currentIndex);

        PickQuestion();
    }

    public void WrongAnswer()
    {
        playerHealth--;
        playerHealthImage.fillAmount = playerHealth / 10.0f;
        playerAnimator.Play("Hurt");
        hitSource.Play();

        if (playerHealth <= 0)
        {
            SceneManager.LoadScene("Lose_Bonus_Quiz", LoadSceneMode.Single);
            return;
        }

        availableQuestions[currentIndex].SetActive(false);
        currentIndex++;
        PickQuestion();
    }
}
