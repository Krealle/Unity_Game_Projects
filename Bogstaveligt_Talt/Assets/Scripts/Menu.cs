using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartGame() {
        Application.LoadLevel(1);
    }
    public void StartGameEz() {
        Application.LoadLevel(2);
    }
    public void MainMenu() {
        Application.LoadLevel(0);
    }
    public void CloseGame() {
        Application.Quit();
    }
}
