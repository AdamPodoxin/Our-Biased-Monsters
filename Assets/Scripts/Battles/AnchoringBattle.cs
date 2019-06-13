using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnchoringBattle : MonoBehaviour
{
    public int playerHealth = 1;
    public int anchoringHealth = 1000;

    public Image playerHealthImage;
    public Image anchoringHealthImage;
    public Text countdownText;
    public GameObject question;

    public SpriteRenderer anchoringRenderer;
    public Sprite anchoringHurt;
    public Animator animator;
    public Animator playerAnimator;

    public AudioSource hitSource;
    public Animator fade;

    private float timeRemaining = 5;
    private bool countingDown = true;
    private bool isWinning;

    private InteractText interactText;

    private void Start()
    {
        interactText = FindObjectOfType<InteractText>();
    }

    private void Update()
    {
        if (countingDown) timeRemaining -= Time.deltaTime;
        countdownText.text = Mathf.CeilToInt(timeRemaining).ToString();

        if (timeRemaining <= 0)
        {
            WrongAnswer();
        }
    }

    public void RightAnswer()
    {
        if (!isWinning)
        {
            isWinning = true;

            anchoringHealth = 0;
            anchoringHealthImage.fillAmount = 0;

            countingDown = false;
            question.SetActive(false);

            anchoringRenderer.sprite = anchoringHurt;
            animator.Play("Hurt");
            hitSource.Play();

            StartCoroutine(WinSpeech());
        }
    }

    public void WrongAnswer()
    {
        playerHealth = 0;
        playerHealthImage.fillAmount = 0;
        playerAnimator.Play("Hurt");
        hitSource.Play();

        timeRemaining = Mathf.Infinity;
        countingDown = false;
        question.SetActive(false);

        StartCoroutine(LoseSpeech());
    }

    private IEnumerator WinSpeech()
    {
        interactText.SayText("You   .   .   .   defeated me.");
        yield return new WaitForSeconds(4);

        interactText.SayText("Just by <color=cyan>ACKNOWLEDGING</color> me.");
        yield return new WaitForSeconds(4);

        interactText.SayText("You were able to stop my effects.");
        yield return new WaitForSeconds(4);

        interactText.SayText("By <color=cyan>ACKNOWLEDGING</color> me.");
        yield return new WaitForSeconds(4);

        interactText.SayText("   .   .   .");
        yield return new WaitForSeconds(4);

        interactText.SayText("Is this how you defeated the <color=red>others</color>?");
        yield return new WaitForSeconds(4);

        interactText.SayText("You saw them for what they really are: just <color=red>automated</color> <color=red>processes</color>?");
        yield return new WaitForSeconds(4);

        interactText.SayText("And you took <color=cyan>control</color>?");
        yield return new WaitForSeconds(4);

        interactText.SayText("Fascinating   .   .   .");
        yield return new WaitForSeconds(4);

        interactText.SayText("You    are    <color=cyan>cognizant</color>.");
        yield return new WaitForSeconds(2);

        fade.Play("Fade");
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("Anchoring_Win", LoadSceneMode.Single);
    }

    private IEnumerator LoseSpeech()
    {
        interactText.SayText("Hmm.");
        yield return new WaitForSeconds(2);

        interactText.SayText("It seems that you are not that powerful or <color=cyan>cognizant</color>.");
        yield return new WaitForSeconds(4);

        interactText.SayText("Goodbye.");
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("Game_Over", LoadSceneMode.Single);
    }
}
