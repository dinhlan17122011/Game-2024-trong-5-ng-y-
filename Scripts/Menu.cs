using UnityEngine.SceneManagement;
using UnityEngine;
public class Menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    // Update is called once per frame
    public void Quit()
    {
        Application.Quit();
    }
}
