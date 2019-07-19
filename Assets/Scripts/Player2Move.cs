using UnityEngine;

public class Player2Move : MonoBehaviour
{
    //zmienne
    public float speed;
    private Rigidbody2D rb;
    private Vector3 mousePosition;
    private Vector3 oldPosition;
    float diffPos;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {         
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition = new Vector3(mousePosition.x, -5.0f, 0);
            diffPos = mousePosition.x - transform.position.x;
            if(Mathf.Abs(diffPos) > speed * Time.deltaTime)
            {
                transform.position += speed * Vector3.right * Mathf.Sign(diffPos) * Time.deltaTime;
            }
            else
            {
                Vector3 mousePos =  mousePosition;
                mousePos.y = transform.position.y;
                transform.position = mousePos;
            }
        }    
    }
}
