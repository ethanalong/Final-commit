using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndItems : MonoBehaviour
{
    public Sprite[] endItems;
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
                EndItems();
                totalTime = 0f;
            }
        }
        if (tr >= 5f && tr < 100f)
        {
            EndItemsEnd();
        }
        if (tr >= 100f)
        {
            tr = 0f;
        }

        void EndItems()
        {
            gameObject.GetComponent<UnityEngine.UI.Image>().sprite = endItems[Random.Range(0, endItems.Length)];
        }

        void EndItemsEnd()
        {
            gameObject.GetComponent<UnityEngine.UI.Image>().sprite = endItems[managerGet.end];
        }
    }
}