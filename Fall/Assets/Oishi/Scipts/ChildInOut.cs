using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildInOut : MonoBehaviour
{
    public bool inout;
    public bool rock;
    public Child child;
    public bool under;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!under)
        {
            if (!inout)
            {
                child.inrock = rock;
            }
            else
            {
                child.outrock = rock;
            }
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag!="Player")
        {
            rock = true;
            if(under)
            {
                child.under = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            rock = false;
            if (under)
            {
                child.under = false;
            }
        }
    }
}
