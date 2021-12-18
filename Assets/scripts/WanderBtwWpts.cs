using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderBtwWpts : MonoBehaviour
{
    public GameObject[] wpts;
    private NavMeshAgent agent;
    public GameObject text;

    // Start is called before the first frame update
    private void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        int d = Random.Range(0, wpts.Length);
        agent.SetDestination(wpts[d].transform.position);
    }

    // Update is called once per frame
    private void Update()
    {
        ScoreOnDestroy sc = text.GetComponent<ScoreOnDestroy>();
        float ssc = sc.score;
        if (agent.remainingDistance < 0.5)
        {
            //go somewhere else random
            int d = Random.Range(0, wpts.Length);
            agent.SetDestination(wpts[d].transform.position);
        }

        gameObject.transform.localScale = new Vector3(ssc * 0.5f + 1f, ssc * 0.5f + 1f, ssc * 0.5f + 1f);
    }
}