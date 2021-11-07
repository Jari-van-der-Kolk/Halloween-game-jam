using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] private bool isPaused;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject hasWonPanel;
    private bool hasWon;

    void Start()
    {
        isPaused = false;
        pausePanel.SetActive(isPaused);
    }

    void Update()
    {
       
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
        if (hasWonPanel.activeInHierarchy)
        {
            isPaused = false;
            Time.timeScale = 0f;     
        }
        pausePanel.SetActive(isPaused);
        if (isPaused == true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

    }

    public void SwitchPausedBool()
    {
        isPaused = !isPaused;
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}
