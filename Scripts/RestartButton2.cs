using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartButton2 : MonoBehaviour

{
    //public Animator ani;
    public GameObject player;
    public Transform gPoint;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        //ani = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void SwitchScene()
    {
        SceneManager.LoadScene("SimpleSky_Demo");
    }

}
