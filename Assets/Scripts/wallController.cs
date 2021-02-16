using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallController : MonoBehaviour
{
    public bool buttonPressed;

    void Start()
    {

    }

    void Update()
    {
        if (buttonPressed)
        {
            foreach (Transform child in gameObject.transform.GetChild(0))
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
