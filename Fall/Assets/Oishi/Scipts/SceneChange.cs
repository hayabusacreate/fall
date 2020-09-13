using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Scene
{
    Title,
    GamePlay,
    Load,
    StageSelect,
    GameClear,
    GameOver
}

public class SceneChange : MonoBehaviour
{
    public Scene scene;
    private Player player;
    public float time;
    private Text timeText;
    private Slider slider;
    public int map;
    public MapCreate mapCreate;
    public bool creaflag;
    public Text text;

    private int mapnum;

    public int mapcount;

    public bool endflag;

    public GameObject gold, silver, bronze, over, serect;

    public AudioClip sound1;
    AudioSource audio;

    private bool ui;
    private float count;
    public GameObject endobj, startobj;
    public static Dictionary<int, bool> clear = new Dictionary<int, bool>();
    public GameObject[] stages;
    private int stagenum;
    public GameObject pl;
    private float scale;
    private bool inout;

    public GameObject key, pad;
    string[] CacheJoystickNames;
    public static bool title;
    private bool clearflag;
    private GameObject UI;
    private GameObject hinoko;
    private float count2;
    private static int deathcount;
    private static bool hintflag;
    public GameObject hintobj;
    public bool allflag;
    public GameObject allobj;
    public GameObject special;
    public GameObject open, close;
    // Start is called before the first frame update
    void Start()
    {
        CacheJoystickNames = Input.GetJoystickNames();
        inout = true;
        audio = GetComponent<AudioSource>();
        if (scene == Scene.Title)
        {
            //UI = GameObject.Find("AA");
        }
        if (scene == Scene.GamePlay)
        {
            close.SetActive(false);
            open.SetActive(true);
            allflag = true;
            //serect.SetActive(true);
            for (int i = 1; i < clear.Count; i++)
            {
                if (!clear[i])
                {
                    allflag = false;
                }
            }
            //hinoko = GameObject.Find("hinoko");
            //hinoko.SetActive(false);
            //slider = GameObject.Find("Count").GetComponent<Slider>();
            //player = GameObject.Find("Player").GetComponent<Player>();
            mapCreate = GameObject.Find("MapCreate").GetComponent<MapCreate>();
            //slider.minValue = 0;
            //slider.maxValue = 100;
            //UI = GameObject.Find("AA");
            mapcount = 20;
            mapnum = mapCreate.ReturnMapnum();
            stagenum = mapCreate.ReturnMapnum();
            //Physics.gravity = new Vector3(0, -5, 0);
        }
        if (scene == Scene.Load)
        {

            mapCreate = GameObject.Find("MapCreate").GetComponent<MapCreate>();
        }
        if (scene == Scene.StageSelect)
        {
            close.SetActive(false);
            open.SetActive(true);
            allflag = true;
            //serect.SetActive(true);
            //for (int i = 1; i < clear.Count; i++)
            //{
            //    if (!clear[i])
            //    {
            //        allflag = false;
            //    }
            //}
            //if (allflag)
            //{
            //    special.SetActive(true);
            //}
            //else
            //{
            //    special.SetActive(false);
            //}
            //UI = GameObject.Find("AA");
            //UI.SetActive(false);
            mapCreate = GameObject.Find("MapCreate").GetComponent<MapCreate>();
            mapnum = mapCreate.ReturnMapnum();
            stagenum = mapCreate.ReturnMapnum();
            if (mapnum == 0)
            {
                mapnum = 1;
                stagenum = 1;
            }
            pl.transform.position = new Vector3(mapnum * 5, pl.transform.position.y, pl.transform.position.z);
            mapCreate.ChangeMap(mapnum);
            //if (title)
            //{
            //    startobj.SetActive(true);
            //    count2 = 10;
            //}
            //if (!title)
            //{
            //    startobj.SetActive(true);
            //    title = true;
            //}
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) Quit();
        Change();
    }
    void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }
    void Change()
    {
        switch (scene)
        {
            case Scene.Title:
                if (Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown("joystick button 0")))
                {
                    clearflag = true;
                    count = 0;
                    endflag = true;

                }
                if (endflag)
                {
                    close.SetActive(true);
                    count++;
                    //endobj.SetActive(true);
                    //UI.SetActive(false);

                }
                if (close.GetComponent<wipeTex>().closed)
                {
                    SceneManager.LoadScene("StageSerect");

                }
                break;
            case Scene.GamePlay:
                //time -= Time.deltaTime;

                if (deathcount > 3)
                {
                    hintobj.SetActive(true);
                    if (hintflag)
                    {
                        if (Input.GetKeyDown(KeyCode.H) || (Input.GetKeyDown("joystick button 3")))
                        {
                            hintflag = false;
                        }
                    }
                    else
                    {
                        if (Input.GetKeyDown(KeyCode.H) || (Input.GetKeyDown("joystick button 3")))
                        {
                            hintflag = true;
                        }
                    }

                }
                if (endflag)
                {
                    count++;
                    endobj.SetActive(true);
                    if(close.GetComponent<wipeTex>().closed)
                    {
                        SceneManager.LoadScene("StageSerect");
                    }
                    //UI.SetActive(false);
                    if (!clearflag)
                    {
                    }

                }

                //if (creaflag)
                //{
                //    if ((((float)mapCreate.maxblock - (float)mapCreate.blocks) / (float)mapCreate.maxblock) * 100 == 100)
                //    {
                //        hinoko.SetActive(true);

                //        clear[mapCreate.ReturnMapnum()] = true;
                //        allflag = true;
                //        //serect.SetActive(true);
                //        for (int i = 1; i < clear.Count; i++)
                //        {
                //            if (!clear[i])
                //            {
                //                allflag = false;
                //            }
                //        }
                //        if (allflag)
                //        {
                //            allobj.SetActive(true);
                //        }
                //        else
                //        {
                //            gold.SetActive(true);
                //        }
                //        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown("joystick button 0")))
                //        {
                //            clearflag = true;
                //            count = 0;
                //            endflag = true;
                //        }
                //    }
                //    else
                //    {
                //        endflag = true;
                //    }


                //}
                //if (Input.GetKeyDown(KeyCode.I))
                //{
                //    ui = true;
                //}
                //if (ui)
                //{
                //    over.SetActive(false);
                //    bronze.SetActive(false);
                //    silver.SetActive(false);
                //    gold.SetActive(false);
                //    serect.SetActive(false);
                //}
                if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 6"))&&endflag)
                {
                    open.SetActive(false);
                    close.SetActive(true);
                    //SceneManager.LoadScene("StageSerect");
                    //clearflag = true;
                    //count = 0;
                    //endflag = true;
                    //mapnum = mapcount;
                }

                if (Input.GetKeyDown(KeyCode.I) || (Input.GetKeyDown("joystick button 7")))
                {
                    SceneManager.LoadScene("Stage" + mapCreate.ReturnMapnum());
                }
                //if (count > 60)
                //{
                //    if (clearflag)
                //    {
                //        mapnum++;
                //        inout = false;
                //        if (mapnum > mapcount)
                //        {
                //            mapnum = mapcount;
                //            SceneManager.LoadScene("StageSerect");
                //        }
                //        else
                //        {
                //            deathcount = 0;
                //            mapCreate.ChangeMap(mapnum);
                //            SceneManager.LoadScene("Stage" + mapCreate.ReturnMapnum());
                //        }

                //    }
                //    else
                //    {
                //        SceneManager.LoadScene("Stage" + mapCreate.ReturnMapnum());
                //        deathcount++;
                //    }

                //}
                break;
            case Scene.StageSelect:
                count2 += Time.deltaTime;
                text.text = "" + mapnum;


                if (count2 > 1)
                {
                    if (stagenum == mapnum)
                    {
                        if ((Input.GetKey(KeyCode.D) || (Input.GetKey("joystick button 5"))) && !endflag)
                        {
                            mapnum++;
                            inout = false;
                            if (mapnum > mapcount)
                            {
                                mapnum = mapcount;
                            }
                            mapCreate.ChangeMap(mapnum);
                        }
                        else
                        if ((Input.GetKey(KeyCode.A) || (Input.GetKey("joystick button 4"))) && !endflag)
                        {
                            inout = false;
                            mapnum--;
                            if (mapnum < 1)
                            {
                                mapnum = 1;
                            }
                            mapCreate.ChangeMap(mapnum);
                        }
                    }
                    else
                    {
                        if (mapnum < stagenum)
                        {
                            pl.transform.position -= new Vector3(Time.deltaTime * 15, 0, 0);
                            //Vector3.Lerp(pl.transform.position, stages[mapnum].transform.position, Time.deltaTime*5);
                            if (pl.transform.position.x - 0.1f <= stages[mapnum].transform.position.x)
                            {
                                inout = true;
                                stagenum = mapnum;
                            }
                        }
                        else
                        {
                            pl.transform.position += new Vector3(Time.deltaTime * 15, 0, 0);
                            //Vector3.Lerp(pl.transform.position, stages[mapnum].transform.position, Time.deltaTime*5);
                            if (pl.transform.position.x + 0.1f >= stages[mapnum].transform.position.x)
                            {
                                inout = true;
                                stagenum = mapnum;
                            }
                        }
                    }
                    if (Input.GetKey(KeyCode.Space) || (Input.GetKeyDown("joystick button 0")))
                    {
                        //UI.SetActive(false);
                        //if (!endflag)
                        //{
                        //    audio.PlayOneShot(sound1);
                        //}
                        endflag = true;
                        open.SetActive(false);
                        close.SetActive(true);
                    }
                    if (endflag)
                    {
                        count++;
                        //endobj.SetActive(true);
                    }
                    if (close.GetComponent<wipeTex>().closed)
                    {
                        SceneManager.LoadScene("Stage" + mapCreate.ReturnMapnum());
                    }
                }

                break;
            case Scene.GameOver:
                if (Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene("NewStage" + mapCreate.ReturnMapnum());
                }
                break;
            case Scene.GameClear:
                if (Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene("NewStage" + mapCreate.ReturnMapnum());
                }
                break;
            case Scene.Load:
                for (int i = 0; i < map; i++)
                {
                    mapCreate.LoadMap(Resources.Load("stage" + i) as TextAsset, i);
                    clear[i] = false;
                }
                SceneManager.LoadScene("Title");
                break;
        }
    }
}
