using NUnit.Framework.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("intro");
    }

    public void Tomainmenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restartlevel1()
    {
        SceneManager.LoadScene("level-1");
    }

        public void Restartlevel2()
    {
        SceneManager.LoadScene("level-2");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
