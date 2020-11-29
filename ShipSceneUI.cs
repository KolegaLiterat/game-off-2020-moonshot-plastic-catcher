using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ShipSceneUI : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    [SerializeField]
    GameObject Airlock;
    [SerializeField]
    GameObject PlayAgain;
    [SerializeField]
    GameObject Quit;
    [SerializeField]
    Text GameOverScore;
    [SerializeField]
    Text GameOver;
    [SerializeField]
    Image Background;

    // Start is called before the first frame update
    void Start()
    {
        if (Player.GetComponent<Player>().isPlayerAlive == true)
        {
            game_over_menu(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<Player>().isPlayerAlive == false)
        {
            
            game_over_menu(true);
        }
    }

    void game_over_menu(bool isMenuVisible)
    {
        GameOverScore.text = "" + Airlock.GetComponent<RecyclerAirlock>().Points;
        Background.enabled = isMenuVisible;
        GameOverScore.enabled = isMenuVisible;
        GameOver.enabled = isMenuVisible;
        PlayAgain.SetActive(isMenuVisible);
        Quit.SetActive(isMenuVisible);
    }

    public void restart_game()
    {
        SceneManager.LoadScene("ShipScene");
    }

    public void quit_game()
    {
        Application.Quit();
    }
}
