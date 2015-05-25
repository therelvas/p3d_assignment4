using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelectScreenScript : MonoBehaviour {
	public InputField playerNameField;
	// Use this for initialization
	void Start () {
	}
	
	public void LevelOnePressed (){
		Application.LoadLevel (1);
		Globals.playerName = playerNameField.text;
	}

    public void LevelTwoPressed()
    {
        Application.LoadLevel(1);
		Globals.playerName = playerNameField.text;
    }

    public void BackPressed(){
        Application.LoadLevel(0);
    }
}
