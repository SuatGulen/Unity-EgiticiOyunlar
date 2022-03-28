using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectController : MonoBehaviour
{   
    public int selected;
    GameObject SelectedItem1;
    GameObject SelectedItem2;
    public int matched;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider!=null && hit.transform.CompareTag("Item"))
            { 
            if(hit.collider!=null && hit.collider.gameObject.GetComponent<Items>().isSelectedBefore==false){
                if (selected==0){
                    SelectedItem1=hit.transform.gameObject;
                    SelectedItem1.GetComponent<Items>().isSelected=true;
                    selected++;
                }
                else if(selected==1){
                    SelectedItem2=hit.transform.gameObject;
                    SelectedItem2.GetComponent<Items>().isSelected=true;
                    selected++;

                    if(SelectedItem1.GetComponent<Items>().itemId*-1==SelectedItem2.GetComponent<Items>().itemId){
                        matched++;

                        if(SelectedItem1.GetComponent<Items>().itemId<0)
                        SelectedItem1.GetComponent<SpriteRenderer>().material = new Material(Shader.Find("Sprites/Default"));
                        else
                        SelectedItem2.GetComponent<SpriteRenderer>().material = new Material(Shader.Find("Sprites/Default"));

                        SelectedItem1.GetComponent<Items>().isSelected=false;
                        SelectedItem2.GetComponent<Items>().isSelected=false;
                        SelectedItem1.GetComponent<Items>().isSelectedBefore=true;
                        SelectedItem2.GetComponent<Items>().isSelectedBefore=true;
                        selected=0;
                    }
                    else
                    {
                        SelectedItem1.GetComponent<Items>().isSelected=false;
                        SelectedItem2.GetComponent<Items>().isSelected=false;
                        selected=0;
                    }
                }        
            }
            }
        }
        if (matched == 4)
        {
            if(SceneManager.GetActiveScene().buildIndex==22)
            SceneManager.LoadScene(1);
            else
            SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
