using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlockPrefabSpawner : MonoBehaviour {

    [SerializeField]
    GameObject[] prefab;

    private int prefabNos;
    //to clamp between the values.
    [SerializeField]
    Boundary boundary;

    //for Size
    [SerializeField]
    Vector2 prefabSize;


    //for rotation
    [SerializeField]
    Vector2 prefabRotation;

    //to increase the time for next Spawn
    private float spawnTime = 1f;

    //time for next spawn
    private float timer = 0.0f ;
    
    //to spawn blocks for this position to this position
    Vector3 spawnPos;

   

    // Use this for initialization
    void Start () {
      //  InvokeRepeating("SpawnPrefabs", 1f, .5f);
	}
	
	// Update is called once per frame
	void Update () {

        if(Time.time > timer)
        {
            SpawnPrefabs();

            timer = Time.time + spawnTime;
            //Speed up the spawnrate for the next egg
            spawnTime = spawnTime * 0.99f;
            spawnTime = Mathf.Clamp(spawnTime, 0.4f, 5f);
        }


    }

   

    void SpawnPrefabs()
    {

        prefabNos = Random.Range(0, prefab.Length);
        float spawnRot = Random.Range(prefabRotation.x, prefabRotation.y);
        

        float spawnSize = Random.Range(prefabSize.x, prefabSize.y);
       
            spawnPos = new Vector3(Random.Range(boundary.minPosX, boundary.maxPosX),
                    transform.position.y,
                    transform.position.z);

            Quaternion spawnRotation = Quaternion.Euler(Vector3.forward * spawnRot);

            GameObject gameObject_Prefabs = Instantiate(prefab[prefabNos], spawnPos, spawnRotation) as GameObject;

            
            gameObject_Prefabs.transform.localScale = Vector3.one * spawnSize;
        }

       

    }

