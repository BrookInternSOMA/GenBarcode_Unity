using System.Collections;
using System.Collections.Generic;

using JinUtill;

public class BarCodeAlgor
{

    #region Public Var
    public string CODE { get; set; }

    public List<string> BinOfCodeList = new List<string>();
    #endregion


    #region Private Var
    private int iCheck = 0;
    private string strCheck = "";

    private List<int> CheckofCodeList = new List<int>();
    #endregion



    public CommonUtill.RESULT_CODE MakeBinOfCode()
    {
        if(CODE != "")
        {
            BinOfCodeList.Add(CommonUtill.DecToBin(141));

            char[] tempCodeList = CODE.ToCharArray();
            for(int i = 0; i < tempCodeList.Length; i++)
            {
                int tempASCII = CommonUtill.ConvertASCII(
                                tempCodeList[i].ToString());
                CheckofCodeList.Add(tempASCII);
                BinOfCodeList.Add(CommonUtill.DecToBin(tempASCII));
            }

            for (int i = 0; i < CheckofCodeList.Count; i++)
                iCheck += CheckofCodeList[i] * i;

            strCheck = CommonUtill.DecToBin((int)((iCheck + 104) % 103));

            BinOfCodeList.Add(strCheck);
            BinOfCodeList.Add(CommonUtill.DecToBin(140));


#if DEBUG
            string strLogOfBin = "BinList Is   ";
            for (int i = 0; i < BinOfCodeList.Count; i++)
            {
                strLogOfBin += BinOfCodeList[i].ToString();
                strLogOfBin += "  ";
            }

            UnityEngine.Debug.Log(strLogOfBin);
#endif



            return CommonUtill.RESULT_CODE.Success;
        }



        return CommonUtill.RESULT_CODE.Fail;
    }


    public int CalBitOfNum()
    {
        int resultSize = 0;
        int numOfBinList = BinOfCodeList.Count;



        if (numOfBinList != 0)
            for (int i = 0; i < numOfBinList; i++)
                resultSize += BinOfCodeList[i].Length;

        UnityEngine.Debug.Log("Size" + resultSize.ToString());

        return resultSize;
    }



}
