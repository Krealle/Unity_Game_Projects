using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MusicSlider : MonoBehaviour {
    public Slider musicSlider;
    public Slider effectSlider;
    public Text musicText;
    public Text effectText;
    private AudioSource audioSource;
    public AudioSource effectSound;
    private float roundedval;

	void Start () {
        musicSlider.value = 0.1f;
        effectSlider.value = 1;
        audioSource = gameObject.GetComponent<AudioSource>();
	}
	
	void Update () {
        audioSource.volume = musicSlider.value;
        effectSound.volume = effectSlider.value;
        roundedval = Mathf.Round(musicSlider.value * 100) / 100;
        musicText.text = "" + roundedval;
        roundedval = Mathf.Round(effectSlider.value * 100) / 100;
        effectText.text = "" + roundedval;
	}
}
