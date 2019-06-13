using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speech : MonoBehaviour
{
    public string[] speechLines;

    public int currentIndex = 0;

    public InteractText interactText;

    public void Start()
    {
        interactText = FindObjectOfType<InteractText>();
    }

    public virtual void SaySpeech()
    {
        interactText.SayText(speechLines[currentIndex]);
        currentIndex++;

        if (currentIndex >= speechLines.Length)
        {
            currentIndex = 0;
            interactText.EndText();
        }
    }
}
