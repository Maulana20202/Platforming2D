using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUI_GameOverHandler : MonoBehaviour
{

    public GameObject GameOverObject;

    public TextMeshProUGUI ScoreText;

    public TextMeshProUGUI HighScore;

    // Start is called before the first frame update
    void Start()
    {
        GUI_GameOverEvent.OnGameOver += GameOverUpdate;
    }

    private void OnDestroy()
    {
        GUI_GameOverEvent.OnGameOver -= GameOverUpdate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameOverUpdate()
    {
        GameOverObject.SetActive(true);

        ScoreText.text = " Score : " + Saver.Instance.CoinValue;

        HighScore.text = " HighScore : " + Saver.Instance.HighScore;

        Saver.Instance.CoinValue = 0;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Level_" + 1);
    }
}
