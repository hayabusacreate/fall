using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public string type;
    public Collider collider;
    // Start is called before the first frame update
    void Start()
    {
        if(type=="0")
        {
            Destroy(gameObject);
        }else
        {
            collider.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
