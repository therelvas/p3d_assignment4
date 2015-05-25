using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndScreenScript : MonoBehaviour {
    public Canvas leaderboardMenu;
    public Canvas quitMenu;
	public Text messageLbl;
	public Text scoresLbl;


	// Use this for initialization
	void Start () {
        //leaderboardMenu = leaderboardMenu.GetComponent<Canvas>();
		ArrayList scores = new ArrayList(System.IO.File.ReadAllLines(@"scores.txt"));

		bool added = false;
		for(int i=0; i<scores.Count; i++)
			if(Globals.score > i){
				scores.Insert(i, Globals.playerName + "\t" + Globals.score);
				added = true;
			}
		if(!added)
			scores.Add(Globals.playerName + "\t" + Globals.score);

		System.IO.File.WriteAllLines(@"scores.txt", (string[])scores.ToArray(typeof(string)));
		messageLbl.text = Globals.endMessage;
		scoresLbl.text = "";
		foreach(string s in scores)
			scoresLbl.text += s+"\n";
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
