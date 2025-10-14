/***************************************************************
*file: Wall.cs
*author: Alan Heng
*class: CS 4700 – Game Development
*assignment: Program 3
*date last modified: 10/13/2025
*
*purpose: This program defines the wall object that serves as a boundary for enemy movement.
*
****************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    // Start is called  before the first frame update
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
