using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMage : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private GameObject gameOverUi;
    [SerializeField] private GameObject gameWinUi;
    private bool isGameWin=false;
    private bool isGameOver = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateSrore();
        gameOverUi.SetActive(false);
        gameWinUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore(int points)
    {
        if (!isGameOver && !isGameWin)
        {
            score += points;
            UpdateSrore();
        }
    }
    private void UpdateSrore()
    {
        textMeshPro.text = score.ToString();
    }
    public void GameOver()
    {
        isGameOver= true;
        score = 0;
        Time.timeScale = 0;
        gameOverUi.SetActive(true);
    }
    public void GameWin()
    {
        isGameWin= true;
        Time.timeScale = 0;
        gameWinUi.SetActive(true);
    }
    public void ResetGame()
    {
        isGameOver = false;
        score = 0;
        UpdateSrore();
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    } 
    public void GotoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public bool IsGameOver()
    {
        return isGameOver;
    }
    public bool IsGameWin()
    {
        return isGameWin;
    }
}
