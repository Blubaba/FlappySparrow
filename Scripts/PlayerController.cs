using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [Space(20)]public float rotateSpeed = 180;
    [Range(1,2)]public float rotateRatio = 1;
    public Transform playerTransform;
    public Transform eyeViewTransform;
    public float MaxViewAngle = 65f;
    private float tmp_viweRotationOffset;
    public float gravity = 9.8f;
    public float verticalVelocity = 0;
    public bool isGround = false;
    public LayerMask GroundLayer;
    public Transform GroundCheckPoint;
    public float checkShereRadius;
    public float MaxJumpHeight = 5f;
    private float tmp_horizontal_axis;
    private float tmp_vertical_axis;
    public GameObject[] actions;
    //public int click = 0;

    //move
    [Space(20)]public CharacterController characterController;
    public Animator ani;
    public float moveSpeed = 10;

    private void Start()
    {
        characterController = this.GetComponent<CharacterController>();
        ani = this.GetComponent<Animator>();
    }

    void Update()
    {
        PlayerRotateControl();
        PlayerMoveControl();

        ani.SetBool(name:"Forwards", value:false);
        ani.SetBool(name:"Backwards", value:false);
        ani.SetBool(name:"Left", value:false);
        ani.SetBool(name:"Right", value:false);
        ani.SetBool(name:"Jump", value:false);

        if(Input.GetKey(KeyCode.W))
        {
            ani.SetBool(name:"Forwards", value:true);
        }

        if(Input.GetKey(KeyCode.S))
        {
            ani.SetBool(name:"Backwards", value:true);
        }

        if(Input.GetKey(KeyCode.A))
        {
            ani.SetBool(name:"Left", value:true);
        }

        if(Input.GetKey(KeyCode.D))
        {
            ani.SetBool(name:"Right", value:true);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            ani.SetBool(name:"Jump", value:true);
        }

    }

 

    
    public void PlayerMoveControl()
    {
        if(characterController == null)
        {
            return;
        }

        Vector3 motionVector =Vector3.zero;
        float horizontal_axis = 0f;
        float vertical_axis = 0f;

        if(isGround)
        {
            horizontal_axis = Input.GetAxis("Horizontal");
            vertical_axis = Input.GetAxis("Vertical");
            motionVector += playerTransform.forward * (moveSpeed * vertical_axis * Time.deltaTime);
            motionVector += playerTransform.right * (moveSpeed * horizontal_axis * Time.deltaTime);
        }
        else
        {
            motionVector += playerTransform.forward * (moveSpeed * tmp_vertical_axis * Time.deltaTime);
            motionVector += playerTransform.right * (moveSpeed * tmp_horizontal_axis * Time.deltaTime);
        }

        verticalVelocity -= gravity * Time.deltaTime;
        motionVector += Vector3.up * (verticalVelocity * Time.deltaTime);

        isGround =Physics.CheckSphere(GroundCheckPoint.position,checkShereRadius, GroundLayer);
        if(isGround && verticalVelocity < -1.5)
        {
            isGround = true;
            verticalVelocity = 0;
        }

        if(isGround)
        {
            if(Input.GetButtonDown("Jump"))
            {
                tmp_horizontal_axis = horizontal_axis;
                tmp_vertical_axis = vertical_axis;

                verticalVelocity = Mathf.Sqrt(2 * gravity * MaxJumpHeight);
            }
        }
        characterController.Move(motionVector);
    }

    private void PlayerRotateControl()
    {
        if(playerTransform == null || eyeViewTransform == null)
        {
            return;
        }
        float offset_X= Input.GetAxis("Mouse X");
        float offset_Y= Input.GetAxis("Mouse Y");
        playerTransform.Rotate(Vector3.up * (offset_X * rotateSpeed * rotateRatio * Time.deltaTime));
        tmp_viweRotationOffset -= offset_Y * rotateSpeed * rotateRatio * Time.deltaTime;
        tmp_viweRotationOffset = Mathf.Clamp(tmp_viweRotationOffset, -MaxViewAngle, MaxViewAngle);
        Quaternion EyeLocalQuaternion = Quaternion.Euler(new Vector3(tmp_viweRotationOffset,
        eyeViewTransform.localEulerAngles.y,
        eyeViewTransform.localEulerAngles.z));
        eyeViewTransform.localRotation = EyeLocalQuaternion;
    }
    
}


