using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartScreenScript : MonoBehaviour {
	public Button playBtn;
    public Canvas quitMenu;

	// Use this for initialization
	void Start () {
		playBtn = playBtn.GetComponent<Button> ();
        quitMenu = quitMenu.GetComponent<Canvas>();
        quitMenu.enabled = false;
	}
	
	public void StartPressed (){
		Application.LoadLevel (1);
	}

    public void QuitPressed(){
        quitMenu.enabled = true;
    }

    public void NoPressed(){
        quitMenu.enabled = false;
    }

    public void YesPressed(){
        Application.Quit();
    }
}
