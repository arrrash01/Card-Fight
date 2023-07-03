using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

using UnityEngine;

public class uiManager : MonoBehaviour
{
    [SerializeField] private GameObject gameEndPanel;
    [SerializeField] private TextMeshProUGUI gameEndText;
    [SerializeField] private Button restartButton;
    public void ShowGameEndPanel()
    {
        gameEndPanel.SetActive(true);
        gameEndText.text = "Game Over";
        GameObject.FindWithTag("Canvas").GetComponent<Canvas>().sortingOrder  = 10;
    }

    private void Start()
    {
        restartButton.onClick.AddListener(RestartScene);
    }
    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
