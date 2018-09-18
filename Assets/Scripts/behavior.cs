using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behavior : MonoBehaviour
{
    Vector3 dir = Vector3.zero;
    bool pressed = false;
    static Vector2 commonPosition;

    void Update()
    {
        if(pressed)
        {
            Vector2 m_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //dir = (m_pos - (Vector2)transform.position).normalized;
            commonPosition = m_pos;
            //transform.Translate(dir * 0.05f);
            transform.position = commonPosition;
        }
        transform.position = commonPosition;
    }

    private void OnMouseDown()
    {
        pressed = true;
    }

    private void OnMouseUp()
    {
        pressed = false;
    }
}
