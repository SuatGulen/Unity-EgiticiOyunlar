using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelection : MonoBehaviour
{   
    int Scene;

    public void SelectScene(int Scene)
    {
       SceneManager.LoadScene(Scene);
    }
}
