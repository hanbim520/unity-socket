using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using xClient.Core.Networking;
using xClient.Config;
using xClient.Core.Utilities;
using xClient.Core.Helper;
using System.Threading;
using xClient.Core.Packets.ClientPackets;
using xClient.Core.Cryptography;

public class Test : MonoBehaviour {
    private static Thread thread;
    private QuasarClient ConnectClient;
    private Object thisLock = new Object();
    private float lastTime;
    private float curTime;
    // Use this for initialization
    void Start () {
        AES.SetDefaultKey(Settings.KEY, Settings.AUTHKEY);
        thread = new Thread(Run);
        thread.Start();
    }
	
    void Run()
    {
        var hosts = new HostsManager(HostHelper.GetHostsList(Settings.HOSTS));
        ConnectClient = new QuasarClient(hosts);
        if (!QuasarClient.Exiting)
            ConnectClient.Connect();
      
    }

    private void SendMsg()
    {
        new SetStatus("Updating...").Execute(ConnectClient);
    }
    // Update is called once per frame
    void Update () {
        curTime = Time.time;
        if (curTime - lastTime >= 3 && ConnectClient.Connected)
        {
            var sendThread = new Thread(SendMsg);
            sendThread.Start();
            lastTime = curTime;
        }
    }
    private void OnDestroy()
    {
        if(!QuasarClient.Exiting)
        {
            lock (thisLock)
            {
                QuasarClient.Exiting = true;
            }
           
        }
        thread.Abort();
        thread = null;
    }
}
