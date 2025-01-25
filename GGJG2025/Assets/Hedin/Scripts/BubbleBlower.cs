using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBlower : MonoBehaviour
{
    public Transform Blower;
    public GameObject Bubble;
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Bubble, Blower.position, Blower.rotation);
        }
    }
}