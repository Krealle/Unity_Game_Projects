using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public Text highScoreText;

    private float timer;

	void Start () {
        highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("highscore", 0);
        timer = 0;
	}
	
	void Update () {
        timer += Time.deltaTime;
        if (timer > 2 && Input.anyKey) {
            Application.LoadLevel(0);
        }
	}
}
