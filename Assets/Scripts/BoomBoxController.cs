﻿using UnityEngine;
using System.Collections;

public class BoomBoxController : MonoBehaviour
{
	protected AudioSource ObjectAudioSource;
	public AudioClip ExplosionSound;
	public AudioClip NormalMusic;
	public AudioClip CrazyMusic;
	public GameObject Explosion;

	void Start()
	{
		ObjectAudioSource = GetComponent<AudioSource>();
	}

    void Update ()
    {
        if (gameObject.transform.localPosition.y < -5)
        {
            gameObject.SetActive(false);
        }
    }

	public void ChangeToNormalMusic()
	{
		ObjectAudioSource.clip = NormalMusic;
		ObjectAudioSource.Play();
	}

	public void ChangeToCrazyMusic()
	{
		ObjectAudioSource.clip = CrazyMusic;
		ObjectAudioSource.Play();
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "TableObjectPrefab(Clone)")
		{
			ObjectAudioSource.clip = ExplosionSound;
			Instantiate(Explosion, transform.position, transform.rotation);
            gameObject.SetActive(false);
		}
	}
}
