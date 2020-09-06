using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType
{
    Up,
    Down,
    Right,
    Left
}

public class Player : MonoBehaviour
{
    public float speed;
    private Vector3 pos,jump;
    public float jumppower;
    private bool jumpFlag;
    public GameObject body,child;
    public PlayerType playerType;
    public bool rightroll,leftroll;
    private bool rockflag;
    public Child childscr;
    public bool rock;
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
        if(Input.GetKeyDown(KeyCode.R))
        {
            rock = !rock;
        }
        if(Input.GetKeyDown(KeyCode.S) && !child.GetComponent<Child>().under)
        {
            rockflag = true;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            rockflag = false;
        }
        if (playerType==PlayerType.Right)
        {
            pos.x = Input.GetAxis("Horizontal") * speed;
            if (Input.GetKey(KeyCode.Q)&&(!rightroll&&!leftroll))
            {
                leftroll = true;
                child.transform.parent = gameObject.transform;
                body.transform.parent = gameObject.transform;
            }
            else
            if (Input.GetKey(KeyCode.E) && (!rightroll && !leftroll))
            {
                rightroll = true;
                child.transform.parent = gameObject.transform;
                body.transform.parent = gameObject.transform;
            }
            if(rightroll)
            {
                transform.Rotate(0, 0, -1);
                float z = gameObject.transform.localEulerAngles.z;
                if (z <= 270)
                {
                    playerType = PlayerType.Down;
                    rightroll = false;
                    child.transform.parent = null;
                    body.transform.parent = null;
                }
            }
            else if(leftroll)
            {
                transform.Rotate(0, 0, 1);
                float z = gameObject.transform.localEulerAngles.z;
                if (z >= 90)
                {
                    playerType = PlayerType.Up;
                    leftroll = false;
                    child.transform.parent = null;
                    body.transform.parent = null;
                }
            }
            else
            if (rockflag)
            {
                body.transform.position = Vector3.Lerp(body.transform.position, transform.position, 1);
                if (child.transform.position.y != transform.position.y)
                {
                    body.transform.position = Vector3.Lerp(body.transform.position, transform.position, 1);
                    //child.transform.position = Vector3.Lerp(child.transform.position, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), Time.deltaTime * 10);
                    float range = Mathf.Abs(body.transform.position.y - transform.position.y);
                    if (range < 0.05)
                    {
                        body.transform.position = transform.position;
                        //child.transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                    }
                }
            }
            else
            {
                body.transform.position = Vector3.Lerp(body.transform.position, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Time.deltaTime * 10);
                //child.transform.position = Vector3.Lerp(child.transform.position, new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z), Time.deltaTime * 10);
                float range = Mathf.Abs(body.transform.position.y - transform.position.y + 1);
                if (range < 0.05)
                {
                    body.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                    //child.transform.position = new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z);
                }
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


            }
            else
            {
                pos.y -= Time.deltaTime ;
            }

        }
        if (playerType == PlayerType.Left)
        {
            pos.x = Input.GetAxis("Horizontal") * speed;
            if (Input.GetKey(KeyCode.Q) && (!rightroll && !leftroll))
            {
                leftroll = true;
                child.transform.parent = gameObject.transform;
                body.transform.parent = gameObject.transform;
            }
            else
            if (Input.GetKey(KeyCode.E) && (!rightroll && !leftroll))
            {
                rightroll = true;
                child.transform.parent = gameObject.transform;
                body.transform.parent = gameObject.transform;
            }
            if (rightroll)
            {
                transform.Rotate(0, 0, -1);
                float z = gameObject.transform.localEulerAngles.z;
                if (z <= 90)
                {
                    playerType = PlayerType.Up;
                    rightroll = false;
                    child.transform.parent = null;
                    body.transform.parent = null;
                }
            }
            else if (leftroll)
            {
                transform.Rotate(0, 0, 1);
                float z = gameObject.transform.localEulerAngles.z;
                if (z >= 270)
                {
                    playerType = PlayerType.Down;
                    leftroll = false;
                    child.transform.parent = null;
                    body.transform.parent = null;
                }
            }
            else
            if (rockflag)
            {
                body.transform.position = Vector3.Lerp(body.transform.position, transform.position, 1);
                if (child.transform.position.y != transform.position.y)
                {
                    body.transform.position = Vector3.Lerp(body.transform.position, transform.position, 1);
                    //child.transform.position = Vector3.Lerp(child.transform.position, new Vector3(transform.position.x-1, transform.position.y, transform.position.z), Time.deltaTime * 10);
                    float range = Mathf.Abs(body.transform.position.y - transform.position.y);
                    if (range < 0.05)
                    {
                        body.transform.position = transform.position;
                        //child.transform.position = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
                    }
                }
            }
            else
            {
                body.transform.position = Vector3.Lerp(body.transform.position, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Time.deltaTime * 10);
                //child.transform.position = Vector3.Lerp(child.transform.position, new Vector3(transform.position.x - 1, transform.position.y - 1, transform.position.z), Time.deltaTime * 10);
                float range = Mathf.Abs(body.transform.position.y - transform.position.y - 1);
                if (range < 0.05)
                {
                    body.transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
                    //child.transform.position = new Vector3(transform.position.x - 1, transform.position.y - 1, transform.position.z);
                }
            }
            if (jumpFlag)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    jump.y = 0;
                    jump.y = jumppower;
                    jumpFlag = false;
                    pos.y = jump.y;
                }

            }
            else
            {
                pos.y -= Time.deltaTime;
            }

        }
        if (playerType == PlayerType.Up)
        {
            pos.x = Input.GetAxis("Horizontal") * speed;
            if (Input.GetKey(KeyCode.Q) && (!rightroll && !leftroll))
            {
                child.transform.parent = gameObject.transform;
                body.transform.parent = gameObject.transform;
                leftroll = true;
            }
            else
            if (Input.GetKey(KeyCode.E) && (!rightroll && !leftroll))
            {
                rightroll = true;
                child.transform.parent = gameObject.transform;
                body.transform.parent = gameObject.transform;
            }
            if (rightroll)
            {
                transform.Rotate(0, 0, -1);
                float z = gameObject.transform.localEulerAngles.z;
                if (z <= 0||z>270)
                {
                    playerType = PlayerType.Right;
                    rightroll = false;
                    child.transform.parent = null;
                    body.transform.parent = null;
                }
            }
            else if (leftroll)
            {
                transform.Rotate(0, 0, 1);
                float z = gameObject.transform.localEulerAngles.z;
                if (z >= 180)
                {
                    playerType = PlayerType.Left;
                    leftroll = false;
                    child.transform.parent = null;
                    body.transform.parent = null;
                }
            }
            else

            if (rockflag)
            {
                body.transform.position = Vector3.Lerp(body.transform.position, transform.position, 1);
                if (child.transform.position.y != transform.position.y)
                {
                    body.transform.position = Vector3.Lerp(body.transform.position, transform.position, 1);
                    //child.transform.position = Vector3.Lerp(child.transform.position, new Vector3(transform.position.x , transform.position.y+1, transform.position.z), Time.deltaTime * 10);
                    float range = Mathf.Abs(body.transform.position.y - transform.position.y);
                    if (range < 0.05)
                    {
                        body.transform.position = transform.position;
                        //child.transform.position = new Vector3(transform.position.x, transform.position.y+1, transform.position.z);
                    }
                }
            }
            else
            {
                body.transform.position = Vector3.Lerp(body.transform.position, new Vector3(transform.position.x-1, transform.position.y, transform.position.z), Time.deltaTime * 10);
                //child.transform.position = Vector3.Lerp(child.transform.position, new Vector3(transform.position.x - 1, transform.position.y + 1, transform.position.z), Time.deltaTime * 10);
                float range = Mathf.Abs(body.transform.position.y - transform.position.y + 1);
                if (range < 0.05)
                {
                    body.transform.position = new Vector3(transform.position.x-1, transform.position.y, transform.position.z);
                    //child.transform.position = new Vector3(transform.position.x - 1, transform.position.y + 1, transform.position.z);
                }
            }
            if (jumpFlag)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    jump.y = 0;
                    jump.y = jumppower;
                    jumpFlag = false;
                    pos.y = jump.y;
                }

            }
            else
            {
                pos.y -= Time.deltaTime;
            }

        }
        if (playerType == PlayerType.Down)
        {
            pos.x = Input.GetAxis("Horizontal") * speed;
            if (Input.GetKey(KeyCode.Q) && (!rightroll && !leftroll))
            {
                child.transform.parent = gameObject.transform;
                body.transform.parent = gameObject.transform;
                leftroll = true;
            }
            else
            if (Input.GetKey(KeyCode.E) && (!rightroll && !leftroll))
            {
                child.transform.parent = gameObject.transform;
                body.transform.parent = gameObject.transform;
                rightroll = true;
            }
            if (rightroll)
            {
                transform.Rotate(0, 0, -1);
                float z = gameObject.transform.localEulerAngles.z;
                if (z <= 180)
                {
                    playerType = PlayerType.Left;
                    rightroll = false;
                    child.transform.parent = null;
                    body.transform.parent = null;
                }
            }
            else if (leftroll)
            {
                transform.Rotate(0, 0, 1);
                float z = gameObject.transform.localEulerAngles.z;
                if (z >= 0&&z<90)
                {
                    playerType = PlayerType.Right;
                    leftroll = false;
                    child.transform.parent = null;
                    body.transform.parent = null;
                }
            }
            else
            if (rockflag)
            {
                body.transform.position = Vector3.Lerp(body.transform.position, transform.position, 1);
                if (child.transform.position.y != transform.position.y)
                {
                    body.transform.position = Vector3.Lerp(body.transform.position, transform.position, 1);
                    //child.transform.position = Vector3.Lerp(child.transform.position, new Vector3(transform.position.x, transform.position.y-1, transform.position.z), Time.deltaTime * 10);
                    float range = Mathf.Abs(body.transform.position.y - transform.position.y);
                    if (range < 0.05)
                    {
                        body.transform.position = transform.position;
                        child.transform.position = new Vector3(transform.position.x , transform.position.y-1, transform.position.z);
                    }
                }
            }
            else
            {
                body.transform.position = Vector3.Lerp(body.transform.position, new Vector3(transform.position.x+1, transform.position.y , transform.position.z), Time.deltaTime * 10);
                child.transform.position = Vector3.Lerp(child.transform.position, new Vector3(transform.position.x + 1, transform.position.y - 1, transform.position.z), Time.deltaTime * 10);
                float range = Mathf.Abs(body.transform.position.y - transform.position.y);
                if (range < 0.05)
                {
                    body.transform.position = new Vector3(transform.position.x+1, transform.position.y , transform.position.z);
                    child.transform.position = new Vector3(transform.position.x + 1, transform.position.y - 1, transform.position.z);
                }
            }
            if (jumpFlag)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    jump.y = 0;
                    jump.y = jumppower;
                    jumpFlag = false;
                    pos.y = jump.y;
                }

            }
            else
            {
                pos.y -= Time.deltaTime;
            }

        }

        transform.position += pos;
        //rigidbody.AddForce(pos.x, pos.y, pos.z);
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag=="Ground")
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
