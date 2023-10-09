using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1) ;
    }

    public void QuiteGame()
    {
        Application.Quit();
        Debug.Log("This Awesome Game has been Quit to Oblivion!");
    }
}
