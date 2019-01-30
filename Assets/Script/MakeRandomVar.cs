using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeRandomVar : MonoBehaviour
{

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


    private System.DateTime preT;



    void Start()
    {
        preT = System.DateTime.Now;
    }
    


    void Update()
    {
        System.DateTime nowT = System.DateTime.Now;


        System.TimeSpan deltaT;
        deltaT = nowT - preT;
        if (deltaT.TotalSeconds > 0.5f)
        {

            Light tempLight = ObjLigth.gameObject.GetComponent<Light>();
            tempLight.intensity = Random.Range(0.2f, 1.2f);

            float xRotBox = Random.Range(0.2f, 360f);
            float yRotBox = Random.Range(-140f, -140f);
            float zRotBox = Random.Range(-30.2f, 20.2f);

            Box.gameObject.transform.rotation =
                    Quaternion.Euler(xRotBox, yRotBox, zRotBox);


            preT = System.DateTime.Now;
        }
        

    }
}
