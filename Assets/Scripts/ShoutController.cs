using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShoutController : MonoBehaviour {

    public AudioClip[] audioClips;
    public string[] audioClipNames;

    protected AudioSource audioSource;
    protected Text textField;

	// Use this for initialization
	void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
        textField = gameObject.transform.GetChild(0).GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlayAnimation ()
    {
        gameObject.SetActive(true);
        gameObject.GetComponent<Animation>().Play();
        PlayAudio();
    }

    public void PlayAudio ()
    {
        var index = UnityEngine.Random.Range(0, 10);
        audioSource.PlayOneShot(audioClips[index], 1);
        textField.text = audioClipNames[index];
    }
}
