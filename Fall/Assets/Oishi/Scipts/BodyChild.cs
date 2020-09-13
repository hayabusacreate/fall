using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyChild : MonoBehaviour
{
    public bool updown;
    public bool hit;
    public Body body;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (updown)
        {
            body.up = hit;
        }
        else
        {
            body.under = hit;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag=="Ground")
        {
            hit = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            hit = false;
        }
    }
}
