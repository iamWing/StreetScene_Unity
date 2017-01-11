using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class SetOnFire : MonoBehaviour {

    [SerializeField] private GameObject m_finalTrigger;
    private PlayScript m_obj1, m_obj2, m_objFinal;
    private Canvas m_canvas;
    private ParticleSystem m_particle;
    private FirstPersonController m_controller;

	// Use this for initialization
	void Start () {
        m_obj1 = GameObject.Find("InHall").GetComponent<PlayScript>();
        m_obj2 = GameObject.Find("Locked&Empty").GetComponent<PlayScript>();
        m_objFinal = m_finalTrigger.GetComponent<PlayScript>();

        m_canvas = GameObject.Find("HUDCanvas").GetComponent<Canvas>();
        m_controller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        m_particle = GetComponent<ParticleSystem>();


        m_canvas.enabled = false;
	}

	// Update is called once per frame
	void Update () {
        if (m_obj1.played && m_obj2.played) {
            m_finalTrigger.SetActive(true);
        }

        if (m_objFinal.played) {
            m_particle.Play();

            Invoke("GameOver", 5);
        }
	}

    void GameOver() {
        m_canvas.enabled = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        m_controller.enabled = false;

        Invoke("Exit", 10);
    }

    void Exit() {
        Application.Quit();
    }
}
