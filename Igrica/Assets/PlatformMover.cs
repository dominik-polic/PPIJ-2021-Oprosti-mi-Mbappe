using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    private Vector3 nextPos;
    private Vector3 posA;
    private Vector3 posB;    

    public float speed;
    private Transform platformTransform;
    public Transform startPosition;
    public Transform endPosition;
    public Transform playerTransform;

    private bool playerOnTop = false;
    

    // Start is called before the first frame update
    void Start()
    {

        platformTransform = GetComponent<Transform>();
        posA = startPosition.position;
        posB = endPosition.position;

        platformTransform.position = posA;

        nextPos = posB;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnTop = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnTop = false;
        }
    }

    private void FixedUpdate()
    {
        Vector3 oldPosPlatform = platformTransform.position;
        platformTransform.position = Vector3.MoveTowards(platformTransform.position, nextPos, speed * Time.deltaTime);
        if (playerOnTop)
        {
            Debug.Log("PLAYER ON TOP!");
            playerTransform.Translate((platformTransform.position - oldPosPlatform));
        }
        if(platformTransform.position == nextPos)
        {
            if (nextPos == posB)
                nextPos = posA;
            else
                nextPos = posB;
        }
    }
}
