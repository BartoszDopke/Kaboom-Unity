using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//done
public class PlayerMove : MonoBehaviour
{
    public float speed = 35f;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }
}
