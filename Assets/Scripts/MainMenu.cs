using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static string testMode = "";

    public void PlayGame(string testMode)
    {
        MainMenu.testMode = testMode;
        //GameObject.FindGameObjectWithTag("Music").GetComponent<MusicScript>().PlayMusic();
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
