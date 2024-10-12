using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawntime : MonoBehaviour
{
    CreateChunks cc;
    public GameObject targetchunk;

    private void Start()
    {
        cc = FindAnyObjectByType<CreateChunks>();
    }
    

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           cc.currentchunk = targetchunk;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(cc.currentchunk == targetchunk)
            {
                cc.currentchunk = null;
            }
        }
    }
}

