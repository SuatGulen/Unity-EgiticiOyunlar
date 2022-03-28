using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sfx : MonoBehaviour
{
    public AudioSource tick;
    public AudioSource success;

    public void playtick(){
        tick.Play();
    }

    public void playsuccess(){
        success.Play();
    }
}
