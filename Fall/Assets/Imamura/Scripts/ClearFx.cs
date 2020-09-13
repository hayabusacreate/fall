using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearFx : MonoBehaviour
{
    float scale, time;
    public GameObject kira;
    bool once;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time <= 1)
        {
            scale = easing.BackOut(time, 1, 0, 1, 2f);
            transform.localScale = new Vector3(scale, scale, scale);
        }
        if(time >= 1 && once == false)
        {
            Instantiate(kira,transform.position,Quaternion.identity);
            once = true;
        }
    }
}
