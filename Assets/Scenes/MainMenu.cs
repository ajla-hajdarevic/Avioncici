using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void playButton()
  {
  	SceneManager.LoadScene("Level01");
  }

     public void loadLevel2()
  {
  	SceneManager.LoadScene("Level02");
  	  	//Debug.Log("LEVEL2!");

  }

     public void loadLevel3()
  {
  	SceneManager.LoadScene("Level03");
  	  	//Debug.Log("LEVEL2!");

  }

  public void loadLevel4()
  {
  	SceneManager.LoadScene("Level04");
  	  	//Debug.Log("LEVEL2!");

  }

  public void quitButton()
  {
  	Debug.Log("QUIT!");
    Application.Quit();

  }
}
