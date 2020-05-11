using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;
using System.Linq;
using System.Diagnostics;

public class TrackingReceiver : MonoBehaviour
{
    //GameObjects to be controlled with Posenet
    public GameObject nose;
    public GameObject wristR;
    public GameObject wristL;

    public GameObject elbowL;

    public GameObject elbowR;

    public GameObject shoulderL;

    public GameObject shoulderR;

    //OSC Variables
    private OSCReceiver _receiver;
    private const string _oscAddress = "/pose/0";

    //Dictionary to store pose data
    public Dictionary<string, Vector3> pose = new Dictionary<string, Vector3>();

    // Start is called before the first frame update
    protected virtual void Start()
    {
        //Set up OSC receiver
        StartOSCReceiver();

        //Initialize pose
        StartPose();
    }

    void StartOSCReceiver() {
        // Creating a receiver.
        _receiver = gameObject.AddComponent<OSCReceiver>();

        // Set local port.
        _receiver.LocalPort = 9876;

        // Bind "MessageReceived" method to special address.
        _receiver.Bind(_oscAddress, MessageReceived);
    }

    void StartPose() {
        pose.Add("nose", nose.transform.position);
        pose.Add("rightWrist", wristR.transform.position);
        pose.Add("leftWrist", wristL.transform.position);
        pose.Add("leftElbow", elbowL.transform.position);
        pose.Add("rightElbow", elbowR.transform.position);
        pose.Add("leftShoulder", shoulderL.transform.position);
        pose.Add("rightShoulder", shoulderL.transform.position);

    }
    

    // Update is called once per frame
    void Update()
    {
        nose.transform.position = pose["nose"];
        wristR.transform.position = pose["rightWrist"];
        wristL.transform.position = pose["leftWrist"];
        elbowL.transform.position = pose["leftElbow"];
        elbowR.transform.position = pose["rightElbow"];
        shoulderL.transform.position = pose["leftShoulder"];
        shoulderR.transform.position = pose["rightShoulder"];
    }

    protected void MessageReceived(OSCMessage message)
    {
        List<OSCValue> list = message.Values;
        //UnityEngine.Debug.Log(list.Count);

        for(int i=0;i<list.Count; i+=3)
        {
            string key = "";
            Vector2 position = Vector3.zero; 

            OSCValue val0 = list.ElementAt(i);
            if (val0.Type == OSCValueType.String) key = val0.StringValue;
            OSCValue val1 = list.ElementAt(i+1);
            if (val1.Type == OSCValueType.Float) position.x = val1.FloatValue-250;
            OSCValue val2 = list.ElementAt(i+2);
            if (val2.Type == OSCValueType.Float) position.y = -(val2.FloatValue-250);

            if (pose.ContainsKey(key)) {
                pose[key] = position; 
            }
        }

    }
}
