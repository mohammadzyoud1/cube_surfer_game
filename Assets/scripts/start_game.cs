using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start_game : MonoBehaviour
{
    public void load()
    {
        //   SceneManager.LoadScene("MainScene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void exit()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
      
    }
}
