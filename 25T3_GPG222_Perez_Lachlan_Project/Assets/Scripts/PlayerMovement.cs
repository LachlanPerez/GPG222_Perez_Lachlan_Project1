using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float playerSpeed = 7;
    [SerializeField]private float jumpHeight = 1.5f;
    [SerializeField]private float gravityValue = -9.8f;  

    private CharacterController characterController;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    public InputActionReference moveAction; //expects vector2
    public InputActionReference jumpAction; //expects Button

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        moveAction.action.Enable();
        jumpAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
        jumpAction.action?.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = characterController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0;
        }

        Vector2 input = moveAction.action.ReadValue<Vector2>(); 
        Vector3 move = new Vector3(input.x, 0, input.y);
        move = Vector3.ClampMagnitude(move, 1);

        if(move != Vector3.zero)
        {
            transform.forward = move;
        }

        if(jumpAction.action.triggered && groundedPlayer)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;

        Vector3 finalMove = (move * playerSpeed) + (playerVelocity.y * Vector3.up);
        characterController.Move(finalMove * Time.deltaTime);
    }
}
