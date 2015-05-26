using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelectScreenScript : MonoBehaviour {
	public InputField playerNameField;
	public Canvas loadingPanel;

	// Use this for initialization
	void Start () {
		loadingPanel.enabled = false;
	}
	
	public void LevelOnePressed (){
		loadingPanel.enabled = true;
		Application.LoadLevel (1);
		Globals.playerName = playerNameField.text != ""? playerNameField.text: "Player 1";
	}

    public void LevelTwoPressed(){
		loadingPanel.enabled = true;
        Application.LoadLevel(1);
		Globals.playerName = playerNameField.text;
    }

    public void BackPressed(){
        Application.LoadLevel(0);
    }
}
