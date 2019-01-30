using System.Collections;
using System.Collections.Generic;

using JinUtill;
using Zen.Barcode;

public class BarCodeAlgor
{

    #region Public Var
    public string CODE { get; set; }



    public List<string> BinOfCodeList = new List<string>();
    #endregion


    #region Private Var
    private Glyph[] m_Code128;
    private Glyph[] m_Code128Check;
    #endregion



    public CommonUtill.RESULT_CODE MakeBinOfCode()
    {
        if(CODE != "")
        {

            m_Code128 = Code128GlyphFactory.Instance.GetGlyphs(CODE);
            for(int i = 0; i < m_Code128.Length; i++)
            {
                Code128Glyph temp = (Code128Glyph)m_Code128[i];
                BinOfCodeList.Add(CommonUtill.DecToBin(temp.BitEncoding));
            }


            m_Code128Check = Code128Checksum.Instance.GetChecksum(CODE);
            for (int i = 0; i < m_Code128Check.Length; i++)
            {
                Code128Glyph tempCheck = (Code128Glyph)m_Code128Check[i];
                BinOfCodeList.Add(CommonUtill.DecToBin(tempCheck.BitEncoding));
            }


            BinOfCodeList.Add(CommonUtill.DecToBin(6379));




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
