using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBookshelf : Speech
{
    private GameManager1 gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager1>();
    }

    public override void SaySpeech()
    {
        gameManager.ReadBookshelf();

        interactText.SayText(speechLines[currentIndex]);
        currentIndex++;

        if (currentIndex >= speechLines.Length)
        {
            currentIndex = 0;
            interactText.EndText();
        }
    }
}
