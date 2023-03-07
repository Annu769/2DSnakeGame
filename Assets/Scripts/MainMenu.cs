using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //[SerializeField] private Scene nextScene;
    [SerializeField] private GameObject activeAndDeactiveGameObject;
    public static bool gameIsPause;
   

    private void Awake()
    {
        activeAndDeactiveGameObject.SetActive(false);
    }

    private void Update()
    {
       if(Input.GetKey(KeyCode.Escape))
        {
            if(gameIsPause)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void GoToNextScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }

    public void ExitGame()
    {
        Debug.Log("Application quit");
        Application.Quit();
    }
    
    public void ActiveRulesPanel()
    {
        activeAndDeactiveGameObject.SetActive(true);
    }
    public void DisableRulePanel()
    {
        activeAndDeactiveGameObject.SetActive(false);
    }

    public void PauseGame()
    {
        activeAndDeactiveGameObject.SetActive(true);
        Time.timeScale = 0;
        gameIsPause = true;
    }
    public void ResumeGame()
    {
        activeAndDeactiveGameObject.SetActive(false);
        Time.timeScale = 1;
        gameIsPause = false;
    }


}
