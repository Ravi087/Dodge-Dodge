using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour {

    [SerializeField]
    GameObject[] sphere_Prefab;
    [SerializeField]
    Boundary boundary;

    [SerializeField]
    Vector2 prefabSize;

    private int prefab_nos;


	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnShere", 3f, 2f);
	}
	
	// Update is called once per frame
	void Update () {

       
	}

    void SpawnShere()
    {
        prefab_nos = Random.Range(0, sphere_Prefab.Length);
        Vector3 spawnPos = new Vector3(Random.Range(boundary.minPosX, boundary.maxPosX),
                                    transform.position.y,
                                    transform.position.z);
        Quaternion spawnRot = Quaternion.identity;

        float size = Random.Range(prefabSize.x, prefabSize.y);

        GameObject spheres = Instantiate(sphere_Prefab[prefab_nos], spawnPos, spawnRot) as GameObject;

        spheres.transform.localScale = Vector3.one * size;
    }

}
