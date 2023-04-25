using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public KeyCode pauseKeyCodePC;
    public KeyCode pauseKeyCodeArcade;
    public static bool pauseEnabled = false;
    public int menuSceneID;
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pauseKeyCodePC))
        {
            if (pauseEnabled)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
        if (Input.GetKeyDown(pauseKeyCodeArcade))
        {
            if (pauseEnabled)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    // !true = false
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        pauseEnabled = true;
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(!true);
        Time.timeScale = 1f;
        pauseEnabled = false;
    }
    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        pauseEnabled = false;
        SceneManager.LoadScene(menuSceneID);
    }
}
