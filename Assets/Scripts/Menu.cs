using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string firstScene = "";

    public void Play()
    {
        SceneManager.LoadScene(firstScene, LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
        print("Quit");
    }

    public void ToggleFullscreen()
    {
        StartCoroutine(ToggleFullscreenCoroutine());
    }

    private IEnumerator ToggleFullscreenCoroutine()
    {
        int width = 1280;
        int height = 720;
        bool fullScreen = !Screen.fullScreen;

        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();

        Screen.SetResolution(width, height, fullScreen);
    }
}
