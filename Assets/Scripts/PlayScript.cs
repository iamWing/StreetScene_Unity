using UnityEngine;
using System.Collections;

public class PlayScript : MonoBehaviour {

    private AudioSource m_source;
    internal bool played = false;

    [SerializeField]
    private AudioClip m_clip;

	// Use this for initialization
	void Start () {
        m_source = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider other) {
        if (!played) {
            m_source.PlayOneShot(m_clip);
            played = true;
        }
    }
}

