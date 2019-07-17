using UnityEngine;


//done
public class AppleMove : MonoBehaviour
{
    public float speed = 8.5f;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
