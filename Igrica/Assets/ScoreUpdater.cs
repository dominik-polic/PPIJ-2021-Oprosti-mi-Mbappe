using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUpdater : MonoBehaviour
{
    string HIGHSCORE = "HIGHSCORE_CURRENT";
    string SCORE = "SCORE_CURRENT";
    string REMAINING_LIVES = "REMAINING_LIVES";

    // Start is called before the first frame update
    void Start()
    {
        //Reset score on game reset
        if (PlayerPrefs.HasKey(SCORE))
        {
            int newScore = PlayerPrefs.GetInt(SCORE);
            if (newScore > PlayerPrefs.GetInt(HIGHSCORE))
                PlayerPrefs.SetInt(HIGHSCORE, newScore);
        }
        PlayerPrefs.SetInt(SCORE, 0);
        PlayerPrefs.SetInt(REMAINING_LIVES, 3);
        string highscore = "High score: ";
        if (!PlayerPrefs.HasKey(HIGHSCORE))
            PlayerPrefs.SetInt(HIGHSCORE, 0);

        highscore += PlayerPrefs.GetInt(HIGHSCORE).ToString();
        GetComponent<TextMeshProUGUI>().text = highscore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
