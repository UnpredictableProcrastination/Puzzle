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
    public float k = 3;

    GridLayoutGroup grid;
    int id = 0;
    
	void Start ()
    {
        grid = GetComponent<GridLayoutGroup>();
        grid.constraintCount = columns;
        
        Texture2D tex = sprite.texture;

        grid.cellSize = new Vector2(tex.width / columns / k, tex.height / rows / k);
        SliceAndDo(columns, rows, (x, y) =>
        {
            Debug.Log("[" + id + "] x:" + tex.width * x + ", y:" + tex.height * y);
            AddSegment(new Rect(tex.width * x, tex.height * y, tex.width / columns, tex.height / rows));
        });

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
        collider.size = renderer.size;
        segment.name = "segment" + id;
        segment.transform.SetParent(grid.transform);
        id++;
    }

    void SliceAndDo(int countX, int countY, Action<float, float> action)
    {
        for (int y = countY - 1; y >= 0; y--)
            for (int x = 0; x < countX; x++)
            {
                //Debug.Log("[" + id + "] x:" + x + ", y:" + y);
                action(x / (float)countX, y / (float)countY);
            }
    }

    void Update ()
    {
		
	}
    
    
}
