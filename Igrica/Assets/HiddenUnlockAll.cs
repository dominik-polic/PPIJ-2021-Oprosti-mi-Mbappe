using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenUnlockAll : MonoBehaviour
{

    public AudioSource stisk;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void unlockAll()
    {
        stisk.Play();
        PlayerPrefs.SetInt("LVL1_UNLOCKED", 1);
        PlayerPrefs.SetInt("LVL2_UNLOCKED", 1);
        PlayerPrefs.SetInt("LVL3_UNLOCKED", 1);
        PlayerPrefs.SetInt("LVL4_UNLOCKED", 1);
        PlayerPrefs.SetInt("LVL5_UNLOCKED", 1);
        PlayerPrefs.SetInt("LVL6_UNLOCKED", 1);
        PlayerPrefs.SetInt("LVL7_UNLOCKED", 1);
        PlayerPrefs.SetInt("LVL8_UNLOCKED", 1);
        PlayerPrefs.SetInt("LVL9_UNLOCKED", 1);
        PlayerPrefs.SetInt("LVL10_UNLOCKED", 1);
        PlayerPrefs.SetInt("LVL11_UNLOCKED", 1);
        PlayerPrefs.SetInt("LVL12_UNLOCKED", 1);
        PlayerPrefs.SetInt("LVLSECRET1_UNLOCKED", 1);
        PlayerPrefs.SetInt("LVLSECRET2_UNLOCKED", 1);
        PlayerPrefs.SetInt("LVLSECRET3_UNLOCKED", 1);
    }
}
