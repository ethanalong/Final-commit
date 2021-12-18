using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PreyBehavior : MonoBehaviour
{
    [HideInInspector]
    public GameObject _hunters;

    private GameObject seletected;
    private GameObject[] _prey;
    public GameObject manager;

    public Transform hunter;
    private Transform movingFood;
    private Transform leg;

    [HideInInspector]
    public bool picked = false;
    private bool isHit = false;
    private bool isControlled = false;
    private bool grabRight = false;
    //private bool isPlayer = false;   //�Ƿ��ǿ����������ʳ��

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Mission");
        seletected = GameObject.FindGameObjectWithTag("Light");
        movingFood = this.gameObject.transform.parent;
        /*Transform[] father = GetComponentsInChildren<Transform>();
        for (int i = 0; i < father.Length; i++)
        {
            if (father[i].name== "BasicMotionsDummy")
            {
                leg = father[i];
                break;
            }
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        hunter = seletected.transform.parent;

        if (hunter.GetComponent<HunterController>().enabled)
        {
            isControlled = true;
        }
        else
        {
            isControlled = false;
        }

        if (isHit == true && isControlled == false)  //��ת����õ�
        {
            Drop();
        }

        /*if (isHit == true && isControlled == true && !Global.instence.isPlayerGotFood)
        {
            PickUp();
            if (gameObject==hunter.GetComponent<HunterController>().fs[manager.GetComponent<Manager>().start])
            {
                grabRight = true;
            }
        }
        else  
        {
            if(isHit == true && isControlled == false)  //��ת����õ�
            {
                Drop();
            }
            //���û�б���������õ����ٽ����ж��������
            *//*if (picked == true && isControlled == true)
            {
                Drop();
                grabRight = false;
                hunter.GetComponent<HunterController>().dropRight = false;
            }*//*
        }*/


    }

    /*void PickUp()
    {
        //Debug.Log("PickUp hunter = "+ hunter.gameObject.name);
        //Debug.Log("this.transform = " + this.transform.gameObject.name);
        picked = true;
        isHit = false;
        Global.instence.isPlayerGotFood = true; //�õ�ʳ����
        //transform.parent = hunter.transform;
        this.transform.parent = seletected.transform;
        this.transform.localPosition = new Vector3(0, 5f, 0);
        this.transform.localRotation = Quaternion.Euler(Vector3.zero);
        this.transform.localScale = new Vector3(20, 20, 20);
        //Destroy(movingFood);
        *//*GameObject go = Instantiate(this.gameObject, this.transform.position, Quaternion.identity);
        go.transform.localPosition = new Vector3(0,2.1f,0);
        go.transform.localRotation = Quaternion.Euler(Vector3.zero);
        go.transform.localScale = new Vector3(5,5,5);*//*
        Debug.Log("PickUp");
    }*/

    void Drop()
    {
        picked = false;
        isHit = false;
        Destroy(gameObject);  //�������ʳ�ʳ������
        Debug.Log("Drop");
    }

   private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hunter")
        {
            isHit = true;   //�������ʳ�isHit��ֵ

            
            /*if (other.gameObject.GetComponent<HunterController>().enabled)
            {
                hunter = other.gameObject.transform;
            }*/
            
           /* if(other.gameObject.name.Equals("PenguinPlayer"))    //PenguinPlayer
            {
                isPlayer = true;
            }*/
        }
    }

}
