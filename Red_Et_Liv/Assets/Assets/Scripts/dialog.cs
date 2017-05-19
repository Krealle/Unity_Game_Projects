using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class dialog : MonoBehaviour {

    public Text box1T;
    public Text box2T;
    public Text box3T;
    public Text box4T;
    public Button box1B;
    public Button box2B;
    public Button box3B;
    public Button phone;
    public Canvas dialogMenu;
    public Canvas phoneCanvas;
    private int whichButton;
    private int i;
    private int qID;
    private int aID;
    private int rnd;
    private bool seqRan;
    private bool firstRun;
    private bool questionUp;
    string[][] currentDialog;
    string[][] listOfDialog;
    string[] dialogContent;
    string[][] listOfQuestions;
    string[] questionContent;

    //string[][] dialog1 = new string[][] { new string[] { "option1", "option2", "option3", "GOOD" }, new string[] { "option4", "option5", "option6", "BAD" } };
    string[][][] dialog2 = new string[][][] { 
        new string[][] { /* DIALOG 1 */
            new string[] {"0","Jeg spørger dig om noget!" }, 
            new string[] {"1", "Jeg spørger dig om noget andet!" },
            new string[] {"2","Jeg spørger dig om noget HELT andet!" } 
        },
        new string[][] { /* DIALOG 2 */
            new string[] { "option01", "option02", "option3", "BAD" }, 
            new string[] { "option04", "option05", "option06", "GOOD" } 
        },
        new string[][] { /* DIALOG 3 */
            new string [] { "option10", "option11", "option11", "GOOD" } 
        } 
    };
    string[][][] answers = new string[][][] { 
        new string[][] { /* Answer 1 */
            new string[] {"Choice 1", "1", "Choice 2", "1", "Choice 3", "1" }, 
            new string[] { "Choice 01", "2", "Choice 02", "2" },
            new string[] { "Choice 11", "3" } 
        },
        new string[][] { /* Answer 2 */
            new string[] { "option01", "option02", "option3", "BAD" }, 
            new string[] { "option04", "option05", "option06", "GOOD" } 
        },
        new string[][] { /* Answer 3 */
            new string [] { "option10", "option11", "option11", "GOOD" } 
        } 
    };

    void awesomeFunc() {
        listOfDialog = dialog2[0]; // LAV RNG :D
        listOfQuestions = answers[0]; // LAV RNG :D
        if (firstRun == true) {
            //dialogContent = listOfDialog[0];
            firstRun = false;
        }
        box4T.text = dialogContent[1];
        aID = int.Parse(dialogContent[0]);
        if(1 == 6) {

        }

        /************************************/
        questionContent = listOfQuestions[aID];
        dialogContent = listOfDialog[qID];
        


        if (questionUp == true && seqRan == false) {
            qID = int.Parse(questionContent[1]);
            questionUp = false;
            seqRan = true;

        } else if (questionUp == false && seqRan == false) {
            
            questionUp = true;
            seqRan = true;
        }
    }

	void Start () {
        i = 0;
        endPhoneCall();
        firstRun = true;
        aID = 0;
        qID = 0;
        questionUp = false;
	}

    void endPhoneCall() {
        phoneCanvas.enabled = true;
        dialogMenu.enabled = false;
    }

    public void pickupPhone() {
        dialogMenu.enabled = true;
        phoneCanvas.enabled = false;
        rnd = Random.Range(0, dialog2.Length);
        currentDialog = dialog2[rnd];
        awesomeFunc();
    }
	
	public void Box1Press () {
        whichButton = 1;
        awesomeFunc();
	}
    public void Box2Press() {
        whichButton = 2;
        awesomeFunc();
    }
    public void Box3Press() {
        whichButton = 3;
        awesomeFunc();
    }

    void buttonPress() {
        if (i + 1 > currentDialog.Length) {
            endPhoneCall();
            i = 0;
            return;
        }
        string[] curDialog = currentDialog[i];
        if (curDialog[3] == "GOOD") {
            //Debug.Log("good choice");
        } else if (curDialog[3] == "BAD") {
            //Debug.Log("bad choice");
        }
        box1T.text = curDialog[0];
        box2T.text = curDialog[1];
        box3T.text = curDialog[2];
        i++;
    }
}
