using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class praviAvioni : MonoBehaviour
{


		public GameObject zuti1, zuti2;

    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {

    	if(zuti2.active == false && zuti1.active ==false){
    		SceneManager.LoadScene("endofGame");
    	}
        
    }
}
