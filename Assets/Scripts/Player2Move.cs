using UnityEngine;

public class Player2Move : MonoBehaviour
{
    //zmienne
    public float speed;
    private Rigidbody2D rb;
    private Vector3 mousePosition;
    private Vector3 oldPosition;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);          
            transform.position = new Vector3(transform.position.x, -5.0f, 0); 
            mousePosition = new Vector3(mousePosition.x, -5.0f, 0);
            transform.position = Vector3.Lerp(transform.position, mousePosition, speed / 15);
            
        }
        
    }
}
