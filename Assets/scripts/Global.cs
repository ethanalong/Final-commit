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

                //清空玩家头顶拿到的食物
                foreach (Transform item in seletected.transform)
                {
                    Destroy(item.gameObject);
                }
                strGotFoodName = "";
                Debug.Log("Destroy food on player heard!");


                //如果给到对的工厂
                if (strCurrFactoryName.Equals(strTargetFactoryName))
                {
                    ScoreOnDestroy.instence.AddToScore(1);   //如果走对了工厂就加分
                }
                
                //如果给到错的工厂
            }
        }*/
    }

}
