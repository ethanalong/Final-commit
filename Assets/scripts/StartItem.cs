using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartItem : MonoBehaviour
{
    public Sprite[] startItems;
    public float stopTime;
    private float totalTime;
    private float tr;
    private bool getMission;
    public GameObject test;

    private Manager managerGet;

    // Start is called before the first frame update
    private void Start()
    {
        managerGet = test.GetComponent<Manager>();
    }

    // Update is called once per frame
    private void Update()
    {
        getMission = managerGet.mission;
        //HunterController rg = test.transform.parent.GetComponent<HunterController>();
        totalTime += Time.deltaTime;
        tr += Time.deltaTime;

        if (tr >= 0f && tr < 5f)
        {
            if (totalTime >= 0.1f)
            {
                StartItems();
                totalTime = 0f;
            }
        }
        if (tr >= 5f && tr < 100f)
        {
            StartItemsEnd();
        }
        if (tr >= 100f)
        {
            tr = 0f;
        }
    }

    private void StartItems()
    {
        gameObject.GetComponent<UnityEngine.UI.Image>().sprite = startItems[Random.Range(0, startItems.Length)];
    }

    private void StartItemsEnd()
    {
        gameObject.GetComponent<UnityEngine.UI.Image>().sprite = startItems[managerGet.start];
    }
}