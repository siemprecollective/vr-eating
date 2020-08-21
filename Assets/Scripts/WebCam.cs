using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebCam : MonoBehaviour
{
    public MeshRenderer[] UseWebcamTexture;
    private WebCamTexture webcamTexture;

    // Start is called before the first frame update
    void Start()
    {
        webcamTexture = new WebCamTexture();
        foreach (MeshRenderer r in UseWebcamTexture)
        {
            r.material.mainTexture = webcamTexture;
        }
        GetComponent<Renderer>().material.mainTexture = webcamTexture;
        webcamTexture.Play();
    }
}
