using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanelController : MonoBehaviour
{
   public  List<InfoPanelModel> PanelModel = new List<InfoPanelModel>();

    public  void AddPanel(InfoPanelModel panel)
    {
        PanelModel.Add(panel);
    }
}
