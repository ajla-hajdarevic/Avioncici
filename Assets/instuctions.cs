using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instuctions : MonoBehaviour
{
    public AudioClip level1;
	  AudioSource audiosource;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        Debug.Log("started");
    }
   void OnMouseDown(){
		audiosource.PlayOneShot(level1);
	}
}
