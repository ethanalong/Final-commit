using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public static Global instence;
    public bool isPlayerGotFood;
    public GameObject seletected;
    public string strGotFoodName;
    public string strTargetFoodName;
    public string strTargetFactoryName;
    public string strCurrFactoryName;

    public bool isRebirth=false;

    private void Awake()
    {
        instence = this;
        isPlayerGotFood = false;
        strGotFoodName = "";
    }

    void Start()
    {
        
        seletected = GameObject.FindGameObjectWithTag("Light");
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPlayerGotFood)
            {
                isPlayerGotFood = false;

                //������ͷ���õ���ʳ��
                foreach (Transform item in seletected.transform)
                {
                    Destroy(item.gameObject);
                }
                strGotFoodName = "";
                Debug.Log("Destroy food on player heard!");


                //��������ԵĹ���
                if (strCurrFactoryName.Equals(strTargetFactoryName))
                {
                    ScoreOnDestroy.instence.AddToScore(1);   //����߶��˹����ͼӷ�
                }
                
                //���������Ĺ���
            }
        }*/
    }

}
