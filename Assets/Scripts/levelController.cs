using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelController : MonoBehaviour
{
    public bool p1ActiveDoors, p2ActiveDoors;
    static int i = 1;
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (p1ActiveDoors && p2ActiveDoors && SceneManager.sceneCountInBuildSettings > i)
        {
            SceneManager.LoadScene(i);
            i++;
            audio.Play();
        }
        else if (p1ActiveDoors && p2ActiveDoors && SceneManager.sceneCountInBuildSettings == i)
        {
            audio.Play();
        }
    }
}
