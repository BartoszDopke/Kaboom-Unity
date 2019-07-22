using UnityEngine;
//done
public class AppleMove : MonoBehaviour
{
    private float speed = 9.5f;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
