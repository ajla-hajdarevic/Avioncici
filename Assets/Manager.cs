using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject stamp1, stamp2, stamp3, passport;

    Vector3 stamp1InitialPos,stamp2InitialPos,stamp3InitialPos;

    void Start(){

    	stamp1InitialPos = stamp1.transform.position;
    	stamp2InitialPos = stamp2.transform.position;
    	stamp3InitialPos = stamp3.transform.position;

    }

    public void DragStamp1(){

    	stamp1.transform.position = Input.mousePosition;

    }

    public void DragStamp2(){
    	
    	stamp2.transform.position = Input.mousePosition;

    }

    public void DragStamp3(){
    	
    	stamp3.transform.position = Input.mousePosition;

    }

    public void DropStamp3(){
    	float Distance = Vector3.Distance(stamp3.transform.position, passport.transform.position);
    	if(Distance < 50){
    		Destroy(stamp3);
    	}
    	else{
    		stamp3.transform.position = stamp3InitialPos;
    	}
    }

     public void DropStamp2(){
    	float Distance = Vector3.Distance(stamp2.transform.position, passport.transform.position);
    	if(Distance < 50){
    		Destroy(stamp2);
    	}
    	else{
    		stamp2.transform.position = stamp2InitialPos;
    	}
    }

     public void DropStamp1(){
    	float Distance = Vector3.Distance(stamp1.transform.position, passport.transform.position);
    	if(Distance < 50){
    		Destroy(stamp1);
    	}
    	else{
    		stamp1.transform.position = stamp1InitialPos;
    	}
    }

    

} 
