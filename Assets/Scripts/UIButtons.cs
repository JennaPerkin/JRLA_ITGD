using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButtons : MonoBehaviour
{
    //Attach Script to Empty Game Object, Drag Empty Game Object onto "On Click"

    //For Start Button
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Landscape");
    }

    //For Quit Game Button
    public void QuitGame()
    {
        Debug.Log("QuitGame");
        Application.Quit();
    }
}
