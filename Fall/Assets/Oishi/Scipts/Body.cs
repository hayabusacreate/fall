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
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float dx = parent.transform.position.x - child.transform.position.x;
        float dz = parent.transform.position.z - child.transform.position.z;
        angle = Mathf.Atan2(dz, dx);

        Quaternion lookRotation = Quaternion.LookRotation(child.transform.position - transform.position, Vector3.up);



        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, 1f);

        far = Mathf.Abs(Vector3.Distance(child.transform.position, parent.transform.position));
        transform.localScale = new Vector3( 0.3f, 1,far );
        transform.position = (parent.transform.position + child.transform.position) / 2;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag=="Ground")
        {
            player.moveflag = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            player.moveflag = false;
        }
    }
}
