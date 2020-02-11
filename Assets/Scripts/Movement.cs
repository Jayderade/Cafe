using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool pickedUp = false;
    public float speed;    
    public Transform foodSpace;  
    public Rigidbody player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Food" && !pickedUp)
        {
            collision.transform.position = foodSpace.position;
            collision.transform.SetParent(foodSpace);
            pickedUp = true;
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        #region Movement
        if (Input.GetKey(KeyCode.UpArrow))
        {
            player.AddForce(0,0, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            player.AddForce(0, 0,-speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.AddForce(-speed * Time.deltaTime, 0, 0);
            player.transform.Rotate(0, Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.transform.Rotate(0, Input.GetAxis("Horizontal") * speed * Time.deltaTime,0);
            player.AddForce(speed * Time.deltaTime, 0, 0);
        }
        #endregion

    }
}
