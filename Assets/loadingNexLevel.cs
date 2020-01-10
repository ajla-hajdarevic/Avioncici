using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadingNexLevel : MonoBehaviour
{
    // Start is called before the first frame update
      public void loadLevel2()
  {
  	SceneManager.LoadScene("Level02");
  	  	//Debug.Log("LEVEL2!");

  }
}
