/***************************************************************
*file: EndGoal.cs
*author: Adam Khalil
*class: CS 4700 – Game Development
*assignment: Program 3
*date last modified: 10/13/2025
*
*purpose: This program defines the end goal object that triggers the end of the game when the player reaches it.
*
****************************************************************/

using UnityEngine;

public class EndGoal : MonoBehaviour
{
    public GameEndUI gameEndUI;

    public bool oneShot = true;
    private bool triggered = false;

    // small delay to avoid triggering at time 0 if something overlaps
    public float activateDelay = 0.2f;

    void Awake()
    {
        if (gameEndUI == null)
        {
            gameEndUI = FindObjectOfType<GameEndUI>();
            if (gameEndUI == null)
                Debug.LogError("[EndGoal] No GameEndUI found in scene.");
        }

        var col = GetComponent<Collider2D>();
        if (col == null) Debug.LogError("[EndGoal] Add a BoxCollider2D and set Is Trigger ON.");
        else col.isTrigger = true;
    }
    // Triggered when something enters the trigger collider
    void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered && oneShot) return;
        if (Time.timeSinceLevelLoad < activateDelay) return;
        if (!other.CompareTag("Player")) return;

        triggered = true;
        if (gameEndUI != null) gameEndUI.Show();
    }
}
