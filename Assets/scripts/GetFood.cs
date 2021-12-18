using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFood : MonoBehaviour
{
    private int l;
    public PreyBehavior be;
    // Start is called before the first frame update
    void Start()
    {
        l= GetComponentsInChildren<Transform>().Length;
        be = gameObject.GetComponentInChildren<PreyBehavior>();
        //Debug.Log(l);
    }

    // Update is called once per frame
    void Update()
    {
        Transform[] father = GetComponentsInChildren<Transform>();

        if (father.Length > l - 1)
        {
            /*if (be.picked == true)
            {
                Destroy(gameObject);
            }*/
        }
    }
}
