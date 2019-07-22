using UnityEngine;

public class Bounds : MonoBehaviour
{
    //ustawienie ograniczeń ekranu dla Bombera i graczy
    void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -9.3f, 9.3f); //granice na osi x
        transform.position = pos;
    }
}
