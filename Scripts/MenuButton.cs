using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuButton : MonoBehaviour

{
    //public Animator ani;
    public GameObject player;
    public Transform gPoint;
    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void SwitchScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    void ResetScene()
    {

    }
}
