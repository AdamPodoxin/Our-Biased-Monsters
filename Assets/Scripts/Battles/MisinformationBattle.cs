using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MisinformationBattle : MonoBehaviour
{
    public int playerHealth = 5;
    public int misinformationHealth = 5;

    public Image playerHealthImage;
    public Image misinformationHealthImage;
    public Text countdownText;
    public Animator animator;
    public Animator playerAnimator;

    public AudioSource sfxSource;
    public AudioClip hitClip;

    public List<GameObject> questions = new List<GameObject>();

    private int currentIndex = 0;
    private int previousIndex;

    private bool rightAnswer = false;

    private float timeRemaining = 10;

    private void Start()
    {
        previousIndex = Random.Range(0, questions.Count);
        PickQuestion();
    }

    private void Update()
    {
        timeRemaining -= Time.deltaTime;
        countdownText.text = Mathf.CeilToInt(timeRemaining).ToString();

        if (timeRemaining <= 0)
        {
            WrongAnswer();
            timeRemaining = 10;
        }
    }

    private void CheckHealth()
    {
        playerHealthImage.fillAmount = playerHealth / 5.0f;
        misinformationHealthImage.fillAmount = misinformationHealth / 5.0f;

        if (misinformationHealth <= 0)
        {
            SceneManager.LoadScene("Village_01_Win", LoadSceneMode.Single);
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
        if (questions.Count > 0)
        {
            questions[currentIndex].SetActive(false);
            if (rightAnswer) questions.RemoveAt(currentIndex);

            timeRemaining = 10;

            if (!rightAnswer || currentIndex >= questions.Count) currentIndex = Random.Range(0, questions.Count);
            if (currentIndex == previousIndex) currentIndex = Random.Range(0, questions.Count);

            questions[currentIndex].SetActive(true);
        }
    }

    public void RightAnswer()
    {
        rightAnswer = true;

        misinformationHealth--;

        animator.Play("Hurt");
        sfxSource.PlayOneShot(hitClip);

        CheckHealth();
        PickQuestion();
    }

    public void WrongAnswer()
    {
        rightAnswer = false;

        playerHealth--;

        playerAnimator.Play("Hurt");
        sfxSource.PlayOneShot(hitClip);

        CheckHealth();
        PickQuestion();
    }
}
