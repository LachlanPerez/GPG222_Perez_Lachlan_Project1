using System;
using Unity.Services.Core;
using System.Threading.Tasks;
using UnityEngine;

public class InitializeScript : MonoBehaviour
{
    public async Task Init()
    {
        try
        {
            await UnityServices.InitializeAsync();
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }

}
