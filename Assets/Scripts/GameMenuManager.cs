using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuManager : MonoBehaviour
{
    
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] Snake snakeController;

    [Header("Game Over Buttons")]
    [SerializeField] Button restart;
    [SerializeField] Button Menu;
    [SerializeField] Button Back;

    static bool IsGamePaused = false;
    // Start is called before the first frame update
    void AWake()
    {
        restart.onClick.AddListener(Restart);
        Menu.onClick.AddListener(Mainmenu);
        Back.onClick.AddListener(ClosePauseMenu);

        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsGamePaused)
            {
                ClosePauseMenu();
            }
            else
            {
                PauseMenu();
            }
        }
    }

    public void GameOver()
    {
        snakeController.gameOver = true;
        gameOverMenu.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene(0);
    }
    public void PauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsGamePaused = true;
    }
    public void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
    }
}
