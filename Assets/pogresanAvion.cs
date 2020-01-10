using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pogresanAvion : MonoBehaviour
{
    public AudioClip fail;
	  AudioSource audiosource;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        Debug.Log("started");
    }
   void OnMouseDown(){
		audiosource.PlayOneShot(fail);
	}
}
