using UnityEngine;
using System.Collections;

public class DialogBase : ScriptableObject 
{

    [TextArea(3,10)]
    public string dialogText = "Dialog placeholder #";
    public DialogBase[] nextDialogs;
    [TextArea(3,10)]
    public string[] questions;
    // public EventBase[] events;
    public EventIDs[] events;
    public DialogBase[] callBackDialog;
    public AudioClip soundClip;
    
    public bool IsMultipleChoice() {
        return nextDialogs.Length > 1;
    }

}

public enum EventIDs
{
	None,
	EndPhoneCall,
	HappyOption,
	SadOption,
	NeutralOption,
	HasCalled,
}