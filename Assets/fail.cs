using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class fail : MonoBehaviour
{
	public AudioClip failed;
	  AudioSource audiosource;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        Debug.Log("started");
    }
   void OnMouseDown(){
		audiosource.PlayOneShot(failed);
	}
}
