using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeRandomVar : MonoBehaviour
{


    private const int IMAGE_WIDTH = 256;
    private const int IMAGE_HEIGHT = 256;


    public int iWidthImg = 0;
    public int iHeightImg = 0;
    public bool bSaveFiles = true;

    public Vector3 vec3BoxPos;
    public Vector3 vec3BoxRot;

    public Vector3 vec3MainCamPos;
    public Vector3 vec3MainCamRot;

    public float fLightdth;

    public Vector3 vec3QuadSize;
    public Vector3 vec3QuadPos;



    public GameObject ObjLigth;
    public GameObject Box;
    public GameObject Cam;
    public GameObject Quad;
    public GameObject BarTextGen;



    private System.DateTime preT;
    private int iNumOfFiles = 0;
    private bool bStartMake = false;

    private ScreenShot m_ScreenShot;


    private UnityEngine.UI.Slider ObjRotSlider;
    private UnityEngine.UI.Slider ObjPosSlider;
    private UnityEngine.UI.Slider LightTenSlider;
    private UnityEngine.UI.Slider ColorTensiSlider;
    private UnityEngine.UI.Slider ColorRSlider;
    private UnityEngine.UI.Slider ColorGSlider;
    private UnityEngine.UI.Slider ColorBSlider;
    private UnityEngine.UI.Slider ColRandRSlider;
    private UnityEngine.UI.Slider ColRandGSlider;
    private UnityEngine.UI.Slider ColRandBSlider;
    private UnityEngine.UI.Slider CamXSlider;
    private UnityEngine.UI.Slider CamYSlider;
    private UnityEngine.UI.Slider CamZSlider;

    private void Awake()
    {
        m_ScreenShot = new ScreenShot();
        m_ScreenShot.resWidth = IMAGE_WIDTH;
        m_ScreenShot.resHeight = IMAGE_HEIGHT;

    }

    void Start()
    {
        preT = System.DateTime.Now;

        ObjRotSlider = GameObject.Find("ObjRotSlider").GetComponent<UnityEngine.UI.Slider>();
        ObjPosSlider = GameObject.Find("ObjPosSlider").GetComponent<UnityEngine.UI.Slider>();
        LightTenSlider = GameObject.Find("LightTensiSlider").GetComponent<UnityEngine.UI.Slider>();
        ColorTensiSlider = GameObject.Find("ColorTensiSlider").GetComponent<UnityEngine.UI.Slider>();
        ColorRSlider = GameObject.Find("ColorRSlider").GetComponent<UnityEngine.UI.Slider>();
        ColorGSlider = GameObject.Find("ColorGSlider").GetComponent<UnityEngine.UI.Slider>();
        ColorBSlider = GameObject.Find("ColorBSlider").GetComponent<UnityEngine.UI.Slider>();
        ColRandRSlider = GameObject.Find("ColRandRSlider").GetComponent<UnityEngine.UI.Slider>();
        ColRandGSlider = GameObject.Find("ColRandGSlider").GetComponent<UnityEngine.UI.Slider>();
        ColRandBSlider = GameObject.Find("ColRandBSlider").GetComponent<UnityEngine.UI.Slider>();
        CamZSlider = GameObject.Find("CamZSlider").GetComponent<UnityEngine.UI.Slider>();
        CamXSlider = GameObject.Find("CamXSlider").GetComponent<UnityEngine.UI.Slider>();
        CamYSlider = GameObject.Find("CamYSlider").GetComponent<UnityEngine.UI.Slider>();

    }
    


    void Update()
    {
        System.DateTime nowT = System.DateTime.Now;

        Camera.main.transform.position = new Vector3(CamXSlider.value, CamYSlider.value, CamZSlider.value);

        System.TimeSpan deltaT;
        deltaT = nowT - preT;
        if(bStartMake)
        {
            
            if (BarTextGen != null)
            {
                Gen1DBarcode tempObjOfScript = BarTextGen.gameObject.GetComponent<Gen1DBarcode>();
                tempObjOfScript.ChangeBarCode(((int)Random.Range(0,100000)).ToString());
            }

            Light tempLight = ObjLigth.gameObject.GetComponent<Light>();
            tempLight.intensity = Random.Range(0.2f, 1.2f) * LightTenSlider.value;


            float xPosBox = Random.Range(-1.0f, 1.0f) * ObjPosSlider.value;
            float yPosBox = Random.Range(-1.5f, 2f) * ObjPosSlider.value;
            float zPosBox = Random.Range(-0.7f, 5.2f) * ObjPosSlider.value;

            Box.transform.position = new Vector3(xPosBox, yPosBox, zPosBox);

            float xRotBox = Random.Range(0.2f, 360f) * ObjRotSlider.value;
            float yRotBox = Random.Range(-140f, -140f) * ObjRotSlider.value - 90;
            float zRotBox = Random.Range(-30.2f, 20.2f) * ObjRotSlider.value;

            Box.gameObject.transform.rotation =
                    Quaternion.Euler(xRotBox, yRotBox, zRotBox);


            float RColBox = Random.Range(0f, 1.5f) * ColorRSlider.value;

            MeshRenderer tempBoxRenderer = Box.gameObject.GetComponentInChildren<MeshRenderer>();
            tempBoxRenderer.material.SetColor("_Color", new Color(ColorRSlider.value * ColorTensiSlider.value * Random.Range(1.0f,ColRandRSlider.value),
                                                                    ColorGSlider.value * ColorTensiSlider.value * Random.Range(1.0f, ColRandGSlider.value),
                                                                    ColorBSlider.value * ColorTensiSlider.value * Random.Range(1.0f, ColRandBSlider.value)));

            Debug.Log(RColBox);



            preT = System.DateTime.Now;

            if(bSaveFiles)
                m_ScreenShot.Shot(iNumOfFiles.ToString());

            iNumOfFiles++;
        }
        

    }


    public void StartMakeBarcodeImg() { bStartMake = true; }
    public void StopMakeBarcodeImg()
    {
        bStartMake = false;
        ResetMakeBarcodeImg();
    }
    public void ResetMakeBarcodeImg()
    {
        iNumOfFiles = 0;
    }



}
