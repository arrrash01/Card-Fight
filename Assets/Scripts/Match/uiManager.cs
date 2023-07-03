
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

using UnityEngine;

public class uiManager : MonoBehaviour
{
    [SerializeField] private GameObject gameEndPanel;
    [SerializeField] private TextMeshProUGUI gameEndText;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button QuitButton;
    public void ShowGameEndPanel()
    {
        gameEndPanel.SetActive(true);
        gameEndText.text = "Game Over";
        GameObject.FindWithTag("Canvas").GetComponent<Canvas>().sortingOrder  = 10;
    }

    private void Start()
    {
        restartButton.onClick.AddListener(RestartScene);
        QuitButton.onClick.AddListener(QuitGame);
    }
    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void QuitGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
}
