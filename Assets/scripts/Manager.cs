using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //***

public class Manager : MonoBehaviour
{
    [HideInInspector]
    public static Manager Instance { get; private set; } //used for singleton, can be referenced by any other script

    private void Awake()
    {
        if (Instance != null && Instance != this) //singleton pattern
        {
            Debug.Log("OnTriggerEnter Destroy 2261");
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private GameObject[] _targets;
    public string FactoryTag = "Factory";
    public string Food1 = "chikenleg";
    public string Food2 = "hamburger";
    public string Food3 = "shrimp";
    public string Food4 = "pineapple";
    public string Food5 = "icecream";
    public string Food6 = "fries";
    public string[] Foods = new string[] { "chikenleg", "hamburger", "shrimp", "pineapple", "icecream", "fries" };
    public GameObject target;
    public string food;
    public int start;
    public int end;
    public bool mission = false;
    private bool change = true;
    private float totalTime;
    private float tr;

    // Start is called before the first frame update

    public void Start()
    {
        _targets = GameObject.FindGameObjectsWithTag(FactoryTag);
        //Debug.Log(Foods.Length);

        //Debug.Log(food);
        //Debug.Log(target);
    }

    private void Update()
    {
        totalTime += Time.deltaTime;
        tr += Time.deltaTime;

        if (0f <= totalTime && totalTime < 5f)
        {
            mission = false;
            change = true;
        }
        /*if (totalTime == 5f)
        {
            change = false;
            if (change==false)
            {
                change = true;
                start = 1;
                end =2;

                *//*if (start == end)
                {
                    end += 1;
                    if (end >= Foods.Length) { end = 1; }
                    return;
                }*//*
            }
            mission = true;
            Debug.Log(start+"s");
            Debug.Log(end+"e");
        }*/

        if (5f <= totalTime && totalTime < 100f)
        {
            change = false;
            if (tr < 6f)
            {
                tr = 6f;
                change = true;
                start = Random.Range(0, Foods.Length);
                end = Random.Range(0, Foods.Length);
                if (start == end)
                {
                    end += 1;
                    if (end >= Foods.Length) { end = 1; }
                    return;
                }
                mission = true;
                /*start = 1;
                end = 2;*/
                /*food = Foods[start];//for picking up the tag
                GameObject target = _targets[end];//target factory
                GameObject selectedfood = GameObject.Find(food);//for chossing all the selected food
                string TargetName = target.name;//target factory`s name*/
                Debug.Log(start + "s");
                Debug.Log(end + "e");
                //string TargetName = _targets[end].name;
                //string food2 = Foods[start];
                Global.instence.strTargetFoodName = Foods[start];  //目标食物名字
                Global.instence.strTargetFactoryName = Foods[end]; //目标工厂名字
                //Debug.Log("food2="+ food2 + "TargetName = " + TargetName + "");
            }
        }
        if (totalTime >= 100f)
        {
            totalTime = 0f;
            tr = 0f;
            mission = false;
        }
    }
}

/*public GameObject GetTarget()
{
    int targetIndex = Random.Range(0, _targets.Length);
    GameObject target = _targets[targetIndex];

    int startIndex = targetIndex; //used to test if the index wraps back on itself
    while (_occupiedTargets.Contains(target))
    {
        targetIndex++;
        if (targetIndex >= _targets.Length) { targetIndex = 0; } //loop back to array start
        target = _targets[targetIndex];
        if (startIndex == targetIndex) { break; } //this means indices wrapped
    }
    return target;
}*/

// Update is called once per frame