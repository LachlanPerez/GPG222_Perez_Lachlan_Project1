using UnityEngine;
using UnityEngine.UI;

public class UIButtonScript : MonoBehaviour
{
    public Button hostWithRelay;
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
        relayNetworkManager.StartHostWithRelay(maxConnections: 8, connectionType: "udp");
    }

    public void JoinCode(string _code)
    {
        code = _code;
    }
}
