using System;
using System.IO;
using UnityEngine;

public class TempFileWriter 
{
    private string _filePath = Application.dataPath + "/Resources/TempData.txt";
    public void WriteFile(string text)
    {
        try
        {
            StreamWriter sw = new StreamWriter(_filePath);
            sw.WriteLine(text);
            sw.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }

    }
}
