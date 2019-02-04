using UnityEngine;
using System.Collections;

using UnityEngine.PostProcessing;

public class ScreenShot : MonoBehaviour
{

    public int resWidth = 2550;
    public int resHeight = 3300;


    public string strPath;
    public bool bFistInitPath = true;



    public GameObject BackGround;
    public GameObject Quad;
    public GameObject Quad2;

   


    private void Start()
    { }



    private string ScreenShotName(string name, int width, int height)
    {
        return strPath + "/" + name + ".png";
    }



    public void Shot(string name, int flag)
    {
        if(flag == 1)
        {
            BackGround.SetActive(true);
            Quad.SetActive(false);
            Quad2.SetActive(true);
            Camera.main.gameObject.GetComponent<PostProcessingBehaviour>().enabled = false;

        }


        if (bFistInitPath)
            strPath = Application.dataPath + "/../screenshots/";

        RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
        Camera.main.targetTexture = rt;
        Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        Camera.main.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        Camera.main.targetTexture = null;
        RenderTexture.active = null; // JC: added to avoid errors
        Destroy(rt);
        byte[] bytes = screenShot.EncodeToPNG();
        string filename;
        if(flag == 1)
            filename = ScreenShotName(name + "_map", resWidth, resHeight);
        else
            filename = ScreenShotName(name , resWidth, resHeight);
        //GameObject.Find("Text (22)").gameObject.GetComponentInChildren<UnityEngine.UI.Text>().text = filename;
        System.IO.File.WriteAllBytes(filename, bytes);
        Debug.Log(string.Format("Took screenshot to: {0}", filename));

        if (flag == 1)
        {
            BackGround.SetActive(false);
            Quad.SetActive(true);
            Quad2.SetActive(false);

            Camera.main.gameObject.GetComponent<PostProcessingBehaviour>().enabled = true;
        }
    }

  


}