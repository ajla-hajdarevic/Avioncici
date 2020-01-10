using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(AudioSource))]
public class clickable : MonoBehaviour
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
		startTimer=true;
  
	}

	private void Update(){
		if(startTimer){
			timeElapsed += Time.deltaTime;
			if(timeElapsed > delayAmount){
				SceneManager.LoadScene(swichToScene);
			}
		}
	}

}
