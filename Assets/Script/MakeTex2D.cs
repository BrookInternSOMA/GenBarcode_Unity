using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using JinUtill;

public class MakeTex2D : MonoBehaviour
{
    [SerializeField]
    public enum BAR_ENC { None, CODE128 }


    private Texture2D BarTexture;
    private BarCodeAlgor m_barCodeAlgor;

    private int iWidthOfBar = 0;
    private int iBarEnc = (int)BAR_ENC.None;
    private int iBias = -90;


    public void InitialTex2D(BAR_ENC Enc)
    {
        int barWidth = -1;
        int resOKBarGen = -99;

        m_barCodeAlgor = new BarCodeAlgor();

        m_barCodeAlgor.CODE = "TaeJoong94";
        resOKBarGen = (int)m_barCodeAlgor.MakeBinOfCode();

        barWidth = m_barCodeAlgor.CalBitOfNum();


        BarTexture = new Texture2D(barWidth, 1);
        iWidthOfBar = barWidth;
        iBarEnc = (int)Enc;

        BarTexture.wrapMode = TextureWrapMode.Clamp;
        BarTexture.filterMode = FilterMode.Point;


        if(resOKBarGen == (int)CommonUtill.RESULT_CODE.Success)
            DrawCodeTexture();

    }

    public Texture2D GetTexture() { return BarTexture; }

    private void DrawCodeTexture()
    { 
        if (BarTexture == null)
            return;

        Color[] cols = BarTexture.GetPixels(0);

        int index = 0;
        for (int i = 0; i < m_barCodeAlgor.BinOfCodeList.Count; i++)
        {
            char[] strTempBin = m_barCodeAlgor.BinOfCodeList[i].ToCharArray();
            for (int j = 0; j < strTempBin.Length; j++)
            {
                if (strTempBin[j] == '1')
                    cols[index] = Color.black;
                else
                    cols[index] = Color.white;

                index++;
            }
        }


        BarTexture.SetPixels(cols, 0);

        BarTexture.Apply();
    }
}
