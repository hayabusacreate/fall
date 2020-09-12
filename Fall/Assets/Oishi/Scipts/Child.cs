using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : MonoBehaviour
{
    public GameObject player, head;
    public float range;
    public bool inrock, outrock;
    public bool under,up;
    private float x;
    public float distance;
    public Block inblock,outblock;
    // Start is called before the first frame update
    void Start()
    {
        range = 1;
        //inrock = false;
        outrock = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.GetComponent<Player>().rightroll && !player.GetComponent<Player>().leftroll&& !player.GetComponent<Player>().unrightroll&& !player.GetComponent<Player>().unleftroll)
        {

            if (player.GetComponent<Player>().playerType == PlayerType.Right)
            {
                distance = Mathf.Abs(Vector3.Distance(transform.position, head.transform.position));

                if (!player.GetComponent<Player>().rock)
                {
                    range = 1;
                    if (Input.GetAxis("Horizontal") > 0)
                    {
                        if (inrock)
                        {
                            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, head.transform.position.y - 0.5f, head.transform.position.z), 1);
                            distance = Mathf.Abs(Vector3.Distance(transform.position, head.transform.position));
                            if (distance < 1f)
                            {
                                x = player.GetComponent<Player>().pos.x;
                                transform.position += new Vector3(x, 0, 0);
                                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, head.transform.position.y - 0.5f, head.transform.position.z), 1);
                            }
                        }
                        else
                        {
                            transform.position = Vector3.Lerp(transform.position, new Vector3(head.transform.position.x + range, head.transform.position.y - 0.5f, head.transform.position.z), 1);
                            distance = Mathf.Abs(Vector3.Distance(transform.position, head.transform.position));
                            if (distance < 1f)
                            {
                                x = player.GetComponent<Player>().pos.x;
                                transform.position += new Vector3(x, 0, 0);
                                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, head.transform.position.y - 0.5f, head.transform.position.z), 1);
                            }
                        }
                    }
                    if (Input.GetAxis("Horizontal") < 0)
                    {
                        if (inrock)
                        {
                            //transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, head.transform.position.y - 0.5f, transform.position.z), 1);
                            //distance = Mathf.Abs(Vector3.Distance(transform.position, head.transform.position));
                            //if (distance < 1f)
                            //{
                            //    x = player.GetComponent<Player>().pos.x;
                            //    transform.position += new Vector3(x, 0, 0);
                            //    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, head.transform.position.y - 0.5f, head.transform.position.z), 1);
                            //}
                            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, head.transform.position.y - 0.5f, head.transform.position.z), 1);
                            //transform.position = new Vector3(x, head.transform.position.y, transform.position.z);
                        }
                        else
                        {
                            transform.position = Vector3.Lerp(transform.position, new Vector3(head.transform.position.x + range, head.transform.position.y - 0.5f, head.transform.position.z),1);
                            distance = Mathf.Abs(Vector3.Distance(transform.position, head.transform.position));
                            if (distance < 1f)
                            {
                                x = player.GetComponent<Player>().pos.x;
                                transform.position += new Vector3(x, 0, 0);
                                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, head.transform.position.y - 0.5f, head.transform.position.z), 1);
                            }
                            //transform.localPosition = new Vector3(head.transform.position.x + range, head.transform.position.y, transform.position.z);
                        }
                    }
                    if (Input.GetAxis("Horizontal") == 0)
                    {
                        if (inrock)
                        {
                            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, head.transform.position.y - 0.5f, head.transform.position.z), 1);
                            //transform.position = new Vector3(x, head.transform.position.y, transform.position.z);
                        }
                        else
                        {
                            transform.position = Vector3.Lerp(transform.position, new Vector3(head.transform.position.x + range, head.transform.position.y - 0.5f, head.transform.position.z), 1);
                            //transform.localPosition = new Vector3(head.transform.position.x + range, head.transform.position.y, transform.position.z);
                        }
                    }
                }
                else
                {
                    x = player.GetComponent<Player>().pos.x;

                    transform.position += new Vector3(x, 0, 0);
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, head.transform.position.y - 0.5f, head.transform.position.z), 1);

                }




            }
            else
            if (player.GetComponent<Player>().playerType == PlayerType.Left)
            {
                distance = Mathf.Abs(Vector3.Distance(transform.position, head.transform.position));

                if (!player.GetComponent<Player>().rock)
                {
                    range = 1;
                    if (Input.GetAxis("Horizontal") > 0)
                    {
                        if (inrock)
                        {
                            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, head.transform.position.y - 0.5f, head.transform.position.z), 1);
                            distance = Mathf.Abs(Vector3.Distance(transform.position, head.transform.position));
                            if (distance < 1f)
                            {
                                x = player.GetComponent<Player>().pos.x;
                                transform.position += new Vector3(x, 0, 0);
                                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, head.transform.position.y - 0.5f, head.transform.position.z), 1);
                            }
                            //transform.position = new Vector3(x, head.transform.position.y, transform.position.z);
                        }
                        else
                        {
                            transform.position = Vector3.Lerp(transform.position, new Vector3(head.transform.position.x - range, head.transform.position.y - 0.5f, head.transform.position.z), 1);
                            distance = Mathf.Abs(Vector3.Distance(transform.position, head.transform.position));
                            if (distance < 1f)
                            {
                                x = player.GetComponent<Player>().pos.x;
                                transform.position += new Vector3(x, 0, 0);
                                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, head.transform.position.y - 0.5f, head.transform.position.z), 1);
                            }
                            //transform.localPosition = new Vector3(head.transform.position.x + range, head.transform.position.y, transform.position.z);
                        }
                    }
                    if (Input.GetAxis("Horizontal") < 0)
                    {
                        if (inrock)
                        {
                            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, head.transform.position.y - 0.5f, transform.position.z), 1);
                            distance = Mathf.Abs(Vector3.Distance(transform.position, head.transform.position));
                            if (distance < 1f)
                            {
                                x = player.GetComponent<Player>().pos.x;
                                transform.position += new Vector3(x, 0, 0);
                                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, head.transform.position.y - 0.5f, head.transform.position.z), 1);
                            }
                            //transform.position = new Vector3(x, head.transform.position.y, transform.position.z);
                        }
                        else
                        {
                            transform.position = Vector3.Lerp(transform.position, new Vector3(head.transform.position.x - range, head.transform.position.y - 0.5f, head.transform.position.z), 1);
                            distance = Mathf.Abs(Vector3.Distance(transform.position, head.transform.position));
                            if (distance < 1f)
                            {
                                x = player.GetComponent<Player>().pos.x;
                                transform.position += new Vector3(x, 0, 0);
                                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, head.transform.position.y - 0.5f, head.transform.position.z), 1);
                            }
                            //transform.localPosition = new Vector3(head.transform.position.x + range, head.transform.position.y, transform.position.z);
                        }
                    }
                    if (Input.GetAxis("Horizontal") == 0)
                    {
                        if (inrock)
                        {
                            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, head.transform.position.y - 0.5f, head.transform.position.z), 1);
                            //transform.position = new Vector3(x, head.transform.position.y, transform.position.z);
                        }
                        else
                        {
                            transform.position = Vector3.Lerp(transform.position, new Vector3(head.transform.position.x - range, head.transform.position.y - 0.5f, head.transform.position.z), 1);
                            //transform.localPosition = new Vector3(head.transform.position.x + range, head.transform.position.y, transform.position.z);
                        }
                    }
                }
                else
                {
                    x = player.GetComponent<Player>().pos.x;

                    transform.position += new Vector3(x, 0, 0);
                    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, head.transform.position.y - 0.5f, head.transform.position.z), 1);

                }
            }
            else if(player.GetComponent<Player>().playerType==PlayerType.UpR)
            {
                if (!player.GetComponent<Player>().rock)
                {
                    range = 1;
                    if (inrock)
                    {
                        //transform.position = new Vector3(x, head.transform.position.y, transform.position.z);
                        transform.position = new Vector3(head.transform.position.x + 0.5f, head.transform.position.y + range, transform.position.z);

                    }
                    else
                    {
                        transform.position = new Vector3(head.transform.position.x + 0.5f, head.transform.position.y + range, transform.position.z);
                    }
                }
                else
                {

                    x = Input.GetAxis("Horizontal") * player.gameObject.GetComponent<Player>().speed;
                    transform.position += new Vector3(x, 0, 0);
                    transform.position = Vector3.Lerp(transform.position, new Vector3(head.transform.position.x + 0.5f, head.transform.position.y + range, transform.position.z), 1);
                }
            }
            else if (player.GetComponent<Player>().playerType == PlayerType.UpL)
            {
                if (!player.GetComponent<Player>().rock)
                {
                    range = 1;
                    if (inrock)
                    {
                        //transform.position = new Vector3(x, head.transform.position.y, transform.position.z);
                        transform.position = new Vector3(head.transform.position.x - 0.5f, head.transform.position.y + range, transform.position.z);

                    }
                    else
                    {
                        transform.position = new Vector3(head.transform.position.x - 0.5f, head.transform.position.y + range, transform.position.z);
                    }
                }
                else
                {

                    x = Input.GetAxis("Horizontal") * player.gameObject.GetComponent<Player>().speed;
                    transform.position += new Vector3(x, 0, 0);
                    transform.position = Vector3.Lerp(transform.position, new Vector3(head.transform.position.x - 0.5f, head.transform.position.y + range, transform.position.z), 1);
                }
            }

        }


    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (player.GetComponent<Player>().rightroll)
            {
                player.GetComponent<Player>().rightroll = false;
                player.GetComponent<Player>().unrightroll = true;
            }
            if (player.GetComponent<Player>().leftroll)
            {
                player.GetComponent<Player>().leftroll = false;
                player.GetComponent<Player>().unleftroll = true;
            }
        }
    }
}
