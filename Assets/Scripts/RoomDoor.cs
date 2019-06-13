using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDoor : MonoBehaviour
{
    public GameObject myRoom;
    public GameObject nextRoom;

    public Vector2 newPlayerPosition;

    public Animator fade;

    private Transform player;
    private PlayerMovement playerMovement;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private IEnumerator LoadNextRoomCoroutine()
    {
        fade.Play("Fade");
        playerMovement.canMove = false;

        yield return new WaitForSeconds(1f);

        playerMovement.canMove = true;
        nextRoom.SetActive(true);
        player.position = newPlayerPosition;
        myRoom.SetActive(false);
    }

    public void LoadNextRoom()
    {
        StartCoroutine(LoadNextRoomCoroutine());
    }
}
