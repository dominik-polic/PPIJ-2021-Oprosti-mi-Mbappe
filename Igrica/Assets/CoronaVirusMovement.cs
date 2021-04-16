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
        if(distanceToPlayer < minimalDistanceToFollow)
        {
            aiSetter.target = player;
        }
        else
        {
            aiSetter.target = coronaVirusHover;
        }
    }
}
