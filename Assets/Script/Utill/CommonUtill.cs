using System;
using System.Text;

public class CommonUtill
{
    public static int ConvertASCII(string str)
    {
        byte[] bytes = Encoding.ASCII.GetBytes(str);
        int result = BitConverter.ToInt32(bytes, 0);
        return result;
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
