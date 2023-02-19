using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float MonHealth = 10;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {

               MonHealth -= 10f;
            
                Debug.Log("Player hit an enemy!");
            }

            if (MonHealth <= 0f)
            {
                Destroy(gameObject);
                Debug.Log("Player died!");
                // End the game or display a game over screen
            }
        }
}
