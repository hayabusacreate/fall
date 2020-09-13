using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    public GameObject L;
    public GameObject R;
    bool Lup, Rup,st;
    float upTime,value;
    Vector3 Lpos, Rpos;
    // Start is called before the first frame update
    void Start()
    {
        value = 0.3f;
        Lpos = L.transform.position;
        Rpos = R.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        upTime += Time.deltaTime;
        //if(upTime <= 0.5f && st == true)
        //{
        //    L.transform.position = new Vector3(L.transform.position.x, L.transform.position.y + value, L.transform.position.z);
        //    R.transform.position = new Vector3(R.transform.position.x, R.transform.position.y - value, R.transform.position.z);
        //}
        //if (upTime <= 0.5f && st == false)
        //{
        //    L.transform.position = new Vector3(L.transform.position.x, L.transform.position.y + value, L.transform.position.z);
        //}
        //if (upTime <= 1&& upTime > 0.5f)
        //{
        //    R.transform.position = new Vector3(R.transform.position.x, R.transform.position.y + value, R.transform.position.z);
        //    L.transform.position = new Vector3(L.transform.position.x, L.transform.position.y - value, L.transform.position.z);
        //}
        //if (upTime <= 1.5f && upTime > 1)
        //{
        //    R.transform.position = new Vector3(R.transform.position.x, R.transform.position.y - value, R.transform.position.z);
        //    L.transform.position = new Vector3(L.transform.position.x, L.transform.position.y + value, L.transform.position.z);

        //}
        //if (upTime <= 2 && upTime > 1.5f)
        //{
        //    R.transform.position = new Vector3(R.transform.position.x, R.transform.position.y + value, R.transform.position.z);
        //    L.transform.position = new Vector3(L.transform.position.x, L.transform.position.y - value, L.transform.position.z);
        //}
        //if (upTime <= 2.5f && upTime > 2)
        //{
        //    R.transform.position = new Vector3(R.transform.position.x, R.transform.position.y - value, R.transform.position.z);
        //    L.transform.position = new Vector3(L.transform.position.x, L.transform.position.y + value, L.transform.position.z);
        //}
        //if (upTime <= 3 && upTime > 2.5f)
        //{
        //    R.transform.position = new Vector3(R.transform.position.x, R.transform.position.y + value, R.transform.position.z);
        //    L.transform.position = new Vector3(L.transform.position.x, L.transform.position.y - value, L.transform.position.z);
        //}
        //if ( upTime > 3)
        //{
        //    st = true;
        //    upTime = 0;
        //}
        if (upTime <= 0.5f && st == true)
        {
            L.transform.position = new Vector3(L.transform.position.x, Lpos.y+ value, L.transform.position.z);
            R.transform.position = new Vector3(R.transform.position.x, Rpos.y, R.transform.position.z);
        }
        if (upTime <= 0.5f && st == false)
        {
            L.transform.position = new Vector3(L.transform.position.x, Lpos.y + value, L.transform.position.z);
        }
        if (upTime <= 1 && upTime > 0.5f)
        {
            R.transform.position = new Vector3(R.transform.position.x, Rpos.y + value, R.transform.position.z);
            L.transform.position = new Vector3(L.transform.position.x, Lpos.y, L.transform.position.z);
        }
        if (upTime <= 1.5f && upTime > 1)
        {
            R.transform.position = new Vector3(R.transform.position.x, Rpos.y, R.transform.position.z);
            L.transform.position = new Vector3(L.transform.position.x, Lpos.y + value, L.transform.position.z);

        }
        if (upTime <= 2 && upTime > 1.5f)
        {
            R.transform.position = new Vector3(R.transform.position.x, Rpos.y + value, R.transform.position.z);
            L.transform.position = new Vector3(L.transform.position.x, Lpos.y, L.transform.position.z);
        }
        if (upTime <= 2.5f && upTime > 2)
        {
            R.transform.position = new Vector3(R.transform.position.x, Rpos.y , R.transform.position.z);
            L.transform.position = new Vector3(L.transform.position.x, Lpos.y + value, L.transform.position.z);
        }
        if (upTime <= 3 && upTime > 2.5f)
        {
            R.transform.position = new Vector3(R.transform.position.x, Rpos.y + value, R.transform.position.z);
            L.transform.position = new Vector3(L.transform.position.x, Lpos.y , L.transform.position.z);
        }
        if (upTime > 3)
        {
            st = true;
            upTime = 0;
        }
    }
}
