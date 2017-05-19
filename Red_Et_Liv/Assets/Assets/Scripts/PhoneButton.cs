using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhoneButton : MonoBehaviour {
	public Dialogs Dialogs;
	private Color oldColor;
	private bool callReady;
	private float timer;
	private float timer2;

	void Start() {
		oldColor = this.gameObject.GetComponent<Renderer>().material.color;
		timer = 2;
		timer2 = 10;
	}

	void FixedUpdate() {
		if(Dialogs.dialogRunning == false && callReady == false) {
			timer -= Time.deltaTime;
			if(timer <= 0) {
				timer = 2;
				int rnd = Random.Range(0, 20);
				//UnityEngine.Debug.Log(rnd);
				if(rnd == 10) {
					callReady = true;
					this.gameObject.GetComponent<Renderer>().material.color = Color.green;
					// Let it stay on for 10-20secs
				}
			}
		}

		if(callReady == true) {
			timer2 -= Time.deltaTime;
			if(timer2 <= 0) {
				callReady = false;
				timer2 = 10;
				this.gameObject.GetComponent<Renderer>().material.color = oldColor;
			}
		}
	}

	void OnMouseOver() {
		if(Dialogs.dialogRunning == true) {
			this.gameObject.GetComponent<Renderer>().material.color = Color.red;
		} else {
			this.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
		}
	}

	void OnMouseExit() {
		if(callReady == true && Dialogs.dialogRunning == false) {
			this.gameObject.GetComponent<Renderer>().material.color = Color.green;
		} else {
			this.gameObject.GetComponent<Renderer>().material.color = oldColor;
		}	
	}

	void OnMouseDown() {
		if(callReady == true) {
			if(Dialogs.dialogRunning == false) {
				Dialogs.PickUpPhone();
			} else {
				Dialogs.PickUpPhone();
				callReady = false;
			}
		}
	}
}
