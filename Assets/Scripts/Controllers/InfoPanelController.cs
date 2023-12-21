using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanelController : MonoBehaviour
{
    public static InfoPanelController Instance;
    public  List<InfoPanelModel> PanelModel = new List<InfoPanelModel>();
   
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }
    public  void AddPanel(InfoPanelModel panel)
    {
        PanelModel.Add(panel);
    }
}
