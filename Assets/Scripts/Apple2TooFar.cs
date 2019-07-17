using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple2TooFar : MonoBehaviour
{
    void Update()
    {
        //wywołanie metod ze Sprite Changerów, gdy bomba spadnie poza kamerę
        if (transform.position.y < -5.5f)
        {
            if (GameManagerVSMode.bombOutOfBoundsVSMode != null)
            {
                GameManagerVSMode.bombOutOfBoundsVSMode.Invoke();              
            }
            Destroy(gameObject);
        }
    }
}
