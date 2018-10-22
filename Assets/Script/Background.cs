using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    public float speed = 0.5f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(0f, Time.time * speed);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
