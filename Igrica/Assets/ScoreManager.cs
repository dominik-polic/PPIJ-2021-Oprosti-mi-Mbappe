using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    int score;
    public int totalCoins = 10;

    
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) instance = this;
        text.text = "0/" + totalCoins.ToString();
    }

    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        text.text = score.ToString() + "/"+totalCoins.ToString();
    }
}
