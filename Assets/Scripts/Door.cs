using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    private bool m_isOpened = false;
    private bool m_trigger = false;
    public float doorOpenAngle = 90.0f;

    [SerializeField]
    private float m_speed = 2.0f;
    [SerializeField]
    private AudioClip m_openDoor;
    [SerializeField]
    private float m_openDoorVol = 1.0f;
    [SerializeField]
    private AudioClip m_closeDoor;
    [SerializeField] float m_closeDoorVol = 1.0f;

    private Transform m_transform;
    private AudioSource m_audioSource;
    private Vector3 m_defaultVector, m_targetVector;

    // Use this for initialization
    void Start() {
        m_transform = this.gameObject.transform;
        m_defaultVector = m_transform.eulerAngles;
        m_targetVector = new Vector3(m_defaultVector.x, m_defaultVector.y + doorOpenAngle, m_defaultVector.z);

        m_audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("e") && m_trigger) {
            m_isOpened = !m_isOpened;
            if (m_isOpened) {
                m_audioSource.PlayOneShot(m_openDoor, m_openDoorVol);
            } else {
                m_audioSource.PlayOneShot(m_closeDoor, m_closeDoorVol);
            }
        }

        if (m_isOpened) {
            m_transform.eulerAngles = Vector3.Slerp(m_transform.eulerAngles, m_targetVector, Time.deltaTime * m_speed);
        } else {
            m_transform.eulerAngles = Vector3.Slerp(m_transform.eulerAngles, m_defaultVector, Time.deltaTime * m_speed);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            m_trigger = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            m_trigger = false;
        }
    }

    void OnGUI() {
        if (m_trigger) {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height - 100, 200, 30), "Press \"E\" to open\\close the door");
        }
    }
}
