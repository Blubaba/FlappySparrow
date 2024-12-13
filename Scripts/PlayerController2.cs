using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerController2 : MonoBehaviour
{

    public GameObject[] actions;
    public int click = 0;

    //move
    [Space(20)]public CharacterController characterController;
    public Animator ani;
    //public float moveSpeed = 10;

    private void Start()
    {
        characterController = this.GetComponent<CharacterController>();
        ani = this.GetComponent<Animator>();
    }

    void Update()
    {
       

        if (Input.GetMouseButtonDown(0))
        {
            //ani.SetInteger("click", Random.Range(0, 16));
            click = Random.Range(0, 17); // 随机生成一个新的click值
            Debug.Log("click value reset to: " + click);
        }

        ani.SetInteger("click", click);
    }

 
}

