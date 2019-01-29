using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gen1DBarcode : MonoBehaviour
{

    public GameObject QuadOfBarcode;

    private SetTextureFromQuad m_SetTexture = new SetTextureFromQuad();

    // Start is called before the first frame update
    void Start()
    {
        if (QuadOfBarcode != null)
        {
            m_SetTexture.CurrQuad = QuadOfBarcode;
            m_SetTexture.InitialQuad();

        } 

    }

    // Update is called once per frame
    void Update()
    {

    }
}
