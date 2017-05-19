using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    private GameObject player;
    private Vector3 danielsPenis;

	void Start () {
        if (Application.loadedLevel == 1) {
            player = GameObject.FindGameObjectWithTag("Player");
            danielsPenis.x = player.transform.position.x;
            danielsPenis.y = player.transform.position.y;
            danielsPenis.z = -10;
        } else if (Application.loadedLevel == 0) {
            player = GameObject.FindGameObjectWithTag("Enemy");
            danielsPenis.x = player.transform.position.x;
            danielsPenis.y = player.transform.position.y;
            danielsPenis.z = -10;
        }
        
	}
	
	void Update () {
        danielsPenis.x = player.transform.position.x;
        transform.position = danielsPenis;
	}
}
