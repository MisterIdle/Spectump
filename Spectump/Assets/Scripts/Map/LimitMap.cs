using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitMap : MonoBehaviour
{
    public float forceMagnitude = 3f;
    public float pushDuration = 0.1f;
    public float friction = 0.1f;
    public Rigidbody2D player;
    private PlayerController playerController;

    public void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 directionToCenter = transform.position - collision.transform.position;
            player.AddForce(directionToCenter.normalized * forceMagnitude, ForceMode2D.Impulse);

            playerController.TakeDamage(1);

            Invoke("StopForce", pushDuration);
        }
    }

    private void StopForce()
    {
        if (player != null)
        {
            player.velocity = Vector2.zero;
        }      
    }
}
