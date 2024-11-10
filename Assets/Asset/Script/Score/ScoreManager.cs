using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public int CoinValue;

    public int currentLevel;

    public TextMeshProUGUI coinText;

    public TextMeshProUGUI levelText;
    // Start is called before the first frame update
    void Start()
    {
        CoinValue = Saver.Instance.CoinValue;

        coinText.text = CoinValue.ToString();

        levelText.text = "Level " + currentLevel.ToString();

        ScoreEvent_Handler.ScorePlus += ScorePlus;
    }

    // Update is called once per frame
    void OnDestroy()
    {
        ScoreEvent_Handler.ScorePlus -= ScorePlus;
    }

    void ScorePlus()
    {
        CoinValue += 1;
        Saver.Instance.CoinValue = CoinValue;
        coinText.text = CoinValue.ToString();
    }
}
