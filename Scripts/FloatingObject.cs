using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    public float amplitude = 0.5f;
    public float frequency = 1f;
    public float rotationSpeed = 10f;

    private Vector3 _initialPostion;

    // Start is called before the first frame update
    void Start()
    {
        _initialPostion = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newY = _initialPostion.y + amplitude * Mathf.Sin(Time.time * frequency);
        transform.position = new Vector3(transform.position.x , newY , transform.position.z);
        transform.Rotate(new Vector3(0f , rotationSpeed * Time.deltaTime,0f),Space.World);
        
    }
}
