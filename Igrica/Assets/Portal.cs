using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public string sendToLevel;
    public AudioSource enterSound;

    string NEXT_LVL = "NEXT_LVL";

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0;
            StartCoroutine(waitForPredz());
        }
    }

    IEnumerator waitForPredz() { 

        if (enterSound != null)
        {
            enterSound.Play();
            yield return new WaitWhile(() => enterSound.isPlaying);
        }
        PlayerPrefs.SetString(NEXT_LVL, sendToLevel);
        Time.timeScale = 1;
        ScoreManager.instance.enterPortal(sendToLevel);
    }

}