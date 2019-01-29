using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTextureFromQuad : MonoBehaviour
{

    private GameObject m_Quad;
    private GameObject m_CurrQuad;
    private MeshRenderer m_MeshRenderer;

    private MakeTex2D m_MakeTex2D;


    [SerializeField]
    public GameObject CurrQuad { set{ m_CurrQuad = value; } get { return m_CurrQuad; } }


    private void Awake()
    {
       
    }


    private void Start()
    {

    }
    // Start is called before the first frame update
    public void InitialQuad()
    {
        if (m_CurrQuad == null)
            Debug.Log("not setting Quad");
        else
        {
            m_MeshRenderer = m_CurrQuad.gameObject.GetComponent<MeshRenderer>();

            m_MakeTex2D = new MakeTex2D();
            m_MakeTex2D.InitialTex2D(100, MakeTex2D.BAR_ENC.CODE128);

            m_MeshRenderer.material.mainTexture = m_MakeTex2D.GetTexture();
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }





}
