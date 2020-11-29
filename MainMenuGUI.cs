using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuGUI : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("ShipScene");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

}
