using UnityEngine;

//done
public class AppleTooFar : MonoBehaviour
{   
    void Update()
    {
        //wywołanie metod ze Sprite Changerów, gdy bomba spadnie poza kamerę
        if (transform.position.y < -5.5f)
        {
            if (GameManager.bombOutOfBounds != null)
            {
                GameManager.bombOutOfBounds.Invoke();
            }
            Destroy(gameObject);

            if (GameManager.bombOutOfBounds2 != null)
            {
                GameManager.bombOutOfBounds2.Invoke();
            }
            Destroy(gameObject);
        }
    }
}
