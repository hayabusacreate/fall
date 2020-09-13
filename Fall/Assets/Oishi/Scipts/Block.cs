using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public string type;
    public Collider collider;
    public Player player;
    public bool rightmove, leftmove, upmove, downmove;
    public bool righthuck, lefthuck, uphuck, downhuck;
    private SceneChange sceneChange;
    public bool playerrayd;
    public GameObject goal, anrock, rockobj;
    // Start is called before the first frame update
    void Start()
    {
        if(type=="0")
        {
            Destroy(gameObject);
        }else if(type=="1")
        {
            collider.enabled = true;
            player = GameObject.Find("Player").GetComponent<Player>();
            goal.SetActive(false);
            anrock.SetActive(true);
            rockobj.SetActive(false);
        }else if(type=="2")
        {
            collider.enabled = true;
            player = GameObject.Find("Player").GetComponent<Player>();
            goal.SetActive(false);
            anrock.SetActive(false);
            rockobj.SetActive(true);
        }
        else if(type=="3")
        {
            collider.enabled = true;
            player = GameObject.Find("Player").GetComponent<Player>();
            sceneChange = GameObject.Find("SceneChange").GetComponent<SceneChange>();
            goal.SetActive(true);
            anrock.SetActive(false);
            rockobj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.playerType == PlayerType.UpR)
        {
            if (!downmove && uphuck)
            {
                if (player.rock && player.pos.y < 0)
                {
                    transform.position += new Vector3(0, player.pos.y * Time.deltaTime, 0);
                }
            }
        }
        if (player.playerType == PlayerType.UpL)
        {
            if (!downmove && uphuck)
            {
                if (player.rock && player.pos.y < 0)
                {
                    transform.position += new Vector3(0, player.pos.y * Time.deltaTime, 0);
                }
            }
        }
        if (!player.jumpFlag)
        {
            playerrayd = false;
        }
        if(!playerrayd)
        {
            if (player.playerType == PlayerType.Right)
            {
                if (!leftmove && righthuck)
                {
                    if (player.rock && player.pos.x < 0)
                    {
                        transform.position += new Vector3(player.pos.x*Time.deltaTime, 0, 0);
                    }
                }
                if (!rightmove && lefthuck)
                {
                    if (player.rock && player.pos.x > 0)
                    {
                        transform.position += new Vector3(player.pos.x * Time.deltaTime, 0, 0);
                    }
                }
            }
            if (player.playerType == PlayerType.Left)
            {
                if (!rightmove && lefthuck)
                {
                    if (player.rock && player.pos.x > 0)
                    {
                        transform.position += new Vector3(player.pos.x * Time.deltaTime, 0, 0);
                    }
                }
                if (!leftmove && righthuck)
                {
                    if (player.rock && player.pos.x < 0)
                    {
                        transform.position += new Vector3(player.pos.x * Time.deltaTime, 0, 0);
                    }
                }
            }

        }

    }
    private void OnCollisionStay(Collision collision)
    {
        //if(type=="3")
        //{
        //    if (collision.gameObject.tag == "Player")
        //    {
        //        sceneChange.endflag = true;
        //    }
        //}
        if(type!="2")
        {
            if (collision.gameObject.tag == "Player")
            {
                playerrayd = true;
            }
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (type != "2")
        {
            if (collision.gameObject.tag == "Player")
            {
                playerrayd = false;
            }
        }
    }
}
