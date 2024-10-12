using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [SerializeField] Camera cam;
    [SerializeField] Rigidbody2D rbEnemy;
    [SerializeField] Transform player;
    private float eHealth;
    public float damaging => enemy.enemyDamage;

    private void Start()
    {
        resethealth();
        cam = Camera.main;
    }
    private void FixedUpdate()
    {
        moveToPlayer();
    }
    public void moveToPlayer ()
    {
      rbEnemy.MovePosition(Vector2.MoveTowards(rbEnemy.position, player.position, enemy.enemySpeed * Time.fixedDeltaTime));
    }

   private void OnEnable()
    {
        resethealth();
    }


    private void resethealth()
    {
        eHealth = enemy.enemyHealth; 
    }

    private void OnDisable()
    {
        var spawnX = Random.Range(0f, 1f);
        if (spawnX < 0.5f)
        {
            spawnX = 0 - Random.Range(0f, 1f);
        }
        else
        {
            spawnX = 1 + Random.Range(0f, 1f);
        }
        var spawnY = Random.Range(0f, 1f);
        if (spawnY < 0.5f)
        {
            spawnY = 0 - Random.Range(0f, 1f);
        }
        else
        {
            spawnY = 1 + Random.Range(0f, 1f);
        }

        var camedge = cam.ViewportToWorldPoint(new Vector3(spawnX, spawnY, 0));
        transform.position = camedge;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            eHealth -= 1;
            Debug.Log("getting damaged " + eHealth);

            if (eHealth <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

}
