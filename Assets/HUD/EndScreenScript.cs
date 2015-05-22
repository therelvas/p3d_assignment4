using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndScreenScript : MonoBehaviour {
    public Canvas leaderboardMenu;
    public Canvas quitMenu;

	// Use this for initialization
	void Start () {
        //leaderboardMenu = leaderboardMenu.GetComponent<Canvas>();

        leaderboardMenu.enabled = false;
        leaderboardMenu.enabled = true;
        quitMenu.enabled = false;
	}
	
	public void PlayPressed (){
		Application.LoadLevel (2);
	}

    public void QuitPressed(){
        quitMenu.enabled = true;
    }

    public void ClosePressed(){
        leaderboardMenu.enabled = false;
    }

    public void NoPressed()
    {
        quitMenu.enabled = false;
    }

    public void YesPressed(){
        Application.Quit();
    }
}
