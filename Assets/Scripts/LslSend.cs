using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using LSL;

public class LslSend : MonoBehaviour
{
    private static StreamOutlet outlet;

    private string streamName = "HoloLensOutput";
    private string streamType = "ParadigmChanges";
    private string streamId = "1234";
    private int channelCount = 1;


    // Start is called before the first frame update
    void Start()
    {
        StreamInfo streamInfo = new StreamInfo(streamName, streamType, channelCount, LSL.LSL.IRREGULAR_RATE, LSL.channel_format_t.cf_string, streamId);
        XMLElement chans = streamInfo.desc().append_child("channels");
        chans.append_child("channel").append_child_value("label", "Paradigm Change");
        outlet = new StreamOutlet(streamInfo);
    }


    // FixedUpdate is a good hook for objects that are governed mostly by physics (gravity, momentum).
    // Update might be better for objects that are governed by code (stimulus, event).
    public static void SendOutlet(string _currentSample)
    {
        Log.AddText($"Pushing outlet onto the LSL: {_currentSample}");
        //outlet.push_sample(_currentSample);
        ClientSend.SendOutletLSL(_currentSample);
        Log.AddText($"Pushed!");
    }
}
