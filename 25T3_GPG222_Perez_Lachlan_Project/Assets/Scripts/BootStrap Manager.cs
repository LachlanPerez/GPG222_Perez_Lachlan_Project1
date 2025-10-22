using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;

public class BootStrapManager : MonoBehaviour
{
    [SerializeField]
    private float buttonWidth = 70f;

    [SerializeField]
    private float buttonHeight = 40f;

    public UnityTransport transport;

    string ipAddress = "127.0.0.1";

    public void NewIPAddress(string ipAddress)
    {
        Debug.Log("New IP Address: " +  ipAddress);
        transport.SetConnectionData(ipAddress, port: 7777);
    }

    private void OnGUI()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        GUILayout.BeginArea(new Rect(10, 10, 100, 400));

        var networkManager = NetworkManager.Singleton;
        if (!networkManager.IsClient && !networkManager.IsServer)
        {
            GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
            myButtonStyle.fontSize = 20;
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
        }

        GUILayout.EndArea();
    }
}
