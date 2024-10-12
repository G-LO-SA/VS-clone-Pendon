using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreateChunks : MonoBehaviour
{    
    PlayerMovement pm;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject chunk;
    [SerializeField] Transform parent;
    public float checkradius;
    public LayerMask terrainmask;
    public GameObject currentchunk;
    Vector3 noTerrain;

    public List<GameObject> chunkList;
    GameObject latestChunk;
    public float Pdismax;
    float Pdis;
    float cooldown;
    float optCooldown;
    public float duration;


    private void Start()
    {
        pm = FindAnyObjectByType<PlayerMovement>();
    }

    private void Update()
    {
        chunkchecker();
        optimize();
    }
    private void chunkchecker()
    {
        if(!currentchunk)
        {   
            Debug.Log("nothing here");
            return;
        }

        if(pm.Current.x > 0 && pm.Current.y == 0)
        {
            if(!Physics2D.OverlapCircle(currentchunk.transform.Find("Right").position, checkradius, terrainmask))
            {
                noTerrain = currentchunk.transform.Find("Right").position;
                SpawnChunk();
            }
        }

        if (pm.Current.x < 0 && pm.Current.y == 0)
        {
            if (!Physics2D.OverlapCircle(currentchunk.transform.Find("Left").position, checkradius, terrainmask))
            {
                noTerrain = currentchunk.transform.Find("Left").position;
                SpawnChunk();
            }
        }

        if (pm.Current.x == 0 && pm.Current.y > 0)
        {
            if (!Physics2D.OverlapCircle(currentchunk.transform.Find("Up").position, checkradius, terrainmask))
            {
                noTerrain = currentchunk.transform.Find("Up").position;
                SpawnChunk();
            }
        }

        if (pm.Current.x == 0 && pm.Current.y < 0)
        {
            if (!Physics2D.OverlapCircle(currentchunk.transform.Find("Down").position, checkradius, terrainmask))
            {
                noTerrain = currentchunk.transform.Find("Down").position;
                SpawnChunk();
            }
        }

        if (pm.Current.x > 0 && pm.Current.y > 0)
        {
            if (!Physics2D.OverlapCircle(currentchunk.transform.Find("Right Up").position, checkradius, terrainmask))
            {
                noTerrain = currentchunk.transform.Find("Right Up").position;
                SpawnChunk();
            }
        }

        if (pm.Current.x <  0 && pm.Current.y < 0)
        {
            if (!Physics2D.OverlapCircle(currentchunk.transform.Find("Left Down").position, checkradius, terrainmask))
            {
                noTerrain = currentchunk.transform.Find("Left Down").position;
                SpawnChunk();
            }
        }

        if (pm.Current.x > 0 && pm.Current.y < 0)
        {
            if (!Physics2D.OverlapCircle(currentchunk.transform.Find("Right Down").position, checkradius, terrainmask))
            {
                noTerrain = currentchunk.transform.Find("Right Down").position;
                SpawnChunk();
            }
        }

        if (pm.Current.x < 0 && pm.Current.y > 0)
        {
            if (!Physics2D.OverlapCircle(currentchunk.transform.Find("Left Up").position, checkradius, terrainmask))
            {
                noTerrain = currentchunk.transform.Find("Left Up").position;
                SpawnChunk();
            }
        }


    }

    void SpawnChunk()
    {
        //int rand = Random.Range(0, chunk.Count);
       latestChunk = Instantiate(chunk, noTerrain, Quaternion.identity, parent);
        chunkList.Add(latestChunk);
        Debug.Log("spawning chunks");
    }

    void optimize()
    {
        optCooldown -= Time.deltaTime;

        if(optCooldown <= 0f) 
        {
            optCooldown = duration;
        }
        else
        {
            return;
        }

        foreach (GameObject chunk in  chunkList)
        {
            Pdis = Vector3.Distance(Player.transform.position, chunk.transform.position);
            if (Pdis > Pdismax) 
            { 
                chunk.SetActive(false);
            }
            else
            {
                chunk.SetActive(true);
            }
        }
    }
}
