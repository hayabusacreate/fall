using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageFx : MonoBehaviour
{
    public GameObject sc,stage1,stage2,stage3,stage4,stage5;
    int num;
    // Start is called before the first frame update
    void Start()
    {
        stage1.SetActive(false);
        stage2.SetActive(false);
        stage3.SetActive(false);
        stage4.SetActive(false);
        stage5.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        num = sc.GetComponent<SceneChange>().mapnum;
        if (num == 1)
        {
            stage1.SetActive(true);
            stage2.SetActive(false);
            stage3.SetActive(false);
            stage4.SetActive(false);
            stage5.SetActive(false);
        }
        if (num == 2)
        {
            stage1.SetActive(false);
            stage2.SetActive(true);
            stage3.SetActive(false);
            stage4.SetActive(false);
            stage5.SetActive(false);
        }
        if (num == 3)
        {
            stage1.SetActive(false);
            stage2.SetActive(false);
            stage3.SetActive(true);
            stage4.SetActive(false);
            stage5.SetActive(false);
        }
        if (num == 4)
        {
            stage1.SetActive(false);
            stage2.SetActive(false);
            stage3.SetActive(false);
            stage4.SetActive(true);
            stage5.SetActive(false);
        }
        if (num == 5)
        {
            stage1.SetActive(false);
            stage2.SetActive(false);
            stage3.SetActive(false);
            stage4.SetActive(false);
            stage5.SetActive(true);
        }
    }
}
