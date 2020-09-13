using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjCont : MonoBehaviour
{
    public GameObject obj;
    float scale,rot;
    float time, tortalTime;
    public GameObject Camera,camP1, camP2,titleLogo,blocks;
    // Start is called before the first frame update
    void Start()
    {
        tortalTime = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.J))
        {
            time += Time.deltaTime;
            if(time <= 1)
            {
                scale = easing.BackOut(time, tortalTime, 0, 1, 1.5f);
                obj.transform.localScale = new Vector3(scale, scale, scale);
            }
        }

        if (Input.GetKey(KeyCode.K))
        {
            time += Time.deltaTime;
            if (time <= 2)
            {
                rot = easing.BackOut(time, 2, -90, -80,1.5f);
                obj.transform.rotation = Quaternion.Euler(new Vector3(rot, obj.transform.rotation.y, obj.transform.rotation.z));
            }
            else if (time <= 6 && time > 2)
            {
                rot = easing.BackOut(time-2, 4, -80,30, 1.2f);
                obj.transform.rotation = Quaternion.Euler(new Vector3(rot, obj.transform.rotation.y, obj.transform.rotation.z));
                Camera.transform.position = easing3D.SineOut(time - 2, 4, camP1.transform.position, camP2.transform.position);
            }
            else if (time <= 8 && time > 6)
            {
                rot = easing.BackOut(time - 6, 2, -80, 30, 1.2f);
                blocks.transform.position = easing3D.SineOut(time - 6, 2, new Vector3(0,0,0), new Vector3(0, 7.5f, 0));
                titleLogo.transform.position = easing3D.SineOut(time - 6, 2, new Vector3(0, 0, 0), new Vector3(0, 13.5f, 0));
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            time = 0;
            
        }
    }
}
