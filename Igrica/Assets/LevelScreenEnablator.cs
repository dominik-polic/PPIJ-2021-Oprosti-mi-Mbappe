using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScreenEnablator : MonoBehaviour
{
    string LVL_1_KEY = "LVL1_UNLOCKED";
    string LVL_2_KEY = "LVL2_UNLOCKED";
    string LVL_3_KEY = "LVL3_UNLOCKED";
    string LVL_4_KEY = "LVL4_UNLOCKED";
    string LVL_5_KEY = "LVL5_UNLOCKED";
    string LVL_6_KEY = "LVL6_UNLOCKED";
    string LVL_SECRET_1_KEY = "LVLSECRET1_UNLOCKED";
    string LVL_SECRET_2_KEY = "LVLSECRET2_UNLOCKED";
    string LVL_SECRET_3_KEY = "LVLSECRET3_UNLOCKED";
    string CURRENT_SCORE_KEY = "CURRENT_SCORE";
    string CURRENT_LIVES_KEY = "CURRENT_LIVES";

    int LOCKED = 0;
    int UNLOCKED = 1;

    public ImagePosition lvl1Renderer;
    

    // Start is called before the first frame update
    void Start()
    {
       // if (PlayerPrefs.GetInt(LVL_1_KEY) != UNLOCKED) lvl1Renderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
