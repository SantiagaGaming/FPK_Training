using UnityEngine;

public class EditEmissiveIntensityExample : MonoBehaviour
{
    public GameObject m_EmissiveObject;

    void Start()
    {
        float emissiveIntensity = 10;
        Color emissiveColor = Color.green;
        m_EmissiveObject.GetComponent<Renderer>().material.SetColor("_EmissiveColor", emissiveColor * emissiveIntensity);
    }
}