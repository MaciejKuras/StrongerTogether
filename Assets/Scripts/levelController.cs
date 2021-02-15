using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelController : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("kek");
            SceneManager.LoadScene(1);
        }
    }
}
