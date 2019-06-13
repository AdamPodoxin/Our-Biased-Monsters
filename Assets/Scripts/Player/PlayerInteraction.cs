using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private bool canInteract = true;

    private GameManager1 gameManager1;
    private PlayerMovement playerMovement;

    private GameObject interactingWith;

    private void Awake()
    {
        gameManager1 = FindObjectOfType<GameManager1>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && interactingWith != null)
        {
            if (interactingWith.CompareTag("Speech"))
            {
                if (interactingWith.GetComponent<SpeechBookshelf>() != null)
                {
                    interactingWith.GetComponent<SpeechBookshelf>().SaySpeech();
                    StartInteraction();
                }
                else
                {
                    interactingWith.GetComponent<Speech>().SaySpeech();
                    StartInteraction();
                }
            }
            else if (interactingWith.CompareTag("Speech_Misinformation"))
            {
                gameManager1.interactingWith = "Misinformation_Effect_Speech_Battle";
                interactingWith.GetComponent<Speech>().SaySpeech();
                StartInteraction();
            }
            else if (interactingWith.CompareTag("Speech_Crowbar"))
            {
                interactingWith.GetComponent<SpeechCrowbar>().SaySpeech();
                StartInteraction();
            }
            else if (interactingWith.CompareTag("Speech_Confirmation"))
            {
                FindObjectOfType<GameManager2>().interactingWith = "Confirmation_Bias_Speech_Battle";
                interactingWith.GetComponent<Speech>().SaySpeech();
                StartInteraction();
            }
            else if (interactingWith.CompareTag("Speech_Anchoring"))
            {
                FindObjectOfType<GameManager3>().interactingWith = "Anchoring_Bias_Speech_Battle";
                interactingWith.GetComponent<Speech>().SaySpeech();
                StartInteraction();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactingWith = collision.gameObject;

        if (collision.CompareTag("RoomDoor"))
        {
            collision.GetComponent<RoomDoor>().LoadNextRoom();
        }
        else if (collision.CompareTag("End"))
        {
            collision.GetComponent<End>().EndGame();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactingWith = null;
    }

    private void CanInteract()
    {
        canInteract = true;
    }

    public void StartInteraction()
    {
        if (canInteract)
        {
            playerMovement.canMove = false;
        }
    }

    public void StopInteraction()
    {
        playerMovement.canMove = true;

        canInteract = false;
        Invoke("CanInteract", 1);
    }
}
