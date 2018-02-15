using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Boundary
{
    public float maxPosX, minPosX;
}


public class PlayerMove : MonoBehaviour {

    [SerializeField]
    float speed;
    [SerializeField]
    Boundary boundary;

    private Rigidbody2D rb;

    Vector3 player_Pos;

    bool game_Over;

    bool started;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    void Start () {
        game_Over = false;
        started = false;
	}
	
	// Update is called once per frame
	void Update () {
        player_Pos = transform.position;
        player_Pos.x = Mathf.Clamp(player_Pos.x, boundary.minPosX, boundary.maxPosX);
        transform.position = player_Pos;

        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
               
                started = true;
            }
        }

    }
    private void FixedUpdate()
    {
       

        MovePlayer();
        /* if(Application.platform == RuntimePlatform.WindowsPlayer)
         {
             MovePlayer();
         }
         else if(Application.platform == RuntimePlatform.Android)
         {
             TouchMove();
         }
         */
    }

    void MovePlayer()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(horizontalMove * speed, 0.0f);
    }

    void TouchMove()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float middlePoint = Screen.width / 2;


            if (touch.position.x < middlePoint && touch.phase == TouchPhase.Began)
            {
                MoveLeft();
            }
            else if (touch.position.x > middlePoint && touch.phase == TouchPhase.Began)
            {
                MoveRight();
            }
        }
        else
        {
            SetVelocityZero();
        }
    }

    void MoveLeft()
    {
        rb.velocity = new Vector2(-speed, 0f);
    }
    void MoveRight()
    {
        rb.velocity = new Vector2(speed, 0f);
    }
    void SetVelocityZero()
    {
        rb.velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if(collision.gameObject.tag == "FallingBlock" && !game_Over)
        {
            game_Over = true;
           
            Destroy(gameObject);
        }

    */
        if(collision.gameObject.tag == "FallingSphere" && !game_Over)
        {
            game_Over = true;
           

            Destroy(gameObject);
        }
    }


}
