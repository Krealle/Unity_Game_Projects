using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MonitorButton : MonoBehaviour {

	public void ChangeSite(Canvas clickedCanvas) {
		clickedCanvas.enabled = true;
	}

	public void Disablesite(Canvas prevCanvas) {
		prevCanvas.enabled = false;
	}
}
