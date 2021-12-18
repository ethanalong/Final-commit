using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterController : MonoBehaviour
{
    public float turnSpeed;
    public float horizontalInput;
    public float forwardInput;

    private string[] fName = new string[] { "chikenleg", "hamburger", "shrimp", "pineapple", "icecream", "fries" };

    private GameObject manager;
    public GameObject[] fs;
    public GameObject ms;
    private GameObject cf;

    private PreyBehavior pb;

    public bool dropRight = false;
    private bool isHit = false;

    [HideInInspector]
    public bool haha = false;

    private GameObject gameObjectFood;
    private GameObject seletected;

    // Start is called before the first frame update
    private void Start()
    {
        seletected = GameObject.FindGameObjectWithTag("Light");
        ms = GameObject.FindGameObjectWithTag("Mission");
    }

    // Update is called once per frame
    private void Update()
    {
        Transform[] ps = GetComponentsInChildren<Transform>();
        /*if (ps.Length>5)
        {
            Compare();
            for (int i = 0; i < fs.Length; i++)
            {
                if ()
                {
                }
            }
        }*/
        /*if (ps.Length>)
        {
        }*/

        //horizontalInput = Input.GetAxis("Horizontal");
        //forwardInput = Input.GetAxis("Vertical");

        horizontalInput = Input.GetAxis("LeftJoyX2");
        forwardInput = Input.GetAxis("LeftJoyY2");
        float hi = Mathf.Abs(horizontalInput);
        float fi = Mathf.Abs(forwardInput);

        //move the  forward and right with speed per frame
        if (hi >= 0.1f)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput * 10);
        }
        if (fi >= 0.1f)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * forwardInput * 20);
        }

        if (Input.GetButtonDown("North2"))
        {
            if (isHit == true && !Global.instence.isPlayerGotFood)
            {
                PickUp();   //捡起来
            }
            else
            {
                if (Global.instence.isPlayerGotFood)
                {
                    Global.instence.isPlayerGotFood = false;
                    //hamberger
                    Debug.Log("strTargetFactoryName=  " + Global.instence.strTargetFactoryName);
                    Debug.Log("strTargetFoodName=  " + Global.instence.strTargetFoodName);

                    Debug.Log("strCurrFactoryName=  " + Global.instence.strCurrFactoryName);
                    Debug.Log("strGotFoodName=  " + Global.instence.strGotFoodName);
                    //如果给到对的工厂
                    if (Global.instence.strCurrFactoryName.Contains(Global.instence.strTargetFactoryName) && Global.instence.strCurrFactoryName != "")
                    {
                        //正确的食物
                        if (Global.instence.strTargetFoodName.Equals(Global.instence.strGotFoodName) && Global.instence.strGotFoodName != "")
                        {
                            ScoreOnDestroy.instence.AddToScore(1);   //食物和工厂同时正确就加分
                        }
                    }

                    //清空玩家头顶拿到的食物
                    foreach (Transform item in seletected.transform)
                    {
                        Destroy(item.gameObject);
                    }

                    Debug.Log("Destroy food on player heard!");

                    Global.instence.strGotFoodName = "";   //注意顺序，最后清空
                }
            }
        }

        DebugTest();
    }

    private void DebugTest()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            seletected.transform.parent.localPosition = new Vector3(-1.39f, 1.44f, 152.42f);
            Debug.Log("1111");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //0.9  21.7  -149.5
            seletected.transform.parent.localPosition = new Vector3(0.9f, 21.7f, -149.5f);
            Debug.Log("1111");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //-130.64   21.385  75.23
            seletected.transform.parent.localPosition = new Vector3(-130.64f, 21.385f, 75.23f);
            Debug.Log("1111");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //129.66  -18.35  75.15
            seletected.transform.parent.localPosition = new Vector3(129.66f, -18.35f, 75.15f);
            Debug.Log("1111");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            //133.87  0.77 -77.66
            seletected.transform.parent.localPosition = new Vector3(133.87f, 0.77f, -77.66f);
            Debug.Log("1111");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            //-131.3  0.11  -75.9
            seletected.transform.parent.localPosition = new Vector3(-131.3f, 0.11f, -75.9f);
            Debug.Log("1111");
        }
    }

    private void PickUp()
    {
        //Debug.Log("PickUp hunter = "+ hunter.gameObject.name);
        //Debug.Log("this.transform = " + this.transform.gameObject.name);
        isHit = false;
        Global.instence.isPlayerGotFood = true; //拿到食物了
        Global.instence.strGotFoodName = gameObjectFood.name;
        gameObjectFood.transform.parent = Global.instence.seletected.transform;
        gameObjectFood.transform.localPosition = new Vector3(0, 5f, 0);
        gameObjectFood.transform.localRotation = Quaternion.Euler(Vector3.zero);
        gameObjectFood.transform.localScale = new Vector3(20, 20, 20);
        Debug.Log("PickUp");
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.tag == "Factory")
        {
            Debug.Log("OnTriggerEnter Factory");
            if (other.name == fName[ms.GetComponent<Manager>().end] + "Factory")
            {
                dropRight = true;
            }
        }*/
        if (other.gameObject.tag == "Hunter")
        // if (other.gameObject.name == "Penguin")
        {
            Debug.Log("Penguin");
            //CursorController.instence.Rebirth();
            Global.instence.isRebirth = true;
        }

        /*if (other.gameObject.tag == "Boo")
        {
            //haha = true;
            Global.instence.isRebirth = true;
        }*/

        if (other.gameObject.name == "hamburgerFactory" ||
            other.gameObject.name == "shrimpFactory" ||
            other.gameObject.name == "pineappleFactory" ||
            other.gameObject.name == "icecreamFactory" ||
            other.gameObject.name == "friesFactory" ||
            other.gameObject.name == "chikenlegFactory"
            )
        {
            Global.instence.strCurrFactoryName = other.gameObject.name;
            //isHit = true;
            //gameObjectFood = other.gameObject;
            //Global.instence.strGotFoodName = other.gameObject.name;
            //Debug.Log("OnTriggerEnter Factory = " + other.gameObject.name);
            //Destroy(other.transform.parent);
        }

        if (other.gameObject.name == "hamburger" ||
            other.gameObject.name == "shrimp" ||
            other.gameObject.name == "pineapple" ||
            other.gameObject.name == "icecream" ||
            other.gameObject.name == "fries" ||
            other.gameObject.name == "chikenleg"
            )
        {
            isHit = true;
            gameObjectFood = other.gameObject;
            //Debug.Log("OnTriggerEnter Food");
            //Destroy(other.transform.parent);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "hamburgerFactory" ||
            other.gameObject.name == "shrimpFactory" ||
            other.gameObject.name == "pineappleFactory" ||
            other.gameObject.name == "icecreamFactory" ||
            other.gameObject.name == "friesFactory" ||
            other.gameObject.name == "chikenlegFactory"
            )
        {
            //Global.instence.strCurrFactoryName = "";
            //isHit = true;
            //gameObjectFood = other.gameObject;
            //Global.instence.strGotFoodName = other.gameObject.name;
            //Debug.Log("OnTriggerExit Factory = " + other.gameObject.name);
            //Destroy(other.transform.parent);
        }

        if (other.gameObject.name == "hamburger" ||
            other.gameObject.name == "shrimp" ||
            other.gameObject.name == "pineapple" ||
            other.gameObject.name == "icecream" ||
            other.gameObject.name == "fries" ||
            other.gameObject.name == "chikenleg"
            )
        {
            isHit = false;
            //gameObjectFood = other.gameObject;
            //Global.instence.strGotFoodName = "";
            //Debug.Log("OnTriggerExit Food = " + other.gameObject.name);
            //Destroy(other.transform.parent);
        }
    }

    /*void Compare()
    {
        cf = GameObject.
    }*/
    /*private void OnColliEnter(Collider other)
    {
        if (other.gameObject.tag == ("Food"))
        {
            Destroy(other.transform.parent);
        }
    }*/
}