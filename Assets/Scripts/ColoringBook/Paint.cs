using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour
{
    public Color[] colorList;
    public Color currentColor;
    public int colorCount;

    void Update()
    {   
        currentColor=colorList[colorCount];
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (Input.GetMouseButtonDown(0))
        {       
        if(hit.collider != null){
            SpriteRenderer sp = hit.collider.gameObject.GetComponent<SpriteRenderer>();
            sp.color = currentColor;
        }
        }
    }

    public void painting(int colorCode){
        colorCount = colorCode;
    }
}
