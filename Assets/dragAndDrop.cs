
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class dragAndDrop : MonoBehaviour
{
	public AudioClip win, fail;
	AudioSource jupii;
	AudioSource faill;

	[SerializeField]
	private float delayAmount = 10f;
	[SerializeField]
	private string swichToScene;
	private float timeElapsed;
	private bool startTimer =false;

	public GameObject stamp1, stamp2, stamp3, passport;
    //Initialize Variables
	GameObject getTarget;
	bool isMouseDragging;
	Vector3 offsetValue;
	Vector3 positionOfScreen;
	Vector3 stamp1InitialPos,stamp2InitialPos,stamp3InitialPos, passportPosition;


    // Use this for initialization 
	void Start()
	{

		jupii = GetComponent<AudioSource>();
		faill = GetComponent<AudioSource>();

		stamp1InitialPos = stamp1.transform.position;
		stamp2InitialPos = stamp2.transform.position;
		stamp3InitialPos = stamp3.transform.position;
		passportPosition = passport.transform.position;
	}



	void Update()
	{

        //Mouse Button Press Down
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hitInfo;
			getTarget = ReturnClickedObject(out hitInfo);
			if (getTarget != null)
			{
				isMouseDragging = true;
                //Converting world position to screen position.
				positionOfScreen = Camera.main.WorldToScreenPoint(getTarget.transform.position);
				offsetValue = getTarget.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z));
			}
		}

        //Mouse Button Up
		if (Input.GetMouseButtonUp(0))
		{

			RaycastHit hitInfo;
			getTarget = ReturnClickedObject(out hitInfo);

			if (getTarget != null){ 
				isMouseDragging = false;

				if(getTarget.name=="stamp1"){
						faill.PlayOneShot(fail);
						getTarget.transform.position = stamp1InitialPos;
				}

				if(getTarget.name=="stamp2"){
						faill.PlayOneShot(fail);
						getTarget.transform.position = stamp2InitialPos;
				}

				if(getTarget.name=="stamp3"){
					float Distance = Vector3.Distance(getTarget.transform.position, passportPosition);
					if(Distance < 45){
						Debug.Log("u ifu sam)");
						getTarget.transform.position = passportPosition;
						Destroy(stamp3) ; 
						startTimer=true;
						jupii.PlayOneShot(win);

				//SceneManager.LoadScene(swichToScene);
					}
					else{
						Debug.Log("u elsu sam)");
						getTarget.transform.position = stamp3InitialPos;

					}
				}
			}
		}



        //Is mouse Moving
		if (isMouseDragging)
		{
            //tracking mouse position.
			Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z);

            //converting screen position to world position with offset changes.
			Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offsetValue;

            //It will update target gameobject's current postion.
			getTarget.transform.position = currentPosition;
		}
		if(startTimer){
			timeElapsed += Time.deltaTime;
			if(timeElapsed > delayAmount){
				Debug.Log("time sam)");
				SceneManager.LoadScene(swichToScene);
			}
		}

	}

    //Method to Return Clicked Object
	GameObject ReturnClickedObject(out RaycastHit hit)
	{
		GameObject target = null;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit))
		{
			if(hit.collider.gameObject.tag == "Selectable"){
				target = hit.collider.gameObject;
			}
		}
		return target;
	}


}