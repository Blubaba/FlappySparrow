using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleText : MonoBehaviour
{
    public float scaleDuration = 1f;
    public float scaleIntensity = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Scale());
    }

    IEnumerator Scale()
    {
        while (true)
        {
            LeanTween.scale(gameObject, Vector3.one * scaleIntensity, scaleDuration / 2).setEaseOutQuad();
            yield return new WaitForSeconds(scaleDuration / 2);

            LeanTween.scale(gameObject, Vector3.one, scaleDuration / 2).setEaseInQuad();
            yield return new WaitForSeconds(scaleDuration / 2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
