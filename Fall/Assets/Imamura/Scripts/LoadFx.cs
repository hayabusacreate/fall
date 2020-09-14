using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFx : MonoBehaviour
{
    public GameObject m;
    float rot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rot += Time.deltaTime*100;
        m.transform.rotation = Quaternion.Euler(new Vector3(m.transform.rotation.x, m.transform.rotation.y, m.transform.rotation.z+rot));
    }
}
