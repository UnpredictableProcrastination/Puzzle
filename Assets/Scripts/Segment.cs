using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour
{
    Vector3 dir = Vector3.zero;
    bool pressed = false;
    Vector3 scale;
    
    static bool firstPress = false;
    static Segment from;

    private void Start()
    {
        scale = transform.localScale;
    }

    void Update()
    {
        if (pressed && from != this)
        {
            if(!firstPress)
            {
                firstPress = true;
                from = this;
                transform.localScale = scale * 1.2f;
            }
            else
            {
                firstPress = false;
                var pos = transform.position;
                transform.position = from.transform.position;
                from.transform.position = pos;
                from.transform.localScale = from.scale;
                pressed = false;
                from = null;
            }
        }
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

/*
 *
 *Vector2 m_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //dir = (m_pos - (Vector2)transform.position).normalized;

            //transform.Translate(dir * 0.05f);
            transform.position = m_pos;
 */
