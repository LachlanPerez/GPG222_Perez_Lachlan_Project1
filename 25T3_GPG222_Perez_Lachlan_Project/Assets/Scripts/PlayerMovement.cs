using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5;
    public float runSpeed = 7;
    public float jumpPower = 7;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Player moves"); 
        }
    }
}
