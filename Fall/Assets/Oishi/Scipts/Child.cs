using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : MonoBehaviour
{
    public GameObject player,head;
    private float range;
    public bool inrock,outrock;
    public bool under;
    private float x;
    // Start is called before the first frame update
    void Start()
    {
        range = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(!player.GetComponent<Player>().rightroll&& !player.GetComponent<Player>().leftroll)
        {

            if((player.GetComponent<Player>().playerType==PlayerType.Right||
                player.GetComponent<Player>().playerType == PlayerType.Left))
            {
                if (!player.GetComponent<Player>().rock)
                {
                    if (Input.GetAxis("Horizontal") > 0)
                    {
                        if (outrock)
                        {
                            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, head.transform.position.y, transform.position.z), Time.deltaTime * 10);
                        }
                        else
                        {
                            x = Input.GetAxis("Horizontal") * player.gameObject.GetComponent<Player>().speed;
                            transform.position += new Vector3(x, 0, 0);
                        }
                    }
                    if (Input.GetAxis("Horizontal") < 0)
                    {
                        if (inrock)
                        {
                            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, head.transform.position.y, transform.position.z), Time.deltaTime * 10);
                            //transform.position = new Vector3(x, head.transform.position.y, transform.position.z);
                        }
                        else
                        {
                            transform.position = Vector3.Lerp(transform.position, new Vector3(head.transform.position.x + range, head.transform.position.y, transform.position.z), Time.deltaTime * 10);
                            //transform.localPosition = new Vector3(head.transform.position.x + range, head.transform.position.y, transform.position.z);
                        }
                    }
                    if (Input.GetAxis("Horizontal") == 0)
                    {
                        if (inrock)
                        {
                            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, head.transform.position.y, transform.position.z), Time.deltaTime * 10);
                            //transform.position = new Vector3(x, head.transform.position.y, transform.position.z);
                        }
                        else
                        {
                            transform.position = Vector3.Lerp(transform.position, new Vector3(head.transform.position.x + range, head.transform.position.y, transform.position.z), Time.deltaTime * 10);
                            //transform.localPosition = new Vector3(head.transform.position.x + range, head.transform.position.y, transform.position.z);
                        }
                    }
                }else
                {

                }


            }
            else
            {
                transform.position = new Vector3(head.transform.position.x, transform.position.y, transform.position.z);
                if (inrock)
                {
                    //transform.position = new Vector3(x, head.transform.position.y, transform.position.z);

                }
                else
                {
                    //transform.position = new Vector3(transform.position.x, head.transform.position.y, transform.position.z);
                }
            }

        }


    }
}
