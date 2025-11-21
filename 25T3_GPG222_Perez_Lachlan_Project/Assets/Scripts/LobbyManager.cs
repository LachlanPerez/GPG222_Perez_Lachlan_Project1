using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public string lobbyName = "SwordsAwesomeLobby";
    public int maxPlayers = 4;
    CreateLobbyOptions options = new CreateLobbyOptions();
    public InitializeScript initialization;

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


        try
        {
            // Quick-join a random lobby with a maximum capacity of 10 or more players.
            QuickJoinLobbyOptions options = new QuickJoinLobbyOptions();

            options.Filter = new List<QueryFilter>()
            {
                new QueryFilter(
                    field: QueryFilter.FieldOptions.MaxPlayers,
                    op: QueryFilter.OpOptions.GE,
                    value: "10")
            };

            var lobby = await LobbyService.Instance.QuickJoinLobbyAsync(options);

            // ...
        }
        catch (LobbyServiceException e)
        {
            Debug.Log(e);
        }
    }
}