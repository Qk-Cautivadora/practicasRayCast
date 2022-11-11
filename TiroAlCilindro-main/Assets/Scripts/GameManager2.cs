using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public Material hitMaterial;
    public Material baseMaterial;
    bool clicked;
    // Update is called once per frame
    void Update()
    {
        if ((Input.touchCount >= 1 && Input.GetTouch(0).phase == TouchPhase.Ended) || (Input.GetMouseButtonUp(0)))
        {

            Vector3 pos = Input.mousePosition;

            Ray rayo = Camera.main.ScreenPointToRay(pos);
            RaycastHit hitInfo;
            if (Physics.Raycast(rayo, out hitInfo))
            {
                if (clicked != true)
                {
                    if (hitInfo.collider.tag.Equals("Cubo"))
                    {
                        LeanTween.scale(hitInfo.collider.gameObject, new Vector3(4f, 4f, 4f), 1f).setEase(LeanTweenType.easeInBounce);
                        clicked = true;
                        hitInfo.collider.GetComponent<MeshRenderer>().material = hitMaterial;

                    }
                }
                else
                {
                    if (hitInfo.collider.tag.Equals("Cubo"))
                    {
                        LeanTween.scale(hitInfo.collider.gameObject, new Vector3(1f, 1f, 1f), 1f).setEase(LeanTweenType.easeOutBounce);
                        clicked = false;
                        hitInfo.collider.GetComponent<MeshRenderer>().material = baseMaterial;

                    }
                }
            }
        }
    }
}
