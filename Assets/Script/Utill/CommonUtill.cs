using System;
using System.Text;

namespace JinUtill
{

    public class CommonUtill
    {

        public enum RESULT_CODE { Fail, Success };

        public static int ConvertASCII(string str)
        {

            byte[] bytes = Encoding.ASCII.GetBytes(str);
            if (bytes.Length > 1)
            {
                int result = BitConverter.ToInt32(bytes, 0);
                return result;
            }
            else
                return (int)bytes[0];

        }

        public static string DecToBin(int Dec)
        {
            return System.Convert.ToString(Dec, 2);

        }

        public static int StringToInt(string str)
        {
            int result = 0;

            try
            {
                result = Int32.Parse(str);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            return result;
        }
    }
}