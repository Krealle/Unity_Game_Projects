using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Dialogs : MonoBehaviour
{

    private int buttonPressed;
    private DialogBase currentDialog;
    public DialogManager dialogManager;
    public Text[] questionTexts;
    public Text dialogTextUI;
    public Canvas dialogCanvas;
    public Canvas phoneCanvas;
    public Text timerText;
    public bool dialogRunning;
    public Slider dialogTimer;
    public Slider sanityMeter;
    public Text sanityText;
    private Color boxColor;
    private int timesCalled;
    private bool hasCalledBool;
    private bool fuckingHellM8;
    public AudioSource dialogSpeaker;
    public AudioSource musicSpeaker;
    public AudioSource buttonSpeaker;
    public CameraControl CameraControl;

    void Start() {
        dialogRunning = false;
        dialogCanvas.enabled = false;
        phoneCanvas.enabled = true;
        boxColor = Color.white;
        sanityMeter.value = sanityMeter.maxValue;
    }

    public void ButtonPress(int whichButton) {
        buttonSpeaker.Play();
        if (dialogRunning == true) {
            NextDialog(whichButton);
            if (dialogTimer.value < dialogTimer.maxValue - 15) {
                dialogTimer.value += 15;
            } else {
                dialogTimer.value = dialogTimer.maxValue;
            }
        }
        else {
            return;
        }
    }

    void FixedUpdate(){
        for (int i = 0; i < questionTexts.Length; i++) {
            if(!dialogSpeaker.isPlaying) {
                musicSpeaker.volume = 0.2f;
                questionTexts[i].transform.parent.GetComponent<Button>().interactable = true;
            } else {
                musicSpeaker.volume = 0.1f;
                questionTexts[i].transform.parent.GetComponent<Button>().interactable = false;
            }
        }
        
        if (dialogRunning == true && !dialogSpeaker.isPlaying) {
            dialogTimer.value -= Time.deltaTime;
            if (dialogTimer.value <= 0) {
                EndPhoneCall();
            }
        }
        if(sanityMeter.value <= 0) {
            // doSomeShit();
            EndPhoneCall();
        }
        sanityText.text = "Rolighed: " + sanityMeter.value + "/100";
        timerText.text = Mathf.Round(dialogTimer.value) + "/100";
    }

    public void PickUpPhone() {
        if (dialogRunning == true) {
            EndPhoneCall();
        }
        else {
            currentDialog = dialogManager.mainDialogs;
            int rnd = Random.Range(0, currentDialog.questions.Length);
            dialogRunning = true;
            //NextDialog(rnd);
            NextDialog(2);
            if(CameraControl.cameras[0].activeSelf == true) {
                dialogCanvas.enabled = true;
            }
            phoneCanvas.enabled = false;
            dialogTimer.value = dialogTimer.maxValue;
            fuckingHellM8 = true;
        }
    }

    public void EndPhoneCall() {
        Debug.Log("End Call");
        dialogRunning = false;
        dialogCanvas.enabled = false;
        phoneCanvas.enabled = true;
        currentDialog = dialogManager.mainDialogs;
        boxColor = Color.white;
        dialogSpeaker.Stop();
    }

    public void NextDialog(int selectedDialog) {
        if (currentDialog.events.Length > 0) {
            for (int i = 0; i < currentDialog.events.Length; i++) {                
                if (selectedDialog == i) {
                    if (currentDialog.events[i] != null) {
                        print(currentDialog.events[i].ToString());
                        CallEvent(currentDialog.events[i], currentDialog.name);
                    }
                    break;
                }
            }
        }

        /*  Vælger den næste dialog linje  */
        DialogBase oldDialog = currentDialog;
        DialogBase newDialog = oldDialog.nextDialogs[selectedDialog];
        /*  Hvis han ringer igen vælg anden dialog linje  */
        if(hasCalledBool == true && selectedDialog == 1 && fuckingHellM8 == true) {
            newDialog = dialogManager.callBackDialog[0]; 
            fuckingHellM8 = false;
        }
        currentDialog = newDialog;

        /*  DIALOG UI  */
        dialogTextUI.text = newDialog.dialogText;
        dialogTextUI.GetComponentInParent<Image>().color = boxColor;

        /*  AUDIO  */
        if(newDialog.soundClip != null) {
            dialogSpeaker.clip = newDialog.soundClip; // Change the audio clip for current dialog
            dialogSpeaker.Stop();
            dialogSpeaker.Play();
        }

        /*  ANSWERS UI  */
        for (int i = 0; i < questionTexts.Length; i++) {
            if (i < newDialog.questions.Length) {
                questionTexts[i].transform.parent.gameObject.SetActive(true);
                questionTexts[i].text = newDialog.questions[i];
            } else {
                questionTexts[i].transform.parent.gameObject.SetActive(false);
            }
        }
    }

    public void CallEvent(EventIDs eventID, string dialogName) {
        switch (eventID) {
            case EventIDs.None:
                boxColor = Color.white;
                break;
            case EventIDs.EndPhoneCall:
                TerminatePhoneCall();
                break;
            case EventIDs.HappyOption:
                HappyOption();
                break;
            case EventIDs.SadOption:
                SadOption();
                break;
            case EventIDs.NeutralOption:
                NeutralOption();
                break;
            case EventIDs.HasCalled:
                HasCalled();
                break;
            default:
                Debug.LogError("Event not set on: " + dialogName);
                break;
        }
    }

    void TerminatePhoneCall() {
        hasCalledBool = false;
    }

    void HasCalled() {
        hasCalledBool = true;
        dialogManager.callBackDialog = currentDialog.callBackDialog;
    }

    void HappyOption() {
        //boxColor = Color.green;
        sanityMeter.value += 5;
    }

    private void NeutralOption() {
        boxColor = Color.white;
        sanityMeter.value -= 1;
    }

    private void SadOption() {
        //boxColor = Color.red;
        sanityMeter.value -= 5;

    }
}
