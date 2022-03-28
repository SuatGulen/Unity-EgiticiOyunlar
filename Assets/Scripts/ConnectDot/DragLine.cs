using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragLine : MonoBehaviour
{   
    public Vector3 startPos;
    public Vector3 endPos;
    Camera maincamera;
    LineRenderer lr;
    int Dot=1;

    Vector3 camOffset=new Vector3(0,0,10);

    void Start()
    {
         maincamera=Camera.main;
    }

    void Update()
    {
       if(Input.GetMouseButtonDown(0)){
           if(lr==null){
               lr=gameObject.AddComponent<LineRenderer>();
           }
           lr.enabled=true;
           lr.positionCount=2;
           lr.material = new Material(Shader.Find("Sprites/Mask"));
           lr.startColor=Color.black;
           lr.endColor=Color.black;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray,Mathf.Infinity);
              if(hit.collider!=null && hit.collider.gameObject.GetComponent<DotMouse>().DotNum==Dot)
             {
                lr.material = new Material(Shader.Find("Sprites/Default"));
                startPos=maincamera.ScreenToWorldPoint(Input.mousePosition)+camOffset;
                lr.SetPosition(0,startPos);
                lr.useWorldSpace=true;
             }
       } 
      
       if(Input.GetMouseButton(0)){
           endPos=maincamera.ScreenToWorldPoint(Input.mousePosition)+camOffset;
           lr.SetPosition(1,endPos);
       }

        
        if (Input.GetMouseButtonUp(0))
        {   
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray,Mathf.Infinity);
              if(hit.collider!=null && hit.collider.gameObject.GetComponent<DotMouse>().DotNum==Dot+1 && lr.enabled==true)
             {
                DrawLine(startPos,endPos,Color.black);
                Dot++;
             }
             if(hit.collider!=null && Dot > 5 && hit.collider.gameObject.GetComponent<DotMouse>().DotNum==1){
                if(SceneManager.GetActiveScene().buildIndex==6){
                    SceneManager.LoadScene(1);
                }
                else{
                    SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
                }
             }
             lr.enabled=false;
        }
    }
    void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 300f)
         {
            GameObject Line = new GameObject();
            Line.transform.position = start;
            Line.AddComponent<LineRenderer>();
            LineRenderer LRenderer = Line.GetComponent<LineRenderer>();
            LRenderer.material = new Material(Shader.Find("Sprites/Default"));
            LRenderer.SetColors(Color.black, Color.black);
            LRenderer.SetPosition(0, start);
            LRenderer.SetPosition(1, end);
            GameObject.Destroy(Line, duration);
         }
}
