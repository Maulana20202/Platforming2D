using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour
{

    private static Saver _instance;

    public static Saver Instance {  get { return _instance; } }

    public int CoinValue = 999;

    public int HighScore;
    // Start is called before the first frame update
    void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(CoinValue >= HighScore)
        {
            HighScore = CoinValue;
        }
    }
}
