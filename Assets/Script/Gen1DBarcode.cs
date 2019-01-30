using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gen1DBarcode : MonoBehaviour
{

    public GameObject QuadOfBarcode;

    private SetTextureFromQuad m_SetTexture = new SetTextureFromQuad();

   
    private void Start()
    {
        if (QuadOfBarcode != null)
        {
            m_SetTexture.CurrQuad = QuadOfBarcode;
            m_SetTexture.InitialQuad();

        } 
    }

}
