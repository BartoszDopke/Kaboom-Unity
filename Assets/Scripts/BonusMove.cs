﻿using UnityEngine;

public class BonusMove : MonoBehaviour
{
    public float speed = 12.5f;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
