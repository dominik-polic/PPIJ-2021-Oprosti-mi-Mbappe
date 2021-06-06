using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsInit : MonoBehaviour
{
    string PREFS_INIT_VERSION = "PREFS_INIT_VERSION";
    string TOUCH_ENABLED = "TOUCH_ENABLED";
    string NEXT_LVL = "NEXT_LVL";
    string CRK_ENABLED = "CRK_ENABLED";
    string LVL1_UNLOCKED = "LVL1_UNLOCKED";

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey(PREFS_INIT_VERSION))
        {
            PlayerPrefs.SetInt(PREFS_INIT_VERSION,1);
            PlayerPrefs.SetInt(TOUCH_ENABLED, 1);
            PlayerPrefs.SetString(NEXT_LVL, "LVL_1");
            PlayerPrefs.SetInt(CRK_ENABLED, 1);
            PlayerPrefs.SetInt(LVL1_UNLOCKED, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
