/***************************************************************
*file: PlayerDeath.cs
*author: Alan Heng
*class: CS 4700 – Game Development
*assignment: Program 3
*date last modified: 10/13/2025
*
*purpose: This program defines the player death behavior when colliding with an enemy.  
*
****************************************************************/ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;   // add this at the top

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] float restartDelay = 0.2f;  // small pause; set 0 for instant
    bool isDead = false;
    Rigidbody2D rb;

    void Awake() { rb = GetComponent<Rigidbody2D>(); }

    // solid collisions
    void OnCollisionEnter2D(Collision2D c)
    {
        if (IsEnemy(c.collider)) Die();
    }

    // trigger collisions
    void OnTriggerEnter2D(Collider2D other)
    {
        if (IsEnemy(other)) Die();
    }

    bool IsEnemy(Collider2D col)
    {
        // covers child colliders: checks the collider, its parent, and root
        if (col.CompareTag("Enemy")) return true;
        Transform p = col.transform.parent;
        if (p && p.CompareTag("Enemy")) return true;
        return col.transform.root.CompareTag("Enemy");
    }

    void Die()
    {
        if (isDead) return;
        isDead = true;

        // optional: freeze player control/motion
        if (rb) { rb.velocity = Vector2.zero; rb.isKinematic = true; }
        // TODO: play death anim/sound here if you have one

        if (restartDelay <= 0f)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else
            Invoke(nameof(Reload), restartDelay);
    }

    void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
