using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelectScreenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	public void LevelOnePressed (){
		Application.LoadLevel (1);
	}

    public void LevelTwoPressed()
    {
        Application.LoadLevel(1);
    }

    public void BackPressed(){
        Application.LoadLevel(0);
    }
}
