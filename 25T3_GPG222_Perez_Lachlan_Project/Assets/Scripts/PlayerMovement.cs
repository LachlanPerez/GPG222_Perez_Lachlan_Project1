using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Unity.Netcode;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private float MoveSmoothTime;
    [SerializeField] private float GravityStrength;
    [SerializeField] private float JumpStrength;
    [SerializeField] private float WalkSpeed;
    [SerializeField] private float RunSpeed;

    private CharacterController Controller;
    private Vector3 CurrentMoveVelocity;
    private Vector3 MoveDampVelocity;

    private Vector3 CurrentForceVelocity; 

    public Transform PlayerCamera; 
    public Vector2 sensitivities;  
    public float SmoothSpeed = 5f;

    private Vector2 SmoothRotation;
    private Vector2 XYRotation;    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (IsOwner)
        {
            Controller = GetComponent<CharacterController>();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            if(PlayerCamera != null)
            {
                PlayerCamera.gameObject.SetActive(false);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;
        {
            HandleMovement();
            HandleCamera();
        }
    }

    private void HandleMovement()
    {
        Vector3 PlayerInput = new Vector3
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = 0f,
            z = Input.GetAxisRaw("Vertical") 
        };

        if (PlayerInput.magnitude > 1f)
        {
            PlayerInput.Normalize();
        }

        Vector3 MoveVector3 = transform.TransformDirection(PlayerInput);
        float CurrentSpeed = Input.GetKey(KeyCode.LeftShift) ? RunSpeed : WalkSpeed;
        CurrentMoveVelocity = Vector3.SmoothDamp(CurrentMoveVelocity, MoveVector3 * CurrentSpeed, ref MoveDampVelocity, MoveSmoothTime);
        Controller.Move(CurrentMoveVelocity * Time.deltaTime); 

        Ray groundCheckRay = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(groundCheckRay, 1.1f))
        {
            CurrentForceVelocity.y = -2f;

            if (Input.GetKey(KeyCode.Space))
            {
                CurrentForceVelocity.y = JumpStrength;
            }
        }
        else
        {
            CurrentForceVelocity.y -= GravityStrength * Time.deltaTime;
        }
        Controller.Move(CurrentForceVelocity * Time.deltaTime);
    }

    private void HandleCamera()
    {
        
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        
        XYRotation.x -= mouseY * sensitivities.y;
        XYRotation.y += mouseX * sensitivities.x;

       
        XYRotation.x = Mathf.Clamp(XYRotation.x, -90f, 90f);

        SmoothRotation = Vector2.Lerp(SmoothRotation, XYRotation, SmoothSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0f, SmoothRotation.y, 0f);
        PlayerCamera.localEulerAngles = new Vector3(SmoothRotation.x, 0f, 0f);
    }
}
