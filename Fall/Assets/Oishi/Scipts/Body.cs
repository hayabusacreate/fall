using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public GameObject parent, child;
    public float far;
    public float hight;
    public float angle;
    public Player player;
    public bool under, up;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        float dx = parent.transform.position.x - child.transform.position.x;
        float dz = parent.transform.position.z - child.transform.position.z;
        angle = Mathf.Atan2(dz, dx);

        Quaternion lookRotation = Quaternion.LookRotation(child.transform.position - transform.position, Vector3.up);

        //lookRotation.y = 0;
        //lookRotation.z = 0;

        transform.rotation = Quaternion.Lerp(transform.rotation,lookRotation, 1);

        far = Mathf.Abs(Vector3.Distance(child.transform.position, parent.transform.position));
        transform.localScale = new Vector3( 0.3f, 0.5f,far-1 );
        transform.position = (parent.transform.position + child.transform.position) / 2;
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag=="Ground")
        {
            if (player.rightmove)
            {
                player.rightmove = false;
                player.unrightroll = true;
            }
            if (player.leftmove)
            {
                player.leftroll = false;
                player.unleftroll = true;
            }
        }
    }
}
