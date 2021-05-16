using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CovidStarter : MonoBehaviour
{
    public CoronaVirusMovement covidController;
    public AudioSource koronaParty;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            covidController.isEnabled = true;
            if(!koronaParty.isPlaying) koronaParty.Play();
        }
    }
}
