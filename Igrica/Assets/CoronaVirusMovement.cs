using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoronaVirusMovement : MonoBehaviour
{

    public AIDestinationSetter aiSetter;
    public Transform player;
    public Transform coronaVirus;
    public Transform coronaVirusHover;
    public float minimalDistanceToFollow;
    public float damage;

    public Collider2D thisCollider;
    public Collider2D playerCollider;
    public float damagePeriod = 20f;
    private float nextDamage = .0f;

    public bool isEnabled = true;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float distanceToPlayer = Vector3.Distance(player.position, coronaVirus.position);
        //Debug.Log(distanceToPlayer);
        if(distanceToPlayer < minimalDistanceToFollow && isEnabled)
        {
            aiSetter.target = player;
        }
        else
        {
            aiSetter.target = coronaVirusHover;
        }

        if (thisCollider.IsTouching(playerCollider))
        {
            float time = Time.time;
            if (time > nextDamage)
            {
                nextDamage = (time + damagePeriod);
                ScoreManager.instance.DoDamage(damage);
            }
        }
    }

    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.DoDamage(damage);            
        }
    }*/
}
