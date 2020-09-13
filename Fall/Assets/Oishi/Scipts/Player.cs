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
    // Start is called before the first frame update
    void Start()
    {
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
                    pos.y -= Time.deltaTime;
                    if (pos.y < -0.8f)
                    {
                        pos.y = -0.8f;
                    }
                }
                else
                {
                    if (pos.y <= 0)
                    {
                        pos.y = 0;
                        jumpFlag = true;
                    }

                }

            }
            pos.x = Time.deltaTime*Input.GetAxis("Horizontal") * speed;
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
                pos.x += Time.deltaTime*speed / 3;
            }
            transform.position += pos;
            if (Input.GetKey(KeyCode.Q) && (!rightroll && !leftroll&&!unrightroll&&!unleftroll))
            {
                leftroll = true;
                child.transform.parent = gameObject.transform;
                body.transform.parent = gameObject.transform;
            }
            //else
            //if (Input.GetKey(KeyCode.E) && (!rightroll && !leftroll))
            //{
            //    rightroll = true;
            //    child.transform.parent = gameObject.transform;
            //    body.transform.parent = gameObject.transform;
            //}
            if (unleftroll)
            {
                transform.Rotate(0, 0, -100*Time.deltaTime);
                float z = gameObject.transform.localEulerAngles.z;
                if (z >= 270||z==0)
                {
                    //playerType = PlayerType.Down;
                    unleftroll = false;
                    child.transform.parent = null;
                    body.transform.parent = null;
                }
            }
            else if (leftroll)
            {
                transform.Rotate(0, 0, 100*Time.deltaTime);
                float z = gameObject.transform.localEulerAngles.z;
                if (z >= 90)
                {
                    playerType = PlayerType.UpR;
                    leftroll = false;
                    child.transform.parent = null;
                    body.transform.parent = null;
                }
            }
            else
            if (rockflag)
            {
                body.transform.position = Vector3.Lerp(body.transform.position, transform.position, 10);
                //if (child.transform.position.y != transform.position.y)
                //{
                //    body.transform.position = Vector3.Lerp(body.transform.position, transform.position, 1);
                //    //child.transform.position = Vector3.Lerp(child.transform.position, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), Time.deltaTime * 10);
                //    float range = Mathf.Abs(body.transform.position.y - transform.position.y);
                //    if (range < 0.05)
                //    {
                //        body.transform.position = transform.position;
                //        //child.transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                //    }
                //}
            }
            else
            {
                body.transform.position = Vector3.Lerp(body.transform.position, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), 10);
                //child.transform.position = Vector3.Lerp(child.transform.position, new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z), Time.deltaTime * 10);
                float range = Mathf.Abs(body.transform.position.y - transform.position.y + 1);
                if (range < 0.05)
                {
                    body.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                    //child.transform.position = new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z);
                }
            }


        }
        if (playerType == PlayerType.Left)
        {
            if (child.GetComponent<Child>().outrock)
            {
                float distance = Mathf.Abs(Vector3.Distance(transform.position, child.transform.position));
                if (distance < 1.2f)
                {
                    leftmove = true;
                }
                else
                {
                    leftmove= false;
                }
            }
            else
            {
                leftmove = false;
            }
            if (jumpFlag)
            {
                pos.y = 0;
                if (Input.GetKeyDown(KeyCode.Space))
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
                    pos.y -= Time.deltaTime;
                    if (pos.y < -0.8f)
                    {
                        pos.y = -0.8f;
                    }
                }
                else
                {
                    if (pos.y <= 0)
                    {
                        pos.y = 0;
                        jumpFlag = true;
                    }

                }

            }
            pos.x = Time.deltaTime * Input.GetAxis("Horizontal") * speed;
            if ((rock && child.GetComponent<Child>().inrock && pos.x > 0&&child.GetComponent<Child>().inblock.GetComponent<Block>().rightmove) ||
                (rock && child.GetComponent<Child>().outrock && pos.x < 0 && child.GetComponent<Child>().outblock.GetComponent<Block>().leftmove)||
                (leftmove && pos.x < 0) || (rightmove && pos.x > 0) || (downmove == false && jumpFlag && rockflag) ||
                ((rock && child.GetComponent<Child>().inrock && pos.x > 0 && child.GetComponent<Child>().inblock.GetComponent<Block>().playerrayd)))
            {
                pos.x = 0;
            }
            range = Mathf.Abs(Vector3.Distance(body.transform.position, child.transform.position));
            if (range > 1.3 && !rock)
            {
                pos.x -= Time.deltaTime*speed / 3;
            }

            //if (Input.GetKey(KeyCode.Q) && (!rightroll && !leftroll))
            //{
            //    leftroll = true;
            //    child.transform.parent = gameObject.transform;
            //    body.transform.parent = gameObject.transform;
            //}
            if (Input.GetKey(KeyCode.E) && (!rightroll && !leftroll && !unrightroll && !unleftroll))
            {
                rightroll = true;
                child.transform.parent = gameObject.transform;
                body.transform.parent = gameObject.transform;
            }
            transform.position += pos;
            if (rightroll)
            {
                transform.Rotate(0, 0, 100 * Time.deltaTime);
                float z = gameObject.transform.localEulerAngles.z;
                if (z >=90)
                {
                    playerType = PlayerType.UpL;
                    rightroll = false;
                    child.transform.parent = null;
                    body.transform.parent = null;
                    rightmove = false;
                    leftmove = false;
                    upmove = false;
                    downmove = false;
                }
            }
            else if (unrightroll)
            {
                transform.Rotate(0, 0, -100 * Time.deltaTime);
                float z = gameObject.transform.localEulerAngles.z;
                if (z >= 270)
                {
                    //playerType = PlayerType.Down;
                    unrightroll = false;
                    child.transform.parent = null;
                    body.transform.parent = null;
                    rightmove = false;
                    leftmove = false;
                    upmove = false;
                    downmove = false;
                }
            }
            else
            if (rockflag)
            {
                body.transform.position = Vector3.Lerp(body.transform.position, transform.position, 1);
                //if (child.transform.position.y != transform.position.y)
                //{
                //    body.transform.position = Vector3.Lerp(body.transform.position, transform.position, 1);
                //    //child.transform.position = Vector3.Lerp(child.transform.position, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), Time.deltaTime * 10);
                //    float range = Mathf.Abs(body.transform.position.y - transform.position.y);
                //    if (range < 0.05)
                //    {
                //        body.transform.position = transform.position;
                //        //child.transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                //    }
                //}
            }
            else
            {
                body.transform.position = Vector3.Lerp(body.transform.position, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), 1);
                //child.transform.position = Vector3.Lerp(child.transform.position, new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z), Time.deltaTime * 10);
                float range = Mathf.Abs(body.transform.position.y - transform.position.y + 1);
                if (range < 0.05)
                {
                    body.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                    //child.transform.position = new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z);
                }
            }



        }
        if (playerType == PlayerType.UpR)
        {

            pos.x = Time.deltaTime * Input.GetAxis("Horizontal") * speed;
            if ((upmove && pos.x < 0) || (downmove && pos.x > 0) || 
                (((child.GetComponent<Child>().under && pos.x > 0)|| (child.GetComponent<Child>().up && pos.x < 0)))||
                ((bodyscr.under&&pos.x>0)|| (bodyscr.up && pos.x < 0))
                )
            {
                pos.x = 0;
            }
            range = Mathf.Abs(Vector3.Distance(body.transform.position, child.transform.position));
            //if (range > 1.2 && !rock)
            //{
            //    pos.y += speed / 3;
            //}
            transform.position += pos ;
            if (Input.GetKey(KeyCode.Q) && (!rightroll && !leftroll && !unrightroll && !unleftroll))
            {
                leftroll = true;
                child.transform.parent = gameObject.transform;
                body.transform.parent = gameObject.transform;
            }
            else
            if (Input.GetKey(KeyCode.E) && (!rightroll && !leftroll && !unrightroll && !unleftroll))
            {
                rightroll = true;
                child.transform.parent = gameObject.transform;
                body.transform.parent = gameObject.transform;
            }
            if (rightroll)
            {
                transform.Rotate(0, 0, -100 * Time.deltaTime);
                float z = gameObject.transform.localEulerAngles.z;
                if (z <= 0 || z > 270)
                {
                    playerType = PlayerType.Right;
                    rightroll = false;
                    child.transform.parent = null;
                    body.transform.parent = null;
                    rightmove = false;
                    leftmove = false;
                    upmove = false;
                    downmove = false;
                }
            }
            else if (leftroll)
            {
                transform.Rotate(100 * Time.deltaTime, 0, 0);
                float z = gameObject.transform.localEulerAngles.y;
                if (z >= 180)
                {
                    playerType = PlayerType.UpL;
                    leftroll = false;
                    child.transform.parent = null;
                    body.transform.parent = null;
                    rightmove = false;
                    leftmove = false;
                    upmove = false;
                    downmove = false;
                }
            }else
            if(unrightroll)
            {
                transform.Rotate(0, 0, 100 * Time.deltaTime);
                float z = gameObject.transform.localEulerAngles.z;
                if (z >= 90)
                {
                    //playerType = PlayerType.UpL;
                    unrightroll = false;
                    child.transform.parent = null;
                    body.transform.parent = null;
                    rightmove = false;
                    leftmove = false;
                    upmove = false;
                    downmove = false;
                }
            }else if(unleftroll)
            {
                transform.Rotate(-100 * Time.deltaTime, 0, 0);
                float z = gameObject.transform.localEulerAngles.y;
                if (z>=270||z==0)
                {
                    //playerType = PlayerType.Right;
                    unleftroll = false;
                    child.transform.parent = null;
                    body.transform.parent = null;
                    rightmove = false;
                    leftmove = false;
                    upmove = false;
                    downmove = false;
                }
            }
            else
            if (rockflag)
            {
                body.transform.position = Vector3.Lerp(body.transform.position, transform.position, 1);
                //if (child.transform.position.x != transform.position.x)
                //{
                //    body.transform.position = Vector3.Lerp(body.transform.position, transform.position, 1);
                //    //child.transform.position = Vector3.Lerp(child.transform.position, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), Time.deltaTime * 10);
                //    float range = Mathf.Abs(body.transform.position.x - transform.position.x);
                //    if (range < 0.05)
                //    {
                //        body.transform.position = transform.position;
                //        //child.transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                //    }
                //}
            }
            else
            {
                body.transform.position = Vector3.Lerp(body.transform.position, new Vector3(transform.position.x+1, transform.position.y, transform.position.z), 1);
                //child.transform.position = Vector3.Lerp(child.transform.position, new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z), Time.deltaTime * 10);
                float range = Mathf.Abs(body.transform.position.x - transform.position.x - 1);
                if (range < 0.05)
                {
                    body.transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
                    //child.transform.position = new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z);
                }
            }
            if (jumpFlag)
            {
                pos.y = 0;
                //if (Input.GetKeyDown(KeyCode.Space))
                //{
                //    jump.y = jumppower;
                //    jumpFlag = false;
                //    pos.y = jump.y;
                //}


            }
            else
            {
                if ((!rock)||(!child.GetComponent<Child>().inrock&&rock)||
                    (child.GetComponent<Child>().inrock && rock && !child.GetComponent<Child>().inblock.GetComponent<Block>().downmove))
                {
                    pos.y -= Time.deltaTime;
                }else
                {
                    pos.y = 0;
                }

            }

        }
        if (playerType == PlayerType.UpL)
        {
            pos.x = Time.deltaTime*Input.GetAxis("Horizontal") * speed;
            if ( (downmove && pos.x < 0) || (upmove && pos.x > 0) ||
                (((child.GetComponent<Child>().under && pos.x < 0) || (child.GetComponent<Child>().up && pos.x > 0))) ||
                ( (bodyscr.under && pos.x < 0) || (bodyscr.up && pos.x > 0))
                )
            {
                pos.x = 0;
            }
            range = Mathf.Abs(Vector3.Distance(body.transform.position, child.transform.position));
            //if (range > 1.2 && !rock)
            //{
            //    pos.y += speed / 3;
            //}
            transform.position += pos ;
            if (Input.GetKey(KeyCode.Q) && (!rightroll && !leftroll && !unrightroll && !unleftroll))
            {
                leftroll = true;
                child.transform.parent = gameObject.transform;
                body.transform.parent = gameObject.transform;
            }
            else
            if (Input.GetKey(KeyCode.E) && (!rightroll && !leftroll && !unrightroll && !unleftroll))
            {
                rightroll = true;
                child.transform.parent = gameObject.transform;
                body.transform.parent = gameObject.transform;
            }
            if (rightroll)
            {
                transform.Rotate(-100 * Time.deltaTime, 0, 0);
                float z = gameObject.transform.localEulerAngles.y;
                if (z <= 0 || z > 270)
                {
                    playerType = PlayerType.UpR;
                    rightroll = false;
                    child.transform.parent = null;
                    body.transform.parent = null;
                    rightmove = false;
                    leftmove = false;
                    upmove = false;
                    downmove = false;
                }
            }
            else if (leftroll)
            {
                transform.Rotate(0, 0, -100 * Time.deltaTime);
                float z = gameObject.transform.localEulerAngles.z;
                if (z >= 180)
                {
                    playerType = PlayerType.Left;
                    leftroll = false;
                    child.transform.parent = null;
                    body.transform.parent = null;
                    rightmove = false;
                    leftmove = false;
                    upmove = false;
                    downmove = false;
                }
            } else if (unrightroll)
            {
                transform.Rotate(100 * Time.deltaTime, 0, 0);
                float z = gameObject.transform.localEulerAngles.y;
                if (z>=180)
                {
                    //playerType = PlayerType.UpR;
                    unrightroll = false;
                    child.transform.parent = null;
                    body.transform.parent = null;
                    rightmove = false;
                    leftmove = false;
                    upmove = false;
                    downmove = false;
                }
            } else if (unleftroll)
            {
                transform.Rotate(0, 0, 100 * Time.deltaTime);
                float z = gameObject.transform.localEulerAngles.z;
                if (z >=90)
                {
                    //playerType = PlayerType.Left;
                    unleftroll = false;
                    child.transform.parent = null;
                    body.transform.parent = null;
                    rightmove = false;
                    leftmove = false;
                    upmove = false;
                    downmove = false;
                }
            }
            else
            if (rockflag)
            {
                body.transform.position = Vector3.Lerp(body.transform.position, transform.position, 1);
                if (child.transform.position.x != transform.position.x)
                {
                    body.transform.position = Vector3.Lerp(body.transform.position, transform.position, 1);
                    //child.transform.position = Vector3.Lerp(child.transform.position, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), Time.deltaTime * 10);
                    float range = Mathf.Abs(body.transform.position.x - transform.position.x);
                    if (range < 0.05)
                    {
                        body.transform.position = transform.position;
                        //child.transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                    }
                }
            }
            else
            {
                body.transform.position = Vector3.Lerp(body.transform.position, new Vector3(transform.position.x+1, transform.position.y, transform.position.z), 1);
                //child.transform.position = Vector3.Lerp(child.transform.position, new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z), Time.deltaTime * 10);
                float range = Mathf.Abs(body.transform.position.x - transform.position.x + 1);
                if (range < 0.05)
                {
                    body.transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                    //child.transform.position = new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z);
                }
            }
            if (jumpFlag)
            {
                pos.y = 0;
                //if (Input.GetKeyDown(KeyCode.Space))
                //{
                //    jump.y = jumppower;
                //    jumpFlag = false;
                //    pos.y = jump.y;
                //}


            }
            else
            {
                if ((!rock) || (!child.GetComponent<Child>().inrock && rock) ||
                    (child.GetComponent<Child>().inrock && rock && !child.GetComponent<Child>().inblock.GetComponent<Block>().downmove))
                {
                    pos.y -= Time.deltaTime;
                }
                else
                {
                    pos.y = 0;
                }
            }

        }
        //if (playerType == PlayerType.Down)
        //{
        //    pos.x = Input.GetAxis("Horizontal") * speed;
        //    range = Mathf.Abs(Vector3.Distance(transform.position, child.transform.position));
        //    if (range > 1.2 && !rock)
        //    {
        //        pos.y -= speed / 3;
        //    }
        //    if (Input.GetKey(KeyCode.Q) && (!rightroll && !leftroll))
        //    {
        //        child.transform.parent = gameObject.transform;
        //        body.transform.parent = gameObject.transform;
        //        leftroll = true;
        //    }
        //    else
        //    if (Input.GetKey(KeyCode.E) && (!rightroll && !leftroll))
        //    {
        //        child.transform.parent = gameObject.transform;
        //        body.transform.parent = gameObject.transform;
        //        rightroll = true;
        //    }
        //    if (rightroll)
        //    {
        //        transform.Rotate(0, 0, -1);
        //        float z = gameObject.transform.localEulerAngles.z;
        //        if (z <= 180)
        //        {
        //            playerType = PlayerType.Left;
        //            rightroll = false;
        //            child.transform.parent = null;
        //            body.transform.parent = null;
        //            rightmove = false;
        //            leftmove = false;
        //            upmove = false;
        //            downmove = false;
        //        }
        //    }
        //    else if (leftroll)
        //    {
        //        transform.Rotate(0, 0, 1);
        //        float z = gameObject.transform.localEulerAngles.z;
        //        if (z >= 0 && z < 90)
        //        {
        //            playerType = PlayerType.Right;
        //            leftroll = false;
        //            child.transform.parent = null;
        //            body.transform.parent = null;
        //            rightmove = false;
        //            leftmove = false;
        //            upmove = false;
        //            downmove = false;
        //        }
        //    }
        //    else
        //    if (rockflag)
        //    {
        //        body.transform.position = Vector3.Lerp(body.transform.position, transform.position, 1);
        //        if (child.transform.position.y != transform.position.y)
        //        {
        //            body.transform.position = Vector3.Lerp(body.transform.position, transform.position, 1);
        //            //child.transform.position = Vector3.Lerp(child.transform.position, new Vector3(transform.position.x, transform.position.y-1, transform.position.z), Time.deltaTime * 10);
        //            float range = Mathf.Abs(body.transform.position.y - transform.position.y);
        //            if (range < 0.05)
        //            {
        //                body.transform.position = transform.position;
        //                child.transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        body.transform.position = Vector3.Lerp(body.transform.position, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), Time.deltaTime * 10);
        //        child.transform.position = Vector3.Lerp(child.transform.position, new Vector3(transform.position.x + 1, transform.position.y - 1, transform.position.z), Time.deltaTime * 10);
        //        float range = Mathf.Abs(body.transform.position.y - transform.position.y);
        //        if (range < 0.05)
        //        {
        //            body.transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        //            child.transform.position = new Vector3(transform.position.x + 1, transform.position.y - 1, transform.position.z);
        //        }
        //    }
        //    if (jumpFlag)
        //    {
        //        if (Input.GetKeyDown(KeyCode.Space))
        //        {
        //            jump.y = 0;
        //            jump.y = jumppower;
        //            jumpFlag = false;
        //            pos.y = jump.y;
        //        }

        //    }
        //    else
        //    {
        //        if (!moveflag)
        //            pos.y -= Time.deltaTime;
        //    }
        //    if (rock && child.GetComponent<Child>().inrock && pos.y < 0)
        //    {
        //        pos.y = 0;
        //    }

        //}

        //rigidbody.AddForce(pos.x, pos.y, pos.z);
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpFlag = true;
            //moveflag = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpFlag = false;
            //moveflag = false;
        }
    }
}
