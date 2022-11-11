using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Material hitMaterial;
    public AudioClip shotSound;
    public AudioClip lataSound;
    private AudioSource gunAudioSource;
    private AudioSource lataAudioSource;
    [SerializeField]
    TextMeshProUGUI puntuacion;
    int puntos;
    void Awake()
    {
        gunAudioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {

            if ((Input.touchCount >= 1 && Input.GetTouch(0).phase == TouchPhase.Ended) || (Input.GetMouseButtonUp(0)))
            {
                gunAudioSource.PlayOneShot(shotSound);
                Vector3 pos = Input.mousePosition;
                if (Application.platform == RuntimePlatform.Android)
                {
                    pos = Input.GetTouch(0).position;
                }

                Ray rayo = Camera.main.ScreenPointToRay(pos);
                RaycastHit hitInfo;
                if (Physics.Raycast(rayo, out hitInfo))
                {
                if (hitInfo.collider.tag.Equals("Lata"))
                {
                    Rigidbody rigidbodyLata = hitInfo.collider.GetComponent<Rigidbody>();
                    rigidbodyLata.AddForce(rayo.direction * 50f, ForceMode.VelocityChange);
                    hitInfo.collider.GetComponent<MeshRenderer>().material = hitMaterial;
                    rigidbodyLata.detectCollisions = false;
                    lataAudioSource.PlayOneShot(lataSound);
                    puntos += 10;

                }
                else puntos -= 5;
                if (hitInfo.collider == null) puntos -= 5;


                    if (puntos <= 0) puntos = 0;
                }

            }
        puntuacion.text = "Puntos: " + puntos.ToString();

    }
}
