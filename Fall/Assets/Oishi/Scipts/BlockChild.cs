using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockChild : MonoBehaviour
{
    public int rlud;
    public Block block;
    public bool hit;
    private bool childhit;
    public bool huck;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(block.type=="1")
        {
            if (rlud == 1)
            {
                block.rightmove = hit;
                block.righthuck = huck;
            }
            if (rlud == 2)
            {
                block.leftmove = hit;
                block.lefthuck = huck;
            }
            if (rlud == 3)
            {
                block.upmove = hit;
                block.uphuck = huck;
            }
            if (rlud == 4)
            {
                block.downmove = hit;
                block.downhuck = huck;
            }
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            if ((other.gameObject.GetComponent<Block>().rightmove && rlud == 1) ||
                (other.gameObject.GetComponent<Block>().leftmove && rlud == 2) ||
                (other.gameObject.GetComponent<Block>().upmove && rlud == 3) ||
                (other.gameObject.GetComponent<Block>().downmove && rlud == 4))
            {
                hit = true;
            }
            else
            {
                hit = false;
            }

        }
        if (other.gameObject.tag == "huck" )
        {
            huck = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            hit = false;
        }
        if (other.gameObject.tag == "huck" )
        {
            huck = false;
        }
    }
}
