using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using Leap;

public class LeapMotionController : MonoBehaviour
{
    private Controller _controller;
    private LeapXRServiceProvider _provider;
    Texture2D leftTex2D;
    Texture2D rightTex2D;
    public RenderTexture leftRenderTexture;
    public RenderTexture rightRenderTexture;

    private void Awake()
    {
        _provider = GetComponent<LeapXRServiceProvider>();
        if (_provider == null)
        {
            _provider = GetComponentInChildren<LeapXRServiceProvider>();
        }
        if (_provider != null) _controller = _provider.GetLeapController();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (_controller != null) _controller.ImageReady += onImageReady;
        else Debug.LogWarning("Warning - Leap controller is null");
    }

    private void onImageReady(object sender, Leap.ImageEventArgs args)
    {
        if (leftTex2D == null)
        {
            leftTex2D = new Texture2D(args.image.Width, args.image.Height, TextureFormat.R8, false);
        }
        leftTex2D.LoadRawTextureData(args.image.Data(Leap.Image.CameraType.LEFT));
        leftTex2D.Apply();
        Graphics.Blit(leftTex2D, leftRenderTexture);

        if (rightTex2D == null)
        {
            rightTex2D = new Texture2D(args.image.Width, args.image.Height, TextureFormat.R8, false);
        }
        rightTex2D.LoadRawTextureData(args.image.Data(Leap.Image.CameraType.RIGHT));
        rightTex2D.Apply();
        Graphics.Blit(rightTex2D, rightRenderTexture);
    }
}
