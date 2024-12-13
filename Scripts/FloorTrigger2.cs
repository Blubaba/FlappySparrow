using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FloorTrigger2 : MonoBehaviour
{
    public Animator ani;
    public float score;
    public GameObject ui;
    public GameObject prefab;
    public Transform gPoint;
    public GameObject player;
    public GameObject gameOver;
    public GameObject Flower;
    public GameObject victory;
    

    // Start is called before the first frame update
    void Start()
    {
        ani = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void OnCollisionEnter(Collision other)
    {
        throw new NotImplementedException();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("floor"))
        {
            ani.SetBool(name:"Death", value:true);
            gameOver.SetActive(true);
        }

        if(other.gameObject.CompareTag("cake"))
        {
            Debug.Log("Eat start");
            ani.SetTrigger(name:"Eat");

            score += 10;
            ui.GetComponent<Text>().text = score.ToString();

            if (score >= 300)
            {
                victory.SetActive(true);
                ani.SetTrigger(name:"win");
            }
        }

        if(other.gameObject.CompareTag("flower1"))
        {
            Transform targetTransform = GameObject.FindGameObjectWithTag("gPoint3").transform;
            this.transform.position = targetTransform.position;
            this.transform.rotation = targetTransform.rotation;
        }

        if(other.gameObject.CompareTag("flower2"))
        {
            Transform targetTransform = GameObject.FindGameObjectWithTag("gPoint4").transform;
            this.transform.position = targetTransform.position;
            this.transform.rotation = targetTransform.rotation;
        }

    }

    private void OnTriggerExit(Collider other)
    {

        if(other.gameObject.CompareTag("cake"))
        {
            Debug.Log("Eat end");
            ani.SetTrigger(name:"Eat");
        }
        
    }

    void OnTriggerStay(Collider other)
    {

    }
}
