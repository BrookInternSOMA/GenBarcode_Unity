using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gen1DBarcode : MonoBehaviour
{

    private SetTextureFromQuad m_SetTexture = new SetTextureFromQuad();


    public GameObject QuadOfBarcode;



   
    private void Start()
    {
        if (QuadOfBarcode != null)
        {
            m_SetTexture.CurrQuad = QuadOfBarcode;
            m_SetTexture.InitialQuad();

        } 
    }

    public void ChangeBarCode(string code)
    {
        m_SetTexture.InitialQuad(code);
    }


}
