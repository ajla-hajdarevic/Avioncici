using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;



public class DestroyOnClick : MonoBehaviour
{
	public AudioClip win;
	  AudioSource winn;

	  [SerializeField]
	  private float delayAmount = 10f;
	  [SerializeField]
	  private string swichToScene;
	  private float timeElapsed;
	  private bool startTimer =false;


    void Start()
    {
        winn = GetComponent<AudioSource>();
        Debug.Log("started");
    }
   void OnMouseDown(){
	winn.PlayOneShot(win);
	Destroy(gameObject);
}



    
    }

