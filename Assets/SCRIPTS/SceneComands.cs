using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneComands : MonoBehaviour
{
    public string Numescene;
    public Canvas canvasSetari;


    public void loadnextsceneIndex()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void loadsceneNumescena()
    {
        SceneManager.LoadScene(Numescene);
        Debug.Log("Load " + Numescene);

    }
    public void quidGame()
    {

        Application.Quit();
    }
public void settingsButton()
    {
        canvasSetari.enabled = true;
    }
}
