using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGrabManager : MonoBehaviour
{
    private OVRGrabber grabber;
    public GameObject cubeGroup;
    public GameObject bowlObject;
    public GameObject headObject;
    public float bowlDistanceThreshold;
    public float headDistanceThreshold;

    // Start is called before the first frame update
    void Start()
    {
        grabber = GetComponent<OVRGrabber>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("in customgrabmanager update pos x y z:" + " " + transform.position.x.ToString() + " " + transform.position.y.ToString() + " " + transform.position.z.ToString());
        OVRGrabbable[] cubeGrabbables = cubeGroup.GetComponentsInChildren<OVRGrabbable>();
        if (grabber.grabbedObject == null)
        {
            Vector3 offset = transform.position - bowlObject.transform.position;
            Debug.Log("in customgrabmanager offset magnitude: " + offset.magnitude.ToString());
            if (offset.magnitude <= bowlDistanceThreshold)
            {
                grabber.ForceGrab(cubeGrabbables);
            }
        }
        else
        {
            Vector3 offset = transform.position - headObject.transform.position;
            Debug.Log("in customgrabmanager distance to head: " + offset.magnitude.ToString());
            if (offset.magnitude <= headDistanceThreshold)
            {
                OVRGrabbable grabbedObject = grabber.grabbedObject;
                grabber.ForceRelease(grabbedObject);
                Destroy(grabbedObject.gameObject);
            }
        }
    }
}
