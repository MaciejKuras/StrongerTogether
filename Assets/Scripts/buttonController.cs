using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonController : MonoBehaviour
{
    wallController parentScript;
    AudioSource audio;

    void Start()
    {
        parentScript = transform.parent.GetComponent<wallController>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player 1") || collision.CompareTag("Player 2"))
        {
            parentScript.buttonPressed = true;
            audio.Play();
        }
    }
}
