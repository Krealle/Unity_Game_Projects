using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelGenerator : MonoBehaviour {

    public GameObject[] obj;
    public Vector3 pos = new Vector3(-4, 0, 0);
    public Vector3 pos2;
    private Vector3 dir = Vector3.right;
    public float spawnTime = 1f;
    public float size = 0.3f;
    public GameObject[] player1;
    public int generateDist = 30;
    private GameObject test;
    public GameObject powerup;
    private int powerupChance;
    private int lastPowerupChance;

	void Start () {
        pos2 = pos;
        lastPowerupChance = 0;
	}

    void Update () {
        if (Application.loadedLevel == 1) {
            player1 = GameObject.FindGameObjectsWithTag("Player");
            if (pos.x < player1[0].transform.position.x + generateDist) {
                test = obj[Random.Range(0, obj.Length)];
                pos2.y = Random.Range(3, 11);
                Instantiate(test, pos, Quaternion.identity);
                Instantiate(powerup, pos2, Quaternion.identity);
                pos += dir * size;
                pos2.x = pos.x;
            }
        } else if (Application.loadedLevel == 0) {
            player1 = GameObject.FindGameObjectsWithTag("Enemy");
            if (pos.x < player1[0].transform.position.x + generateDist) {
                test = obj[Random.Range(0, obj.Length)];
                Instantiate(test, pos, Quaternion.identity);
                pos += dir * size;
                pos2.x = pos.x;
            }
        }
    }
}
