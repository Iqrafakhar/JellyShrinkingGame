using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingPlayerMovement : MonoBehaviour
{
    Vector3 size;
    public float speed;
    public  float turnSpeed;
    private float LeftRight;
    private float MoveForward;
    public bool GameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LeftRight = Input.GetAxis("Horizontal");
        MoveForward = Input.GetAxis("Vertical"); 
        transform.Translate(Vector3.forward * Time.deltaTime * speed * MoveForward);
        transform.Rotate(Vector2.up, turnSpeed * LeftRight * Time.deltaTime);    
       
       

        /*Code to shrink the local scale of the object */
        if (Input.GetKeyDown(KeyCode.Z))
        {
                size = transform.localScale;
                size.x += 0.8f;
                size.y = 0.5f;
                size.z = 1f;
                transform.localScale = size;
   
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            size = transform.localScale;
            size.x = 1f;
            size.y = 1f;
            size.z = 1f;
            transform.localScale = size;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            size = transform.localScale;
            size.x = 0.5f;
            size.y += 1.5f;
            size.z = 1f;
            transform.localScale = size;   
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            size = transform.localScale;
            size.x = 1f;
            size.y = 1f;
            size.z = 1f;
            transform.localScale = size;
        }
        //Code Ends here for shrinking
    }
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Hurdle1" || collision.gameObject.name == "Hurdle2")
        {
            GameOver = true;
            Debug.Log("Game Over");
            //Destroy(gameObject);
        }

    }
}
