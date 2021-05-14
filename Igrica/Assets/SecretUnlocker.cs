using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretUnlocker : MonoBehaviour
{

    public Renderer tmRenderer;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tmRenderer.enabled = false;
        }
    }
}
