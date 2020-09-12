using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpDown : MonoBehaviour
{
    public Player player;
    public bool updown;
    private bool moveflag;
    public bool back;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!back)
        {
            if (updown)
            {
                player.upmove = moveflag;
            }
            else
            {
                player.downmove = moveflag;
            }
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            moveflag = true;
        }
        if (other.gameObject.tag=="Ground")
        {

            if(back)
            {
                if (player.playerType == PlayerType.Right)
                {
                    player.leftmove = true;
                }
                if (player.playerType == PlayerType.Left)
                {
                    player.rightmove = true;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            moveflag = false;
        }
        if (other.gameObject.tag == "Ground")
        {

            if (back)
            {
                if (player.playerType == PlayerType.Right)
                {
                    player.leftmove = false;
                }
                if (player.playerType == PlayerType.Left)
                {
                    player.rightmove = false;
                }
            }
        }
    }
}
