using UnityEngine;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.Text;
using UnityEngine.InputSystem;

public class SerialChecker : MonoBehaviour
{
    private const string RegistryKeyPath = @"SOFTWARE\CATO\Fpk";
    private void Start()
    {
        CheckSerial();
    }
    private void CheckSerial()
    {
        RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath);
       if(key == null)
        {
            Application.Quit();
        }
        //if (key.GetValue("key") == null || key.GetValue("key").ToString() != GetKey())
        //{
           
        //}
          //  
    }
    private string GetKey()
    {
        var combinedString = "fpk";
        var md5 = MD5.Create();
        var inputBytes = Encoding.UTF8.GetBytes(combinedString);
        var hashBytes = md5.ComputeHash(inputBytes);

        var sb = new StringBuilder();
        foreach (var b in hashBytes)
        {
            sb.Append(b.ToString("X2"));
        }
        return sb.ToString();
    }
}