using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
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

        Vector3 MoveVector3 = transform.TransformDirection(PlayerInput);// This will store the movement inputs from the transformdirection into another variable called the move vector 
        float CurrentSpeed = Input.GetKey(KeyCode.LeftShift) ? RunSpeed : WalkSpeed;// determines weather the player is sprinting or not and it uses the ? mark asa  variable to determine this outcome
        CurrentMoveVelocity = Vector3.SmoothDamp(CurrentMoveVelocity, MoveVector3 * CurrentSpeed, ref MoveDampVelocity, MoveSmoothTime);// currentmovevelocity variable as it will be the primary vector to move the player with the smoothing of the current move velocity

        Controller.Move(CurrentMoveVelocity * Time.deltaTime);// moves the player through move velocity and multiples by time to delta time 

        Ray groundCheckRay = new Ray(transform.position, Vector3.down);// checking ray cast that shoots down for 1.25
        if(Physics.Raycast(groundCheckRay, 1.1f))// If the player is on the floor or  
        {
            CurrentForceVelocity.y = -2f;// detects a collision will be applied to keep the player on the floor when navigating.

            if (Input.GetKey(KeyCode.Space))//Checks to see if the space bar button has been pressed
            {
                CurrentForceVelocity.y = JumpStrength;// when the player has pressed teh jump button it will be set to the jump strength
            }
        }
        else
        {
            CurrentForceVelocity.y -= GravityStrength * Time.deltaTime;//if the raycast isnt colliding with anything it will subtract the gravity multiplied by delta time so that the players falling velocity will gradually increase
        }
        Controller.Move(CurrentForceVelocity * Time.deltaTime);//uses the current move force velocity variable multiplied by delta time
    }

    
}
