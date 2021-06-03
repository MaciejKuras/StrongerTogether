using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFloorController : MonoBehaviour
{
    
    public GameObject floor;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {

       floor.GetComponent<movingObjectController>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player 1") || collision.CompareTag("Player 2"))
        {
            floor.GetComponent<movingObjectController>().enabled = true;
            audio.Play();
        }
    }
}
