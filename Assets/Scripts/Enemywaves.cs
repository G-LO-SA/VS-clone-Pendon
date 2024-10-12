using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.VFX;
using static UnityEditor.Experimental.GraphView.GraphView;
using Random = UnityEngine.Random;

public class Enemywaves : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] List<GameObject> toSpawn;
    [SerializeField] Transform Parent;
    [SerializeField] List<GameObject> spawnthis;
    [SerializeField] float enemylimit = 10f;
    [SerializeField] Image fill;
    public float timecount = 3f;
    public float bigwavecount = 60f;
    private float frequency = 1f;
    private float bigfrequency = 1f;
    private int numberarray = 0;
    private int activecount;
    public Vector3 camedge;
    private GameObject enemy;
    

    private void Start()
    {
        NEnemies();
        cam = Camera.main;
        
    }

    private void Update()
    {
         if (frequency < timecount)
         {
             frequency += Time.deltaTime;

         }
         
         else 
         {   
             frequency = 0f;
            numbertospawn();
            
         }

        bigwaves();

        fill.fillAmount = bigfrequency/ bigwavecount;
    }

    private void NEnemies()
    {   
        
        for (int i = 0; i < enemylimit; i++) 
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

            camedge = cam.ViewportToWorldPoint(new Vector3(spawnX, spawnY, 0));

            var rand = Random.Range( 0,spawnthis.Count);
            var enemy = Instantiate(spawnthis[rand], transform.position + camedge, Quaternion.identity, Parent);
            enemy.SetActive(false);
            toSpawn.Add(enemy);
           
        }

    }

    private void numbertospawn()
    {

        if(activecount < enemylimit) 
        {   
            
            toSpawn[numberarray].SetActive(true);
            numberarray++;
            activecount++;
        }

        else
        {
            CancelInvoke(nameof(numbertospawn));
            numberarray = 0;
            activecount = 0;
        }

    }

    private void bigwaves()
    {

        if (bigfrequency < bigwavecount)
        {
            bigfrequency += Time.deltaTime;

        }

        else
        {
            bigfrequency = 0f;
            foreach (GameObject spawn in toSpawn)
            {
                spawn.SetActive(true);
            }

        }
    }
    
    private void spawningarea()
    {
        
        /*if (point.position.y > center.position.y || point.position.y < center.position.y) 
        {
            if (rnumber == 1 )
            {
                randomranges = new Vector3(Random.Range(localcords, -localcords), 0, 0);
                
            }

            else if (rnumber == 2)
            {
                randomranges = new Vector3(Random.Range(localcords, -localcords), 0, 0);
                
            }
        }

        if (point.position.x > center.position.x || point.position.x < center.position.x)
        {
            if (rnumber == 3)
            {
                randomranges = new Vector3(0, Random.Range(localcords, -localcords), 0);
                
            }

            else if (rnumber == 4)
            {
                randomranges = new Vector3(0, Random.Range(localcords, -localcords), 0);
                
            }
        }
        return randomranges;*/
    }

}
