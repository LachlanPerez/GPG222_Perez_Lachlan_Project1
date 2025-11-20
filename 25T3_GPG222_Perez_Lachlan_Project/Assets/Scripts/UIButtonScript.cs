using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonScript : MonoBehaviour
{
    public Button hostWithRelay;
    public Button clientWithRelay;
    public Button createLobbyWithRelay;
    public Button joinLobbyWithoutRelay;
    public RelayNetworkManager relayNetworkManager;
    private string code;

    private void OnEnable()
    {
        hostWithRelay.onClick.AddListener(OnClicked);
    }

    private void OnDisable()
    {
        hostWithRelay.onClick.RemoveListener(OnClicked);
    }

    private void OnClicked()
    {
        Task<string> startHostWithRelay = relayNetworkManager.StartHostWithRelay(maxConnections: 8, connectionType: "udp");
        Debug.Log(startHostWithRelay.Result);
    } 

    public void JoinCode(string _code)
    {
        code = _code;
    }
}
