using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorController : MonoBehaviour
{
    levelController parentScript;

    void Start()
    {
        parentScript = transform.parent.parent.GetComponent<levelController>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player 1"))
        {
            parentScript.p1ActiveDoors = true;
        }

        if (collision.CompareTag("Player 2"))
        {
            parentScript.p2ActiveDoors = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        parentScript.p1ActiveDoors = false;
        parentScript.p2ActiveDoors = false;
    }
}
