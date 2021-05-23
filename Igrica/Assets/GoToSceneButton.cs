using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToSceneButton : MonoBehaviour
{

    public string sceneName;
    public AudioSource stisk;

    string NEXT_LVL = "NEXT_LVL";

    void OnEnable()
    {

    }



    IEnumerator waitForStisk()
    {

        GetComponent<Image>().color = Color.white;
        if (stisk != null)
        {
            stisk.Play();
            yield return new WaitWhile(() => stisk.isPlaying);
        }
        if (sceneName != "NEXT_LVL")
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            if (!PlayerPrefs.HasKey(NEXT_LVL))
                PlayerPrefs.SetString(NEXT_LVL, "LVL_1");

            SceneManager.LoadScene(PlayerPrefs.GetString(NEXT_LVL));
        }

    }

    public void goToScene()
    {

        StartCoroutine(waitForStisk());
        
    }

    public void pushButton()
    {
        GetComponent<Image>().color = Color.magenta;
    }


    public void Update()
    {

    }
}



