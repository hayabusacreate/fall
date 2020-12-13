using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType
{
    UpR,
    UpL,
    Down,
    Right,
    Left
}

public class Player : MonoBehaviour
{
    public float speed;
    public Vector3 pos, jump;
    public float jumppower;
    public bool jumpFlag;
    public GameObject body, child;
    public Body bodyscr;
    public PlayerType playerType;
    public bool rightroll, leftroll,unrightroll,unleftroll;
    private bool rockflag;
    public Child childscr;
    public bool rock;
    private bool roolflag;
    private float range;
    public bool moveflag, rightmove, leftmove,upmove,downmove,rockmove;
    public AudioClip kati;
    public AudioSource audioSource,sya,guruguru;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = null;
        playerType = PlayerType.Right;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            rock = !rock;
            child.GetComponent<Child>().range = Vector3.Distance(child.transform.position, child.GetComponent<Child>().head.transform.position);
            audioSource.PlayOneShot(kati);
        }
        if (Input.GetKeyDown(KeyCode.S) &&( (playerType==PlayerType.Right&&!child.GetComponent<Child>().under)||(playerType==PlayerType.Left&&!child.GetComponent<Child>().under)))
        {
            rockflag = true;
        }
        if (Input.GetKeyDown(KeyCode.W) && ((playerType == PlayerType.Right && !child.GetComponent<Child>().up) || (playerType == PlayerType.Left && !child.GetComponent<Child>().up)))
        {
            rockflag = false;
        }
        if (playerType == PlayerType.Right)
        {
            if(child.GetComponent<Child>().inrock)
            {
                float distance = Mathf.Abs(Vector3.Distance(transform.position, child.transform.position));
                if (Input.GetAxis("Horizontal")<0)
                {
                    if (!sya.isPlaying)
                        sya.Play();
                    guruguru.Stop();
                }else if(distance>1.3f)
                {
                    sya.Stop();
                    if(!guruguru.isPlaying)
                    guruguru.Play();
                }
            }else
            {
                sya.Stop();
                guruguru.Stop();
            }
            if (child.GetComponent<Child>().outrock)
            {
                float distance = Mathf.Abs(Vector3.Distance(transform.position, child.transform.position));
                if(distance<1.2f)
                {
                    rightmove = true;
                }else
                {
                    rightmove = false;
                }
            }
            else
            {
                rightmove = false;
            }
            if (jumpFlag)
            {
                pos.y = 0;
                if (Input.GetKeyDown(KeyCode.Space)&&!bodyscr.up&&!child.GetComponent<Child>().up)
                {
                    jump.y = jumppower;
                    jumpFlag = false;
                    pos.y = jump.y;
                }

                if (!bodyscr.under && !child.GetComponent<Child>().under)
                {
                    jumpFlag = false;
                }
            }
            else
            {
                if (!bodyscr.under && !child.GetComponent<Child>().under)
                {
                    pos.y -= 3f*Time.deltaTime;
                    if (pos.y < -2f)
                    {
                        pos.y = -2f;
                    }
                }
                else
                {
                    //if (pos.y <= 0)
                    //{
                    //    pos.y = 0;
                    //    jumpFlag = true;
                    //}

                }

            }
            pos.x = Input.GetAxis("Horizontal") * speed*Time.deltaTime;
            if ((rock && child.GetComponent<Child>().inrock && pos.x < 0 &&child.GetComponent<Child>().inblock.GetComponent<Block>().leftmove)||
                (rock && child.GetComponent<Child>().outrock && pos.x > 0&& child.GetComponent<Child>().outblock.GetComponent<Block>().rightmove)
                || (leftmove && pos.x < 0) || (rightmove && pos.x > 0)||(downmove==false&&jumpFlag&&rockflag)||
                ((rock && child.GetComponent<Child>().inrock && pos.x < 0 && child.GetComponent<Child>().inblock.GetComponent<Block>().playerrayd))||
                (rockmove&&pos.x>0))
            {
                pos.x = 0;
            }
            range = Mathf.Abs(Vector3.Distance(body.transform.position, child.transform.position));
            if (range > 1.3 && !rock)
            {
                //pos.x += speed *Time.deltaTime;
            }
            transform.position += pos*Time.deltaTime;
            if (rockflag)
            {
                body.transform.position = Vector3.Lerp(body.transform.position, transform.position, 10*Time.deltaTime);
            }
            else
            {
                body.transform.position = Vector3.Lerp(body.transform.position, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), 10*Time.deltaTime);
                float range = Mathf.Abs(body.transform.position.y - transform.position.y + 1);
                if (range < 0.05)
                {
                    body.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                }
            }


        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpFlag = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpFlag = false;
        }
    }
}
