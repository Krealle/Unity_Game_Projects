using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {

    public int destroyDistance = 10;
    public GameObject Enemy;

	void Start () {
        
    }

	void Update () {
            Enemy = GameObject.FindGameObjectWithTag("Enemy");
            float dist = Vector3.Distance(Enemy.transform.position, transform.position);
            if (dist > destroyDistance && transform.position.x < Enemy.transform.position.x) {
                Destroy(gameObject);
            }
        
	}
}
