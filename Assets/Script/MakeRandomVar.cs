using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SFB;

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
    private int iNumOfCycle = 0;
    private bool bStartMake = false;
    private bool bStartFlage = false;
    private bool bCheckRandTogle = false;

    private ScreenShot m_ScreenShot;


    #region UI Slider Obj
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

    private UnityEngine.UI.Slider PosXRSlider;
    private UnityEngine.UI.Slider PosYRSlider;
    private UnityEngine.UI.Slider PosZRSlider;
    private UnityEngine.UI.Slider RoXRSlider;
    private UnityEngine.UI.Slider RoYRSlider;
    private UnityEngine.UI.Slider RoZRSlider;

    private UnityEngine.UI.Slider PosXRSlider2;
    private UnityEngine.UI.Slider PosYRSlider2;
    private UnityEngine.UI.Slider PosZRSlider2;
    private UnityEngine.UI.Slider RoXRSlider2;
    private UnityEngine.UI.Slider RoYRSlider2;
    private UnityEngine.UI.Slider RoZRSlider2;
    #endregion

    private UnityEngine.UI.InputField WidFF;
    private UnityEngine.UI.InputField HeiFF;

    private GameObject ObjStartButt;
    private GameObject ObjStopButt;


    private GameObject LeftTop;
    private GameObject RightTop;
    private GameObject LeftBottom;
    private GameObject RightBottom;

    private void Awake()
    {
        m_ScreenShot = new ScreenShot();
        m_ScreenShot.resWidth = IMAGE_WIDTH;
        m_ScreenShot.resHeight = IMAGE_HEIGHT;

    }

    private void Start()
    {
        preT = System.DateTime.Now;

        #region find ui obj instance
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

        PosXRSlider = GameObject.Find("PosXRSlider").GetComponent<UnityEngine.UI.Slider>();
        PosYRSlider = GameObject.Find("PosYRSlider").GetComponent<UnityEngine.UI.Slider>();
        PosZRSlider = GameObject.Find("PosZRSlider").GetComponent<UnityEngine.UI.Slider>();
        RoXRSlider = GameObject.Find("RoXRSlider").GetComponent<UnityEngine.UI.Slider>();
        RoYRSlider = GameObject.Find("RoYRSlider").GetComponent<UnityEngine.UI.Slider>();
        RoZRSlider = GameObject.Find("RoZRSlider").GetComponent<UnityEngine.UI.Slider>();

        PosXRSlider2 = GameObject.Find("PosXRSlider (1)").GetComponent<UnityEngine.UI.Slider>();
        PosYRSlider2 = GameObject.Find("PosYRSlider (1)").GetComponent<UnityEngine.UI.Slider>();
        PosZRSlider2 = GameObject.Find("PosZRSlider (1)").GetComponent<UnityEngine.UI.Slider>();
        RoXRSlider2 = GameObject.Find("RoXRSlider (1)").GetComponent<UnityEngine.UI.Slider>();
        RoYRSlider2 = GameObject.Find("RoYRSlider (1)").GetComponent<UnityEngine.UI.Slider>();
        RoZRSlider2 = GameObject.Find("RoZRSlider (1)").GetComponent<UnityEngine.UI.Slider>();

        WidFF = GameObject.Find("WidFF").GetComponent<UnityEngine.UI.InputField>();
        HeiFF = GameObject.Find("HeiFF").GetComponent<UnityEngine.UI.InputField>();
        #endregion

        ObjStartButt = GameObject.Find("StartButton");
        ObjStopButt = GameObject.Find("StopButton");

        LeftTop = GameObject.Find("LeftTop");
        RightTop = GameObject.Find("RightTop");
        LeftBottom = GameObject.Find("LeftBottom");
        RightBottom = GameObject.Find("RightBottom");

    }

    private float CalQuadWidth()
    {
        return Camera.main.WorldToScreenPoint(RightTop.gameObject.transform.position)[0] -
                    Camera.main.WorldToScreenPoint(LeftTop.gameObject.transform.position)[0];
    }

    private float CalQuadHeight()
    {
        return Camera.main.WorldToScreenPoint(LeftTop.gameObject.transform.position)[1] -
                    Camera.main.WorldToScreenPoint(LeftBottom.gameObject.transform.position)[1];
    }


    private void Update()
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


            float xPosBox = ObjPosSlider.value * Random.Range(PosXRSlider.value, PosXRSlider2.value);
            float yPosBox = ObjPosSlider.value * Random.Range(PosYRSlider.value, PosYRSlider2.value);
            float zPosBox = ObjPosSlider.value * Random.Range(PosZRSlider.value, PosZRSlider2.value);

            Box.transform.localPosition = new Vector3(xPosBox, yPosBox, zPosBox);

            float xRotBox = ObjRotSlider.value * Random.Range(RoXRSlider.value, RoXRSlider2.value);
            float yRotBox = ObjRotSlider.value * Random.Range(RoYRSlider.value, RoYRSlider2.value);
            float zRotBox = ObjRotSlider.value * Random.Range(RoZRSlider.value, RoZRSlider2.value);

            Box.gameObject.transform.rotation =
                    Quaternion.Euler(xRotBox, yRotBox, zRotBox);


            float RColBox = Random.Range(0f, 1.5f) * ColorRSlider.value;

            MeshRenderer tempBoxRenderer = Box.gameObject.GetComponentInChildren<MeshRenderer>();
            tempBoxRenderer.material.SetColor("_Color", new Color(ColorRSlider.value * ColorTensiSlider.value * Random.Range(1.0f,ColRandRSlider.value),
                                                                    ColorGSlider.value * ColorTensiSlider.value * Random.Range(1.0f, ColRandGSlider.value),
                                                                    ColorBSlider.value * ColorTensiSlider.value * Random.Range(1.0f, ColRandBSlider.value)));


            float randScale = Random.Range(0.5f, 1f);

            float xPosQuad = -0.521f;
            float yPosQuad;
            float zPosQuad;

            if (randScale == 1.0f)
            {
                zPosQuad = Random.Range(-0.246f, 0.248f);
                yPosQuad = Random.Range(-0.292f, 0.292f);
            }
            else
            {
                yPosQuad = Random.Range(-0.292f * (1.0f -randScale)  + -0.292f, 0.292f * (1.0f - randScale) + 0.292f);
                zPosQuad = Random.Range(-0.246f * (1.0f - randScale) + -0.246f, 0.248f * (1.0f - randScale) + 0.248f);
            }


            Quad.gameObject.transform.localPosition = new Vector3(xPosQuad, yPosQuad, zPosQuad);

            Quad.gameObject.transform.localScale = new Vector3(0.3f * 1.5f * randScale, 0.3f * randScale, 1);


            preT = System.DateTime.Now;

            if (bSaveFiles)
            {
                m_ScreenShot.resWidth = int.Parse( WidFF.text);
                m_ScreenShot.resHeight = int.Parse(HeiFF.text);
                m_ScreenShot.Shot(iNumOfFiles.ToString() + "_" + iNumOfCycle.ToString());

                iNumOfFiles++;
            }



           
        }

        Debug.Log(Camera.main.WorldToScreenPoint(Quad.gameObject.transform.position));

        Debug.Log("Wid : " + CalQuadWidth());
        Debug.Log("Hei : " + CalQuadHeight());
    }


    public void StartMakeBarcodeImg()
    { 
        bStartMake = true;
        bStartFlage = true;
    }
    public void StopMakeBarcodeImg()
    {
        ResetMakeBarcodeImg();
        bStartMake = false;
        bStartFlage = false;
    }
    public void ResetMakeBarcodeImg()
    {
        iNumOfFiles = 0;
        iNumOfCycle++;

    }


    public string WriteResult(string[] paths)
    {
        string _path = "";
        if (paths.Length == 0)
        {
            return _path;
        }

        _path = paths[0];
        return _path;
    }

    public void SetSaveFilesDir()
    {
#if UNITY_EDITOR
        string path = UnityEditor.EditorUtility.OpenFolderPanel("Chose Save img that generated Barcode", "", "");
#elif UNITY_STANDALONE_OSX
        string path = WriteResult(StandaloneFileBrowser.OpenFolderPanel("Chose Save img that generated Barcode", "", true));
#endif

        m_ScreenShot.bFistInitPath = false;
        m_ScreenShot.strPath = path;
    }


    public void ToggleCheckStopChRandom()
    {

        UnityEngine.UI.Text tempText = GameObject.Find("CheckRandToggle").
                                           gameObject.GetComponentInChildren<UnityEngine.UI.Text>();

        if(bCheckRandTogle && !bStartFlage)
        {
            bCheckRandTogle = false;
            bStartMake = false;
            bSaveFiles = true;
            tempText.text = "Check Random";

            ObjStartButt.gameObject.SetActive(true);
            ObjStopButt.gameObject.SetActive(true);

        }
        else if (!bCheckRandTogle && !bStartFlage)
        {
            bCheckRandTogle = true;
            bStartMake = true;
            bSaveFiles = false;

            tempText.text = "Stop Check Random";

            ObjStartButt.gameObject.SetActive(false);
            ObjStopButt.gameObject.SetActive(false);

        }
    }



}
