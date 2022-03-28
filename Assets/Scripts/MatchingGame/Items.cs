using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    
    public bool isSelected=false;
    public bool isSelectedBefore=false;
    public int itemId;

    void Update()
    {
            if(isSelected==true){
                this.GetComponent<RawImage>().enabled=true;
            }
            if(isSelected==false){
                this.GetComponent<RawImage>().enabled=false;
            }

    }
}