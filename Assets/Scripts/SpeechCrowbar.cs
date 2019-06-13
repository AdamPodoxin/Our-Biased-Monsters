using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechCrowbar : Speech
{
    public override void SaySpeech()
    {
        interactText.SayText(speechLines[currentIndex]);
        currentIndex++;

        if (currentIndex >= speechLines.Length)
        {
            currentIndex = 0;
            interactText.EndText();
            Destroy(gameObject);
        }
    }
}
