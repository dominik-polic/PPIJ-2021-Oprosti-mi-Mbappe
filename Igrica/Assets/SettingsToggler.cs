using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsToggler : MonoBehaviour
{
    public string settingKey;
    public AudioSource stisk;
    public bool defaultEnabled = true;

    int ENABLED = 1;
    int DISABLED = 0;

    void OnEnable()
    {
        if (!PlayerPrefs.HasKey(settingKey))
            PlayerPrefs.SetInt(settingKey, ENABLED);

        if(PlayerPrefs.GetInt(settingKey) == ENABLED)
        {
            GetComponent<Image>().color = Color.white;
        }
        else
        {
            GetComponent<Image>().color = Color.grey;
        }
    }



    public void togglePref()
    {
        stisk.Play();
        if (settingKey == "RESET_ALL")
        {
            PlayerPrefs.DeleteAll();
            return;
        }
        
        if (PlayerPrefs.GetInt(settingKey) != ENABLED)
        {
            PlayerPrefs.SetInt(settingKey, ENABLED);
            GetComponent<Image>().color = Color.white;
        }
        else
        {
            PlayerPrefs.SetInt(settingKey, DISABLED);
            GetComponent<Image>().color = Color.grey;
        }
        

    }


    public void Update()
    {

    }
}
