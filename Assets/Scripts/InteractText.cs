using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractText : MonoBehaviour
{
    public GameObject container;

    public Text text;

    public float textSpeed = 0.225f;

    private string[] textArray;
    private int currentIndex = 0;

    private GameManager1 gameManager1;
    [SerializeField] private GameManager2 gameManager2;
    [SerializeField] private GameManager3 gameManager3;
    private PlayerInteraction playerInteraction;

    private void Start()
    {
        gameManager1 = FindObjectOfType<GameManager1>();
        playerInteraction = FindObjectOfType<PlayerInteraction>();
    }

    private IEnumerator EndTextCoroutine()
    {
        yield return new WaitForSeconds(textArray.Length * textSpeed + 1f);
        container.SetActive(false);
        playerInteraction.StopInteraction();

        if (gameManager1 != null) gameManager1.CheckEndText();
        else if (gameManager2 != null) gameManager2.CheckEndText();
        else if (gameManager3 != null) gameManager3.CheckEndText();
    }

    private void AddWord()
    {
        text.text += textArray[currentIndex] + " ";
        currentIndex++;

        if (currentIndex == textArray.Length)
        {
            CancelInvoke("AddWord");
        }
    }

    public void SayText(string textToSay)
    {
        CancelInvoke("AddWord");
        textArray = textToSay.Split(' ');

        container.SetActive(true);
        text.text = "";

        currentIndex = 0;
        InvokeRepeating("AddWord", 0, textSpeed);
    }

    public void EndText()
    {
        StartCoroutine(EndTextCoroutine());
    }
}
