using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.UI;

public class BootStrapManager : MonoBehaviour
{
    [SerializeField]
    private float buttonWidth = 70f;

    [SerializeField]
    private float buttonHeight = 40f;

    public UnityTransport transport;

    public RelayNetworkManager relayNetworkManager;

    string ipAddress = "127.0.0.1";
    private string relayJoinCode = "Write Code";

    public void NewIPAddress(string ipAddress)
    {
        Debug.Log("New IP Address: " +  ipAddress);
        transport.SetConnectionData(ipAddress, port: 7777);
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 100, 400));

        var networkManager = NetworkManager.Singleton;
        if (!networkManager.IsClient && !networkManager.IsServer)
        {
            GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
            myButtonStyle.fontSize = 16;
            myButtonStyle.fixedWidth = buttonWidth;
            myButtonStyle.fixedHeight = buttonHeight;

            if (GUILayout.Button("Host", myButtonStyle))
            {
                networkManager.StartHost();
            }

            ipAddress = GUILayout.TextField(ipAddress, maxLength: 15);
            if (GUILayout.Button("Client", myButtonStyle))
            {
                networkManager.StartClient();
            }

            if (GUILayout.Button("Server", myButtonStyle))
            {
                networkManager.StartServer();
            }
            
            
            
            
            GUILayout.Space(50);

            if(GUILayout.Button("Start with Relay", myButtonStyle))
            {
               relayNetworkManager.StartHostWithRelay(8, "udp");
            }

            GUILayout.Space(20);
            
            relayJoinCode = GUILayout.TextField(relayJoinCode, maxLength: 15);
            
            if(GUILayout.Button("Client", myButtonStyle))
            {
                relayNetworkManager.StartClientWithRelay(relayJoinCode, connectionType: "udp");
            }
            
            
            
            GUILayout.Space(50);
            if (GUILayout.Button("Create Lobby", myButtonStyle))
            {
                //LobbyManager.CreateLobby()
            }
            
            GUILayout.Space(20);
            if (GUILayout.Button("Join Lobby", myButtonStyle))
            {
                
            }
        }

        GUILayout.EndArea();
    }
}
