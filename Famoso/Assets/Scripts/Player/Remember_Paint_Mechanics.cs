using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remember_Paint_Mechanics : MonoBehaviour
{
    public LayerMask targetLayer;
    public MO_TextureController MO_TextureController;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, targetLayer))
            {
                MO_TextureController.saveTexture(hit.collider.gameObject);
            }
        }
    }
}
