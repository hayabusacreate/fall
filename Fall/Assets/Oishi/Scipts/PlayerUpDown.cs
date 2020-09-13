using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpDown : MonoBehaviour
{
    public Player player;
    public bool updown;
    private bool moveflag;
    public bool back;
    private SceneChange sceneChange;
    // Start is called before the first frame update
    void Start()
    {
        sceneChange = GameObject.Find("SceneChange").GetComponent<SceneChange>();
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
            if(!updown&&!back)
            {
                if(other.gameObject.GetComponent<Block>().type=="3")
                {
                    sceneChange.endflag = true;
                }
            }
            if(!back&&updown)
            {
                player.pos.y = 0;
            }
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
                if(updown)
                {
                    player.rockmove = true;
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
                if (updown)
                {
                    player.rockmove = false;
                }
            }
        }
    }
}
