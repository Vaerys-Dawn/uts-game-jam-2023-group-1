using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using Unity.Netcode;
using UnityEngine;

public class NetworkUI : MonoBehaviour
{
    [SerializeField] private Button serverButton; //No client. Server only
    [SerializeField] private Button hostButton; // Host = Client + server
    [SerializeField] private Button clientButton; // No server. Client only

    private void Awake()
    {
    	serverButton.onClick.AddListener(() => NetworkManager.Singleton.StartServer());
    	hostButton.onClick.AddListener(() => NetworkManager.Singleton.StartHost());
    	clientButton.onClick.AddListener(() => NetworkManager.Singleton.StartClient());
    }

    public void onClick()
    {
        GameObject.Find("ServerButton").SetActive(false);
        GameObject.Find("HostButton").SetActive(false);
        GameObject.Find("ClientButton").SetActive(false);
        GameObject.Find("NotAmongUs").SetActive(false);
    }
}
