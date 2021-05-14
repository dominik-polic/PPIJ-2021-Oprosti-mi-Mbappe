using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public int damagePerSecond = 1;

    public Collider2D thisCollider;
    public Collider2D playerCollider;

    public float damagePeriod = 20f;
    private float nextDamage = .0f;

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.DoDamage(damagePerSecond);

        }
    }*/


    private void FixedUpdate()
    {
        if (thisCollider.IsTouching(playerCollider)){
            float time = Time.time;
            if (time > nextDamage)
            {
                nextDamage = (time + damagePeriod);
                ScoreManager.instance.DoDamage(damagePerSecond);
            }                       
        }
    }
}
