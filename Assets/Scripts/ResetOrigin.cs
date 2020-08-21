using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetOrigin : MonoBehaviour
{
    public GameObject leapRigObject;
    public GameObject cameraObject;
    private Vector3 initialPos;
    private Vector3 initialRot;

    void Start()
    {
        initialPos = leapRigObject.transform.localPosition;
        initialRot = leapRigObject.transform.localRotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        OVRInput.Update();
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            Debug.Log("Got the input down one");
            leapRigObject.transform.SetPositionAndRotation(initialPos - cameraObject.transform.localPosition, Quaternion.Euler(initialRot - cameraObject.transform.localRotation.eulerAngles));
        }
    }
}
