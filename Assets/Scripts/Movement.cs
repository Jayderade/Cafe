using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool pickedUp = false;
    public float rotateSpeed;
    public float speed;
    public Transform tableSpace;
    public Transform foodSpace;  
    public Rigidbody player;
    public Transform curFood;
    public GameObject gum;
    public Collider gumCol;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    #region Food pickup & down
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Food" && !pickedUp)
        {
            
            gum = collision.gameObject;
            gumCol = gum.GetComponent<Collider>();
            gumCol.enabled = false;
            collision.transform.position = foodSpace.position;
            collision.transform.SetParent(foodSpace);
            pickedUp = true;
        }
        if (collision.transform.tag == "Table" && pickedUp)
        {
            collision.gameObject.tag = "Table Served";
            tableSpace = collision.transform.GetChild(0);
            gum.transform.position = tableSpace.position;
            gum.transform.SetParent(collision.transform);
            gum = null;
            
            pickedUp = false;
        }
        if (collision.transform.tag == "Table Served" && pickedUp)
        {
            collision.gameObject.tag = "Untagged";
            tableSpace = collision.transform.GetChild(2).GetChild(0);
            gum.transform.position = tableSpace.position;
            gum.transform.SetParent(collision.transform);
            gum = null;

            pickedUp = false;
        }
        if (collision.transform.tag == "Customer" && pickedUp)
        {
            collision.gameObject.tag = "Customer Hand";
            tableSpace = collision.transform.GetChild(2).GetChild(0);
            gum.transform.position = tableSpace.position;
            gum.transform.SetParent(collision.transform);
            gum = null;

            pickedUp = false;
        }
        if (collision.transform.tag == "Customer Hand" && pickedUp)
        {
            collision.gameObject.tag = "Untagged";
            tableSpace = collision.transform.GetChild(2).GetChild(1);
            gum.transform.position = tableSpace.position;
            gum.transform.SetParent(collision.transform);
            gum = null;

            pickedUp = false;
        }
    }
    #endregion
    // Update is called once per frame
    void Update()
    {
        #region Movement
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            player.AddForce(transform.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            player.AddForce(transform.forward * -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //player.AddForce(-speed * Time.deltaTime, 0, 0);
            player.transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            player.transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime,0);
            //player.AddForce(speed * Time.deltaTime, 0, 0);
        }
        #endregion
        
    }
}
