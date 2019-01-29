using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTex2D : MonoBehaviour
{
    [SerializeField]
    public enum BAR_ENC { None, CODE128 }


    private Texture2D barTexture;
    private int iWidthOfBar = 0;
    private int iBarEnc = (int)BAR_ENC.None;
    // Start is called before the first frame update
    

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitialTex2D(int Width, BAR_ENC Enc)
    {
        barTexture = new Texture2D(Width, 1);
        iWidthOfBar = Width;
        iBarEnc = (int)Enc;

        barTexture.wrapMode = TextureWrapMode.Clamp;
        barTexture.filterMode = FilterMode.Point;
        SetPixelsTexture();


    }

    public Texture2D GetTexture() { return barTexture; }


    private void SetPixelsTexture()
    { 
        if (barTexture == null)
            return;

        Color[] cols = barTexture.GetPixels(0);
        for (int i = 0; i < cols.Length; ++i)
        {
            int randNumm = Random.Range(1, 10);
            if (i % randNumm  == 0)
                cols[i] = Color.black;
            else
                cols[i] = Color.white;
        }


        barTexture.SetPixels(cols, 0);

        barTexture.Apply();
    }
}
