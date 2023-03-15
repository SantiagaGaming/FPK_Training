using System;
using System.IO;
using UnityEngine;

public class TempFileWriter 
{
    private string _fileName;
    private string _filePath = Application.dataPath + "/Resources/";
    public void WriteFile(string text)
    {
        try
        {
            var date = DateTime.Now;
            DateParser pareser = new DateParser(date);
            _fileName = pareser.ParseDate();
            StreamWriter sw = new StreamWriter(_filePath+_fileName+ ".txt");
            sw.WriteLine(text);
            sw.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }

    }
}
