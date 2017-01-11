using UnityEngine;
using System.Collections;


public class SetOnFire : MonoBehaviour {

    [SerializeField] private GameObject m_finalTrigger;
    private PlayScript m_obj1, m_obj2, m_objFinal;
    private ParticleSystem m_particle;

	// Use this for initialization
	void Start () {
        m_obj1 = GameObject.Find("InHall").GetComponent<PlayScript>();
        m_obj2 = GameObject.Find("Locked&Empty").GetComponent<PlayScript>();
        m_objFinal = m_finalTrigger.GetComponent<PlayScript>();

        m_particle = GetComponent<ParticleSystem>();
	}

	// Update is called once per frame
	void Update () {
        if (m_obj1.played && m_obj2.played) {
            m_finalTrigger.SetActive(true);
        }

        if (m_objFinal.played) {
            m_particle.Play();
        }
	}
}
