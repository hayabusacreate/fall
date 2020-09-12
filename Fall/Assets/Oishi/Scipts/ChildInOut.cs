using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildInOut : MonoBehaviour
{
    public bool inout;
    public bool rock;
    public Child child;
    public bool under;
    public bool up;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        rock = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!under && !up)
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
        if (other.gameObject.tag == "Ground")
        {
            //if (other.gameObject.GetComponent<Block>().leftmove && player.playerType == PlayerType.Right ||
            //    other.gameObject.GetComponent<Block>().rightmove && player.playerType == PlayerType.Left ||
            //    other.gameObject.GetComponent<Block>().downmove && player.playerType == PlayerType.UpL ||
            //    other.gameObject.GetComponent<Block>().downmove && player.playerType == PlayerType.UpR)
            //{
            //    rock = true;
            //}
            //else
            //{
            //    rock = false;
            //}
            rock = true;
            if (!inout)
            {
                child.GetComponent<Child>().inblock = other.gameObject.GetComponent<Block>();
            }
            else
            {
                child.GetComponent<Child>().outblock = other.gameObject.GetComponent<Block>();
            }

            if (under)
            {
                child.under = true;
            }
            if (up)
            {
                child.up = true;
            }
        }


    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            rock = false;
            if (under)
            {
                child.under = false;
            }
            if (up)
            {
                child.up = false;
            }
        }
    }
}
