
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class koferDragDrop : MonoBehaviour
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
	private int counter = 6;

	public GameObject plavi1, plavi2, zuti1, zuti2, crveni1, crveni2, zutibox, plavibox, crvenibox; 
    //Initialize Variables
	GameObject getTarget;
	bool isMouseDragging;
	Vector3 offsetValue;
	Vector3 positionOfScreen;
	Vector3 plavi1Position, plavi2Position, zuti1Position, zuti2Position, crveni1Position, crveni2Position, zutiboxPosition, plaviboxPosition, crveniboxPosition;


    // Use this for initialization 
	void Start()
	{

		jupii = GetComponent<AudioSource>();

		plavi1Position = plavi1.transform.position;
		plavi2Position = plavi2.transform.position;
		zuti1Position = zuti1.transform.position;
		zuti2Position = zuti2.transform.position;
		crveni1Position = crveni1.transform.position;
		crveni2Position = crveni2.transform.position;
		zutiboxPosition = zutibox.transform.position;
		plaviboxPosition = plavibox.transform.position;
		crveniboxPosition = crvenibox.transform.position;
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
				if(getTarget.name=="plavi1"){
					float Distance = Vector3.Distance(getTarget.transform.position, plaviboxPosition);
					if(Distance < 25){
						counter = counter - 1;;

						Debug.Log("u ifu sam)");
						getTarget.transform.position = plaviboxPosition;
					    jupii.PlayOneShot(win);
					    Destroy(getTarget);


					}
					else{
						Debug.Log("u elsu sam)");

						getTarget.transform.position = plavi1Position;
						jupii.PlayOneShot(fail);

					}
				}

				if(getTarget.name=="plavi2"){
					float Distance = Vector3.Distance(getTarget.transform.position, plaviboxPosition);
					if(Distance < 10){
						counter = counter - 1;;
						Debug.Log("u ifu sam)");
						getTarget.transform.position = plaviboxPosition;
						jupii.PlayOneShot(win);
						Destroy(getTarget);

					}
					else{
						Debug.Log("u elsu sam)");
					 jupii.PlayOneShot(fail);
						getTarget.transform.position = plavi2Position;

					}
				}


				if(getTarget.name=="crveni1"){
					float Distance = Vector3.Distance(getTarget.transform.position, crveniboxPosition);
					if(Distance < 55){
												counter = counter - 1;;

						Debug.Log("u ifu sam)");
						getTarget.transform.position = crveniboxPosition;
						    			jupii.PlayOneShot(win);
						    			Destroy(getTarget);


					}
					else{
						Debug.Log("u elsu sam)");

						getTarget.transform.position = crveni1Position;
					jupii.PlayOneShot(fail);


					}
				}

				if(getTarget.name=="crveni2"){
					float Distance = Vector3.Distance(getTarget.transform.position, crveniboxPosition);
					if(Distance < 50){
												counter = counter - 1;;

						Debug.Log("u ifu sam)");
						getTarget.transform.position = crveniboxPosition;
						    			jupii.PlayOneShot(win);
						    			Destroy(getTarget);


					}
					else{
						Debug.Log("u elsu sam)");

						getTarget.transform.position = crveni2Position;
						jupii.PlayOneShot(fail);


					}
				}

				if(getTarget.name=="zuti1"){
					float Distance = Vector3.Distance(getTarget.transform.position, zutiboxPosition);
					if(Distance < 50){
						
						counter = counter - 1;;
						Debug.Log("u ifu sam)");
						getTarget.transform.position = zutiboxPosition;
						jupii.PlayOneShot(win);
						Destroy(getTarget);


					}
					else{
						Debug.Log("u elsu sam)");
						getTarget.transform.position = zuti1Position;
						jupii.PlayOneShot(fail);


					}
				}
				if(getTarget.name=="zuti2"){
					float Distance = Vector3.Distance(getTarget.transform.position, zutiboxPosition);
					if(Distance < 50){
						counter = counter - 1;;
						Debug.Log("u ifu sam)");
						getTarget.transform.position = zutiboxPosition;
						jupii.PlayOneShot(win);
						Destroy(getTarget);


					}
					else{
						Debug.Log("u elsu sam)");
						getTarget.transform.position = zuti2Position;
						jupii.PlayOneShot(fail);


					}
				}

			}



		}

		if(counter == 0){
			timeElapsed += Time.deltaTime;
			if(timeElapsed > delayAmount){
				Debug.Log("time sam)");

				SceneManager.LoadScene(swichToScene);
			}
		}

        //Is mouse Moving
		if (isMouseDragging)
		{

			//tracking mouse position.
			Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z );

            //converting screen position to world position with offset changes.
			Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offsetValue;

            //It will update target gameobject's current postion.
            if(getTarget != null){
            	getTarget.transform.position = currentPosition;
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