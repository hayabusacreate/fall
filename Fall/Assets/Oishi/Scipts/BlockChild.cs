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
    public Block saveblock;
    // Start is called before the first frame update
    void Start()
    {
        saveblock = block;
    }

    // Update is called once per frame
    void Update()
    {
        if (block.type != "2")
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
            if (other.gameObject.GetComponent<Block>().playerrayd)
            {
                block.playerrayd = true;
            }
            saveblock = other.gameObject.GetComponent<Block>();
            if ((other.gameObject.GetComponent<Block>().rightmove && rlud == 1) ||
                (other.gameObject.GetComponent<Block>().leftmove && rlud == 2) ||
                (other.gameObject.GetComponent<Block>().upmove && rlud == 3) ||
                (other.gameObject.GetComponent<Block>().downmove && rlud == 4))
            {
                hit = true;
                saveblock = other.gameObject.GetComponent<Block>();
            }
            else
            {
                hit = false;
                if ((other.gameObject.GetComponent<Block>().righthuck && rlud == 1) ||
    (other.gameObject.GetComponent<Block>().lefthuck && rlud == 2) ||
    (other.gameObject.GetComponent<Block>().uphuck && rlud == 3) ||
    (other.gameObject.GetComponent<Block>().downhuck && rlud == 4))
                {
                    huck = true;

                }else
                {
                    huck = false;
                }
                saveblock = other.gameObject.GetComponent<Block>();
                //huck = false;
            }
            


        }
        if (block.type != "2")
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
        if (other.gameObject.tag == "huck")
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
        if (other.gameObject.tag == "huck")
        {
            huck = false;
            block.righthuck = false;

            block.lefthuck = false;

            block.uphuck = false;

            block.downhuck = false;
            saveblock.righthuck = false;

            saveblock.lefthuck = false;

            saveblock.uphuck = false;

            saveblock.downhuck = false;

        }
    }
}
