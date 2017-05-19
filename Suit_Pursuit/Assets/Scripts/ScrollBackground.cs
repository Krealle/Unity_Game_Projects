using UnityEngine;
using System.Collections;

public class ScrollBackground : MonoBehaviour {

    public float speed = 0.5f;
    public Renderer rend;
	void Start () {
	
	}
	
	void Update () {
        Vector2 offset = new Vector2(Time.time * speed, 0);

        rend = GetComponent<Renderer>();
        rend.material.mainTextureOffset = offset;
	}
}
