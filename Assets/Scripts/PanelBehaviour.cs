using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBehaviour : MonoBehaviour
{
    public Sprite sprite;
    public GameObject segmentPrefab;
    public int rows = 3;
    public int columns = 3;

    GridLayoutGroup grid;
    int id = 0;
    
	void Start ()
    {
        grid = GetComponent<GridLayoutGroup>();
        grid.constraintCount = columns;
        
        var tex = sprite.texture;
        
        SliceAndDo(columns, rows, (x, y) => AddSegment(new Rect(tex.height * x, tex.height * y, tex.width / columns, tex.height / rows)));
    }

    void AddSegment(Rect rect)
    {
        var segment = Instantiate(segmentPrefab);
        var renderer = segment.GetComponent<SpriteRenderer>();
        
        var tex = sprite.texture;
        var segmentSprite = Sprite.Create(sprite.texture, rect, new Vector2(0.5f, 0.5f));
        renderer.sprite = segmentSprite;

        var trans = segment.GetComponent<RectTransform>();

        var collider = segment.GetComponent<BoxCollider2D>();
        Debug.Log(collider.size.x + " " + collider.size.y);
        segment.name = "segment" + id;
        segment.transform.SetParent(grid.transform);
        id++;
    }

    void SliceAndDo(int countX, int countY, Action<float, float> action)
    {
        for (int y = 0; y < countY; y++)
            for (int x = 0; x < countX; x++)
            {
                action(x / (float)countX, y / (float)countY);
            }
    }

    void Update ()
    {
		
	}
    
    
}
