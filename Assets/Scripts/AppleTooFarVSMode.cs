using UnityEngine;

public class AppleTooFarVSMode : MonoBehaviour
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
