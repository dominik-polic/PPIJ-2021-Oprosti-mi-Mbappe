using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CheckEnabledButton : MonoBehaviour
{

    public string KEY;
    int UNLOCKED = 1;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt(KEY) != UNLOCKED)
        {
            GetComponent<EventTrigger>().enabled  = false;
            GetComponent<Image>().color = Color.gray;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
