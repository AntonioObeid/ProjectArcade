using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private static bool _gamePaused;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (_gamePaused)
            {
                Resume();
            }else
            {
                Pause();
            }
    }

    private void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        _gamePaused = true;
        //Timescale ranges from 0 (time freezes) to 1 (Time would pass like in realTime)
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        _gamePaused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        _gamePaused = false;
        print ("Restarting the Level");
    }

    public void Menu(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
        Debug.Log("LoadingMenu");
    }
}


