using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nobiruyatu : MonoBehaviour
{
    Material nobi;
    float scale;
    // Start is called before the first frame update
    void Start()
    {
        nobi = transform.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        scale = transform.localScale.z;
        nobi.mainTextureScale = new Vector2(scale,1);
    }
}
