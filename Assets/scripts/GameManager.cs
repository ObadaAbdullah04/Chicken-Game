using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject GameOvercanvas;
    [SerializeField] private GameObject Scorecanvas;
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Time.timeScale = 1f;
    }
    public void GameOver()
    {
        GameOvercanvas.SetActive(true);
        Scorecanvas.SetActive(false);
        Time.timeScale = 0f;
    }
    
}
