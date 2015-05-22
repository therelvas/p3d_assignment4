using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartScreenScript : MonoBehaviour {
    public Canvas quitMenu;

	// Use this for initialization
	void Start () {
        quitMenu = quitMenu.GetComponent<Canvas>();
        quitMenu.enabled = false;
	}
	
	public void StartPressed (){
		Application.LoadLevel (2);
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
