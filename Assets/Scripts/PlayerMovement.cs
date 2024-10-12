using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Canvas canvaslocation;
    [SerializeField] Image fill;
    Camera cam;
    Vector3 currentposition;
    public float speed = 1f;
    public float health = 10f;
    private float currenthealth;
    public Vector3 offset;
    [HideInInspector]
    public Vector3 Current;



    private void Start()
    {
        currenthealth = health;
        cam = Camera.main;
    }

    private void Update()
    {   
        Vector3 screenPos = cam.WorldToScreenPoint(transform.position + offset);
        playermovement();
        fill.fillAmount = currenthealth / health;
        fill.transform.position = screenPos;
        
    }

    private void playermovement()
    {
        var movingx = (Input.GetAxis("Horizontal"));
        var movingy = (Input.GetAxis("Vertical"));

        float movementspeedx = movingx * speed * Time.deltaTime;
        float movementspeedy = movingy * speed * Time.deltaTime; 
  
        Current = new Vector3 (movementspeedx,movementspeedy);

        currentposition = player.position + Current;
        transform.position = currentposition;


        if (Input.GetAxis("Horizontal") > 0 )
        {
          animator.SetBool("Moving", true);
            spriteRenderer.flipX = false;
        }

        else if (Input.GetAxis("Horizontal") < 0)
        {
            animator.SetBool("Moving", true);
            spriteRenderer.flipX = true;
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            animator.SetBool("Moving", true);
        }

        else if (Input.GetAxis("Vertical") < 0)
        {
            animator.SetBool("Moving", true);    
        }

        else
        {
            animator.SetBool("Moving", false);
        }
    }  
    
       
    private void OnCollisionStay2D(Collision2D other)
    {
        EnemyScript Enemy = other.collider.GetComponent<EnemyScript>();

        if (Enemy)
        {
               currenthealth -= Enemy.damaging;
               Debug.Log("You are getting damaged " + currenthealth);
        }
    }

}
