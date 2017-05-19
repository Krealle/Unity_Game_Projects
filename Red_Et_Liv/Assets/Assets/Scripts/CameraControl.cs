using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public GameObject[] cameras;
	public Canvas shitThatIsInTheWay;
	public Dialogs Dialogs;
	
	public void ChangeCamera () {
		if(cameras[0].activeSelf == true) {
			cameras[0].SetActive(false);
			cameras[1].SetActive(true);
			shitThatIsInTheWay.enabled = false;
		} else {
			cameras[0].SetActive(true);
			cameras[1].SetActive(false);
			if(Dialogs.dialogRunning == true) {
				shitThatIsInTheWay.enabled = true;
			}
		}
	}
}
