using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlockPrefab : MonoBehaviour {


    [SerializeField]
    Vector2 speedMinMax;
    
   private float speed;

	// Use this for initialization
	void Start () {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, DifficultyGame.DifficultyPercentage());
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -12)
        {
            Destroy(gameObject);
        }
    }
}
