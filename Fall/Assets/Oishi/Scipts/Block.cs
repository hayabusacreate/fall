using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public string type;
    public Collider collider;
    private Player player;
    public bool rightmove, leftmove, upmove, downmove;
    public bool righthuck, lefthuck, uphuck, downhuck;
    private SceneChange sceneChange;
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
        }else if(type=="2")
        {
            collider.enabled = true;
            player = GameObject.Find("Player").GetComponent<Player>();
        }
        else if(type=="3")
        {
            collider.enabled = true;
            player = GameObject.Find("Player").GetComponent<Player>();
            sceneChange = GameObject.Find("SceneChange").GetComponent<SceneChange>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player.playerType==PlayerType.Right)
        {
            if(!leftmove&&righthuck)
            {
                if(player.rock&&player.pos.x<0)
                {
                    transform.position += new Vector3(player.pos.x, 0, 0);
                }
            }
            if (!rightmove && lefthuck)
            {
                if (player.rock && player.pos.x > 0)
                {
                    transform.position += new Vector3(player.pos.x, 0, 0);
                }
            }
        }
        if (player.playerType == PlayerType.Left)
        {
            if (!rightmove && lefthuck)
            {
                if (player.rock && player.pos.x > 0)
                {
                    transform.position += new Vector3(player.pos.x, 0, 0);
                }
            }
            if (!leftmove && righthuck)
            {
                if (player.rock && player.pos.x < 0)
                {
                    transform.position += new Vector3(player.pos.x, 0, 0);
                }
            }
        }
        if (player.playerType == PlayerType.UpR)
        {
            if (!downmove &&uphuck)
            {
                if (player.rock&&player.pos.y<0)
                {
                    transform.position += new Vector3(0, player.pos.y, 0);
                }
            }
        }
        if (player.playerType == PlayerType.UpL)
        {
            if (!downmove && uphuck)
            {
                if (player.rock && player.pos.y < 0)
                {
                    transform.position += new Vector3(0, player.pos.y, 0);
                }
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if(type=="3")
        {
            if (collision.gameObject.tag == "Player")
            {
                sceneChange.endflag = true;
            }
        }

    }
}
