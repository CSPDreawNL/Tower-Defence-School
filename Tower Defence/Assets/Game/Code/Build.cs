using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    public GameObject Tower;
    public int Kosten;
    private bool m_AlreadyBuilt;

    private void OnMouseUpAsButton()
    {
        if (GameManager.instance.Currency < 10 || m_AlreadyBuilt)
            return;
        GameManager.instance.ModifyCurrency(-Kosten);
        m_AlreadyBuilt = true;
        GetComponent<MeshRenderer>().material.color -= Color.white;
        Instantiate(Tower, transform.position + Vector3.up + new Vector3(1f, -0.4f, -0.5f), Quaternion.identity);
    }

    private void OnMouseEnter()
    {
        GetComponent<MeshRenderer>().material.color += Color.white;
    }

    private void OnMouseExit()
    {
        GetComponent<MeshRenderer>().material.color -= Color.white;
    }
}
