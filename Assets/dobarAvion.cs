using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dobarAvion : MonoBehaviour
{

    public AudioClip success;
	  AudioSource audiosource;

	private float delayAmount = 0.8f;
	private bool startTimer =false;
	private float timeElapsed;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        Debug.Log("started");
    }
   void OnMouseDown(){
		audiosource.PlayOneShot(success);
		startTimer=true;
	}


void Update(){
	if(startTimer){
			timeElapsed += Time.deltaTime;
			if(timeElapsed > delayAmount){
				Debug.Log("time sam)");
				this.gameObject.SetActive(false);
			}
		}
}

}
