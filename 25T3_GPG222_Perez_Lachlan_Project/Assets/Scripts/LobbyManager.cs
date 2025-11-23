using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using TMPro;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
  /*
    public string lobbyName = "SwordsAwesomeLobby";
    public int maxPlayers = 4;
    CreateLobbyOptions options = new CreateLobbyOptions();
    public InitializeScript initialization;
    [SerializeField] private GameObject lobbyCreationParent;
    [SerializeField] private TMP_InputField createLobbyNameField;
    [SerializeField] private TMP_Dropdown createLobbyGameModeDropdown;
    [SerializeField] private TMP_InputField createLobbyMaxPlayersField;
    [SerializeField] private TMP_InputField createLobbyPasswordField;

    public RelayNetworkManager relayNetworkManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async void Start()
    {
        await initialization.Init();
        await SignUpAnonymouslyAsync();
        await CreateLobby();
        Debug.Log("Lobby created");
    }

    // Update is called once per frame
    public async Task CreateLobby()
    {
        options.Data = new Dictionary<string, DataObject>()
        {
            {
                "RelayCode", new DataObject(
                    visibility: DataObject.VisibilityOptions.Public, // Visible publicly.
                    value: "RelayCode")
            },
        };

        Lobby lobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers, options);
    }


    public async Task<Lobby> CreateLobbyWithHeartbeatAsync()
    {
        // See 'Creating a Lobby' for example parameters
        var lobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers, options);

        // Heartbeat the lobby every 15 seconds.
        StartCoroutine(HeartbeatLobbyCoroutine(lobby.Id, 15));
        return lobby;
    }

    IEnumerator HeartbeatLobbyCoroutine(string lobbyId, float waitTimeSeconds)
    {
        var delay = new WaitForSecondsRealtime(waitTimeSeconds);

        while (true)
        {
            LobbyService.Instance.SendHeartbeatPingAsync(lobbyId);
            yield return delay;
        }
    }

    public async Task SignUpAnonymouslyAsync()
    {
        try
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            Debug.Log("Sign in anonymously succeeded!");

            // Shows how to get the playerID
            Debug.Log($"PlayerID: {AuthenticationService.Instance.PlayerId}");
        }
        catch (AuthenticationException ex)
        {
            // Compare error code to AuthenticationErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
        catch (RequestFailedException ex)
        {
            // Compare error code to CommonErrorCodes
            // Notify the player with the proper error message
            Debug.LogException(ex);
        }
    }

    public async Task JoinLobby(string lobbyId)
    {
        if (needPassword)
        {
            try
            {
                await LobbyService.Instance.JoinLobbyByIdAsync(lobbyID, new JoinLobbyByIdOptions
                    { Password = await InputPassword(), Player = playerData });

                joinedLobbyId = lobbyID;
                lobbyListParent.SetActive(false);
                joinedLobbyParent.SetActive(true);
                UpdateLobbyInfo();
            }
            catch (LobbyServiceException e)
            {
                Debug.Log(e);
            }
        }
        else
        {
            try
            {
                await LobbyService.Instance.JoinLobbyByIdAsync(lobbyID, new JoinLobbyByIdOptions { Player = playerData });
                lobbyListParent.SetActive(false);
                joinedLobbyParent.SetActive(true);

                joinedLobbyId = lobbyID;
                UpdateLobbyInfo();
            }
            catch (LobbyServiceException e)
            {
                Debug.Log(e);
            }
        }
    }
*/
}