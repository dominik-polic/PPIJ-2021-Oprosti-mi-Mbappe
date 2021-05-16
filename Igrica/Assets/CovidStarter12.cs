using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CovidStarter12 : MonoBehaviour
{
    public CoronaVirusMovement covidController1;
    public CoronaVirusMovement covidController2;
    public CoronaVirusMovement covidController3;
    public CoronaVirusMovement covidController4;
    public CoronaVirusMovement covidController5;
    public CoronaVirusMovement covidController6;
    public CoronaVirusMovement covidController7;
    public CoronaVirusMovement covidController8;
    public CoronaVirusMovement covidController9;
    public CoronaVirusMovement covidController10;
    public CoronaVirusMovement covidController11;
    public CoronaVirusMovement covidController12;
    public AudioSource koronaParty;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!koronaParty.isPlaying) koronaParty.Play();
        if (other.gameObject.CompareTag("Player"))
        {
            covidController1.isEnabled = true;
            covidController2.isEnabled = true;
            covidController3.isEnabled = true;
            covidController4.isEnabled = true;
            covidController5.isEnabled = true;
            covidController6.isEnabled = true;
            covidController7.isEnabled = true;
            covidController8.isEnabled = true;
            covidController9.isEnabled = true;
            covidController10.isEnabled = true;
            covidController11.isEnabled = true;
            covidController12.isEnabled = true;
        }
    }
}
