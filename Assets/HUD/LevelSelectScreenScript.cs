using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelectScreenScript : MonoBehaviour {
	public InputField name;
	// Use this for initialization
	void Start () {
	}
	
	public void LevelOnePressed (){
		Application.LoadLevel (1);
		Globals.playerName = name.text;
	}

    public void LevelTwoPressed()
    {
        Application.LoadLevel(1);
		Globals.playerName = name.text;
    }

    public void BackPressed(){
        Application.LoadLevel(0);
    }
}
