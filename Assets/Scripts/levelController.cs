using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelController : MonoBehaviour
{
    public bool p1ActiveDoors, p2ActiveDoors;
    static int i = 1;

    void Start()
    {

    }

    void Update()
    {
        if (p1ActiveDoors && p2ActiveDoors && SceneManager.sceneCountInBuildSettings > i)
        {
            SceneManager.LoadScene(i);
            i++;
        }
        else if (p1ActiveDoors && p2ActiveDoors && SceneManager.sceneCountInBuildSettings == i)
        {
            Debug.Log("kek");
        }
    }
}
