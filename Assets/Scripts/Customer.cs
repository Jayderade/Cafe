using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public Rigidbody player;
    public float rotateSpeed = 1;
    public float maxRotate = 100000;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if (rotateSpeed < maxRotate)
        {
            rotateSpeed = rotateSpeed + 1;
        }
        //player.transform.localScale = new Vector3(rotateSpeed * .0005f, rotateSpeed * .001f, rotateSpeed * .0005f);            
            player.transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
       // player.AddForce(transform.up * rotateSpeed * Time.deltaTime);
    */}
}
