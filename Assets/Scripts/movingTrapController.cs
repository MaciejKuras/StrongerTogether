using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingTrapController : MonoBehaviour
{
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.MovePosition(transform.position+transform.right*Time.deltaTime);
    }
}
