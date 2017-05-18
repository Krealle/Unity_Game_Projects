using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrambleDemWords : MonoBehaviour {
    private string word;
    public bool hardMode = false;
    private string wordScram;
    private int wordLenght;
    private int score;
    private char l1;
    private char l2;
    private char l3;
    private char l4;
    private char l5;
    private char l6;
    private char l7;
    private char l8;
    private char l9;
    private int rnd2;
    public Texture aTexture;
    public Texture[] ezTexture = new Texture[] { };
    public Texture[] hcTexture = new Texture[] { };
    public GUIStyle largeFont;
    public GUIStyle userStyle;
    public GUIStyle smallFont;
    public GUIStyle smallerFont;
    public Text userInput;
    public Text worderino;
    public Text scoreUser;
    public Text hitpoints;
    public RawImage helpWord;

	// Use this for initialization
	void Start() {
        score = 0;
        NextWord();
	}

    void NextWord() {
        WordChooser();
        WordPrepper();
        WordScrambler();
        userInput.text = "";
    }

    void WordChooser() {
        if (hardMode == false) {
            string[] ezMode = new string[] { "hus", "bil", "mand", "vand", "hals", "stol", 
                "mund", "hund", "kat", "hest", "ugle", "arm", "taske", "brev", "cola", 
                "pind", "sko", "kost", "hals", "avis", "mobil", "regn", "sand", "bus", 
                "spil", "bord", "hat", "lego", "mus" };
            rnd2 = Random.Range(0, ezMode.Length);
            word = ezMode[rnd2];
            helpWord.texture = ezTexture[rnd2];
        } else {
            string[] hcMode = new string[] { "elefant", "cirkus", "festival", "computer", "sodavand", "svaner", "stolben", 
                "hamster", "kamera", "tekster", "tivoli", "skumfidus", "doktor", 
                "hundehus", "kaffe", "marsvin", "giraf", "internet", "port", 
                "cookie", "fodbold", "leopard", "klasse", "flodhest", "banan", 
                "tastatur", "ballon", "madpakke" };
            rnd2 = Random.Range(0, hcMode.Length);
            word = hcMode[rnd2];
            helpWord.texture = hcTexture[rnd2];
        }
    }

    void WordPrepper() {
        wordLenght = word.Length;
        for (int i = 0; i < wordLenght; i++) {
            if (i == 0) {
                l1 = word[i];
                char[] chars = { l1 };
                wordScram = new string(chars);
            } else if (i == 1) {
                l2 = word[i];
                char[] chars = { l1, l2 };
                wordScram = new string(chars);
            } else if (i == 2) {
                l3 = word[i];
                char[] chars = { l1, l2, l3 };
                wordScram = new string(chars);
            } else if (i == 3) {
                l4 = word[i];
                char[] chars = { l1, l2, l3, l4 };
                wordScram = new string(chars);
            } else if (i == 4) {
                l5 = word[i];
                char[] chars = { l1, l2, l3, l4, l5 };
                wordScram = new string(chars);
            } else if (i == 5) {
                l6 = word[i];
                char[] chars = { l1, l2, l3, l4, l5, l6 };
                wordScram = new string(chars);
            } else if (i == 6) {
                l7 = word[i];
                char[] chars = { l1, l2, l3, l4, l5, l6, l7 };
                wordScram = new string(chars);
            } else if (i == 7) {
                l8 = word[i];
                char[] chars = { l1, l2, l3, l4, l5, l6, l7, l8 };
                wordScram = new string(chars);
            } else if (i == 8) {
                l9 = word[i];
                char[] chars = { l1, l2, l3, l4, l5, l6, l7, l8, l9 };
                wordScram = new string(chars);
            }
        }
    }

    void WordScrambler() {
        int rnd = Random.Range(0, 8);
        if (wordLenght == 3) {
            l1 = word[0];
            l2 = word[1];
            l3 = word[2];
        } else if (wordLenght == 4) {
            l1 = word[0];
            l2 = word[1];
            l3 = word[2];
            l4 = word[3];
        } else if (wordLenght == 5) {
            l1 = word[0];
            l2 = word[1];
            l3 = word[2];
            l4 = word[3];
            l5 = word[4];
        } else if (wordLenght == 6) {
            l1 = word[0];
            l2 = word[1];
            l3 = word[2];
            l4 = word[3];
            l5 = word[4];
            l6 = word[5];
        } else if (wordLenght == 7) {
            l1 = word[0];
            l2 = word[1];
            l3 = word[2];
            l4 = word[3];
            l5 = word[4];
            l6 = word[5];
            l7 = word[6];
        } else if (wordLenght == 8) {
            l1 = word[0];
            l2 = word[1];
            l3 = word[2];
            l4 = word[3];
            l5 = word[4];
            l6 = word[5];
            l7 = word[6];
            l8 = word[7];
        } else if (wordLenght == 9) {
            l1 = word[0];
            l2 = word[1];
            l3 = word[2];
            l4 = word[3];
            l5 = word[4];
            l6 = word[5];
            l7 = word[6];
            l8 = word[7];
            l9 = word[8];
        }
        
        if (rnd == 0) {
            if (wordLenght == 3) {
                char[] chars = { l1, l3, l2 };
                wordScram = new string(chars);
            } else if (wordLenght == 4) {
                char[] chars = { l4, l3, l2, l1 };
                wordScram = new string(chars);
            } else if (wordLenght == 5) {
                char[] chars = { l5, l3, l2, l1, l4 };
                wordScram = new string(chars);
            } else if (wordLenght == 6) {
                char[] chars = { l6, l3, l4, l2, l1, l5 };
                wordScram = new string(chars);
            } else if (wordLenght == 7) {
                char[] chars = { l6, l3, l5, l2, l4, l7, l1 };
                wordScram = new string(chars);
            } else if (wordLenght == 8) {
                char[] chars = { l5, l3, l1, l4, l6, l2, l8, l7 };
                wordScram = new string(chars);
            } else if (wordLenght == 9) {
                char[] chars = { l2, l3, l1, l6, l5, l7, l4, l5, l9 };
                wordScram = new string(chars);
            }
        } else if (rnd == 1) {
            if (wordLenght == 3) {
                char[] chars = { l3, l1, l2 };
                wordScram = new string(chars);
            } else if (wordLenght == 4) {
                char[] chars = { l3, l4, l2, l1 };
                wordScram = new string(chars);
            } else if (wordLenght == 5) {
                char[] chars = { l5, l4, l2, l1, l3 };
                wordScram = new string(chars);
            } else if (wordLenght == 6) {
                char[] chars = { l2, l3, l4, l6, l1, l5 };
                wordScram = new string(chars);
            } else if (wordLenght == 7) {
                char[] chars = { l6, l4, l5, l2, l3, l7, l1 };
                wordScram = new string(chars);
            } else if (wordLenght == 8) {
                char[] chars = { l5, l3, l8, l4, l6, l2, l1, l7 };
                wordScram = new string(chars);
            } else if (wordLenght == 9) {
                char[] chars = { l2, l9, l1, l6, l5, l7, l4, l5, l3 };
                wordScram = new string(chars);
            }
        } else if (rnd == 2) {
            if (wordLenght == 3) {
                char[] chars = { l2, l1, l3 };
                wordScram = new string(chars);
            } else if (wordLenght == 4) {
                char[] chars = { l3, l4, l1, l2 };
                wordScram = new string(chars);
            } else if (wordLenght == 5) {
                char[] chars = { l3, l4, l2, l1, l5 };
                wordScram = new string(chars);
            } else if (wordLenght == 6) {
                char[] chars = { l1, l3, l4, l6, l2, l5 };
                wordScram = new string(chars);
            } else if (wordLenght == 7) {
                char[] chars = { l6, l4, l7, l2, l3, l5, l1 };
                wordScram = new string(chars);
            } else if (wordLenght == 8) {
                char[] chars = { l4, l3, l8, l5, l6, l2, l1, l7 };
                wordScram = new string(chars);
            } else if (wordLenght == 9) {
                char[] chars = { l2, l9, l4, l6, l5, l7, l1, l5, l3 };
                wordScram = new string(chars);
            }
        } else if (rnd == 3) {
            if (wordLenght == 3) {
                char[] chars = { l2, l3, l1 };
                wordScram = new string(chars);
            } else if (wordLenght == 4) {
                char[] chars = { l2, l4, l1, l3 };
                wordScram = new string(chars);
            } else if (wordLenght == 5) {
                char[] chars = { l2, l4, l3, l1, l5 };
                wordScram = new string(chars);
            } else if (wordLenght == 6) {
                char[] chars = { l1, l3, l5, l6, l2, l4 };
                wordScram = new string(chars);
            } else if (wordLenght == 7) {
                char[] chars = { l2, l4, l7, l6, l3, l5, l1 };
                wordScram = new string(chars);
            } else if (wordLenght == 8) {
                char[] chars = { l4, l3, l1, l5, l6, l2, l8, l7 };
                wordScram = new string(chars);
            } else if (wordLenght == 9) {
                char[] chars = { l2, l9, l4, l3, l5, l7, l1, l5, l6 };
                wordScram = new string(chars);
            }
        } else if (rnd == 4) {
            if (wordLenght == 3) {
                char[] chars = { l3, l2, l1 };
                wordScram = new string(chars);
            } else if (wordLenght == 4) {
                char[] chars = { l2, l4, l3, l1 };
                wordScram = new string(chars);
            } else if (wordLenght == 5) {
                char[] chars = { l2, l4, l3, l5, l1 };
                wordScram = new string(chars);
            } else if (wordLenght == 6) {
                char[] chars = { l4, l3, l5, l6, l2, l1 };
                wordScram = new string(chars);
            } else if (wordLenght == 7) {
                char[] chars = { l5, l4, l7, l6, l3, l2, l1 };
                wordScram = new string(chars);
            } else if (wordLenght == 8) {
                char[] chars = { l4, l3, l7, l5, l6, l2, l8, l1 };
                wordScram = new string(chars);
            } else if (wordLenght == 9) {
                char[] chars = { l2, l9, l4, l3, l5, l7, l6, l5, l1 };
                wordScram = new string(chars);
            }
        } else if (rnd == 5) {
            if (wordLenght == 3) {
                char[] chars = { l2, l3, l1 };
                wordScram = new string(chars);
            } else if (wordLenght == 4) {
                char[] chars = { l3, l4, l2, l1 };
                wordScram = new string(chars);
            } else if (wordLenght == 5) {
                char[] chars = { l5, l4, l3, l2, l1 };
                wordScram = new string(chars);
            } else if (wordLenght == 6) {
                char[] chars = { l4, l6, l5, l3, l2, l1 };
                wordScram = new string(chars);
            } else if (wordLenght == 7) {
                char[] chars = { l5, l6, l7, l4, l3, l2, l1 };
                wordScram = new string(chars);
            } else if (wordLenght == 8) {
                char[] chars = { l4, l3, l7, l5, l6, l8, l2, l1 };
                wordScram = new string(chars);
            } else if (wordLenght == 9) {
                char[] chars = { l8, l9, l4, l3, l5, l7, l6, l2, l1 };
                wordScram = new string(chars);
            }
        } else if (rnd == 6) {
            if (wordLenght == 3) {
                char[] chars = { l2, l1, l3 };
                wordScram = new string(chars);
            } else if (wordLenght == 4) {
                char[] chars = { l4, l3, l2, l1 };
                wordScram = new string(chars);
            } else if (wordLenght == 5) {
                char[] chars = { l5, l2, l3, l4, l1 };
                wordScram = new string(chars);
            } else if (wordLenght == 6) {
                char[] chars = { l5, l6, l4, l3, l2, l1 };
                wordScram = new string(chars);
            } else if (wordLenght == 7) {
                char[] chars = { l7, l6, l5, l4, l3, l2, l1 };
                wordScram = new string(chars);
            } else if (wordLenght == 8) {
                char[] chars = { l4, l8, l7, l5, l6, l3, l2, l1 };
                wordScram = new string(chars);
            } else if (wordLenght == 9) {
                char[] chars = { l8, l9, l4, l6, l5, l7, l3, l2, l1 };
                wordScram = new string(chars);
            }
        } else if (rnd == 7) {
            if (wordLenght == 3) {
                char[] chars = { l2, l1, l3 };
                wordScram = new string(chars);
            } else if (wordLenght == 4) {
                char[] chars = { l4, l3, l1, l2 };
                wordScram = new string(chars);
            } else if (wordLenght == 5) {
                char[] chars = { l5, l2, l3, l1, l4 };
                wordScram = new string(chars);
            } else if (wordLenght == 6) {
                char[] chars = { l6, l5, l4, l3, l2, l1 };
                wordScram = new string(chars);
            } else if (wordLenght == 7) {
                char[] chars = { l2, l6, l5, l4, l3, l7, l1 };
                wordScram = new string(chars);
            } else if (wordLenght == 8) {
                char[] chars = { l6, l8, l7, l5, l4, l3, l2, l1 };
                wordScram = new string(chars);
            } else if (wordLenght == 9) {
                char[] chars = { l8, l9, l7, l6, l5, l4, l3, l2, l1 };
                wordScram = new string(chars);
            }
        } else if (rnd == 8) {
            if (wordLenght == 3) {
                char[] chars = { l2, l1, l3 };
                wordScram = new string(chars);
            } else if (wordLenght == 4) {
                char[] chars = { l2, l3, l1, l4 };
                wordScram = new string(chars);
            } else if (wordLenght == 5) {
                char[] chars = { l5, l1, l3, l2, l4 };
                wordScram = new string(chars);
            } else if (wordLenght == 6) {
                char[] chars = { l6, l5, l1, l3, l2, l4 };
                wordScram = new string(chars);
            } else if (wordLenght == 7) {
                char[] chars = { l2, l3, l5, l4, l6, l7, l1 };
                wordScram = new string(chars);
            } else if (wordLenght == 8) {
                char[] chars = { l7, l8, l6, l5, l4, l3, l2, l1 };
                wordScram = new string(chars);
            } else if (wordLenght == 9) {
                char[] chars = { l9, l8, l7, l6, l5, l4, l3, l2, l1 };
                wordScram = new string(chars);
            }
        }
        //randomly mix the word
        Debug.Log(word);
        worderino.text = wordScram.ToUpper();
    }

    void userInputChange() {
        if (Input.GetKeyDown(KeyCode.Backspace)) {
            if (userInput.text.Length > 0) {
                userInput.text = userInput.text.Substring(0, userInput.text.Length - 1);
            }
        } else if (Input.GetKeyDown(KeyCode.A)) {
            userInput.text = userInput.text + "A";
        } else if (Input.GetKeyDown(KeyCode.B)) {
            userInput.text = userInput.text + "B";
        } else if (Input.GetKeyDown(KeyCode.C)) {
            userInput.text = userInput.text + "C";
        } else if (Input.GetKeyDown(KeyCode.D)) {
            userInput.text = userInput.text + "D";
        } else if (Input.GetKeyDown(KeyCode.E)) {
            userInput.text = userInput.text + "E";
        } else if (Input.GetKeyDown(KeyCode.F)) {
            userInput.text = userInput.text + "F";
        } else if (Input.GetKeyDown(KeyCode.G)) {
            userInput.text = userInput.text + "G";
        } else if (Input.GetKeyDown(KeyCode.H)) {
            userInput.text = userInput.text + "H";
        } else if (Input.GetKeyDown(KeyCode.I)) {
            userInput.text = userInput.text + "I";
        } else if (Input.GetKeyDown(KeyCode.J)) {
            userInput.text = userInput.text + "J";
        } else if (Input.GetKeyDown(KeyCode.K)) {
            userInput.text = userInput.text + "K";
        } else if (Input.GetKeyDown(KeyCode.L)) {
            userInput.text = userInput.text + "L";
        } else if (Input.GetKeyDown(KeyCode.M)) {
            userInput.text = userInput.text + "M";
        } else if (Input.GetKeyDown(KeyCode.N)) {
            userInput.text = userInput.text + "N";
        } else if (Input.GetKeyDown(KeyCode.O)) {
            userInput.text = userInput.text + "O";
        } else if (Input.GetKeyDown(KeyCode.P)) {
            userInput.text = userInput.text + "P";
        } else if (Input.GetKeyDown(KeyCode.Q)) {
            userInput.text = userInput.text + "Q";
        } else if (Input.GetKeyDown(KeyCode.R)) {
            userInput.text = userInput.text + "R";
        } else if (Input.GetKeyDown(KeyCode.S)) {
            userInput.text = userInput.text + "S";
        } else if (Input.GetKeyDown(KeyCode.T)) {
            userInput.text = userInput.text + "T";
        } else if (Input.GetKeyDown(KeyCode.U)) {
            userInput.text = userInput.text + "U";
        } else if (Input.GetKeyDown(KeyCode.V)) {
            userInput.text = userInput.text + "V";
        } else if (Input.GetKeyDown(KeyCode.W)) {
            userInput.text = userInput.text + "W";
        } else if (Input.GetKeyDown(KeyCode.X)) {
            userInput.text = userInput.text + "X";
        } else if (Input.GetKeyDown(KeyCode.Y)) {
            userInput.text = userInput.text + "Y";
        } else if (Input.GetKeyDown(KeyCode.Z)) {
            userInput.text = userInput.text + "Z";
        }
    }
	
	// Update is called once per frame
	void Update() {
        WordChecker();
        userInputChange();
	}

    void WordChecker() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            if (userInput.text == word.ToUpper()) {
                Debug.Log("Correct!");
                score++;
                scoreUser.text = "POINT:"  + score;
                NextWord();
            } else {
                Debug.Log("Wrong!");
                hitpoints.text = hitpoints.text.Substring(0, hitpoints.text.Length - 1);
                if (hitpoints.text.Length <= 0) {
                    Application.LoadLevel(0);
                }
                userInput.text = "";
            }
        }
    }
}
