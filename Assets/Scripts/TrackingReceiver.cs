using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;
using System.Linq;
using System.Diagnostics;

public class TrackingReceiver : MonoBehaviour
{
    //GameObjects to be controlled with Posenet

    public GameObject wristR;
    public GameObject wristL;
    public GameObject shoulderL;
    public GameObject shoulderR;

    public GameObject ankleL;
    public GameObject ankleR;

    private Vector3 offset1;

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

        offset1 = new Vector3(0,50,0);

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

        pose.Add("rightWrist", wristR.transform.position);
        pose.Add("leftWrist", wristL.transform.position);
        pose.Add("leftShoulder", shoulderL.transform.position);
        pose.Add("rightShoulder", shoulderR.transform.position);
        //pose.Add("leftAnkle", ankleL.transform.position);
        //pose.Add("rightAnkle", ankleR.transform.position);
        pose.Add("leftKnee", ankleL.transform.position);
        pose.Add("rightKnee", ankleR.transform.position);

    }

    
    // Update is called once per frame
    void Update()
    {

        shoulderL.transform.position = pose["leftShoulder"];
        shoulderR.transform.position = pose["rightShoulder"];


        wristR.transform.position = new Vector3(pose["rightWrist"].x,pose["rightWrist"].y,-40.0f)+offset1;

        wristL.transform.position =new Vector3(pose["leftWrist"].x,pose["leftWrist"].y,-40.0f)+offset1;

    
        //ankleR.transform.position = pose["rightAnkle"];
        //ankleL.transform.position =pose["leftAnkle"];

        ankleR.transform.position = pose["rightKnee"]+offset1;
        ankleL.transform.position =pose["leftKnee"]+offset1;
        
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
