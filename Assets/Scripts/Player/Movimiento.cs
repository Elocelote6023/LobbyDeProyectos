using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private float mH, mV;
    public float Velocidad, gravity, fallVelocity, jumpForce;
    public CharacterController Player;
    private Vector3 playerInput, movePlayer;
    public Camera mainCamera;
    public Transform c, target;
    public float t;

    private bool isOnSlope = false;
    private Vector3 hitNormal;
    public float slideVelocity, slopeForceDown;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        c.position = Vector3.Lerp(c.position, target.position, t * Time.deltaTime);

        mH = Input.GetAxis("Horizontal");
        mV = Input.GetAxis("Vertical");

        playerInput = new Vector3(mH, 0, mV);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        movePlayer = movePlayer = playerInput.z * transform.forward + playerInput.x * transform.right;

        movePlayer = movePlayer * Velocidad;

        SetGravity();

        Jumping();

        Player.Move(movePlayer * Time.deltaTime);
    }

    public void SetGravity()
    {
        

        if (Player.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }

        SlideDown();
    }

    public void Jumping()
    {
        if (Player.isGrounded && Input.GetButtonDown("Jump"))
        {
            fallVelocity = jumpForce;
            movePlayer.y = fallVelocity;
        }
    }

    public void SlideDown()
    {
        isOnSlope = Vector3.Angle(Vector3.up, hitNormal) >= Player.slopeLimit;

        if (Vector3.Angle(Vector3.up, hitNormal) != 90 && isOnSlope)
        {
            movePlayer.x += (1f - hitNormal.y) * hitNormal.x * slideVelocity;
            movePlayer.z += (1f - hitNormal.y) * hitNormal.z * slideVelocity;

            movePlayer.y += slopeForceDown;
        }

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hitNormal = hit.normal;
    }

}
