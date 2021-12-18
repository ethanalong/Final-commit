using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HunterRoaming : MonoBehaviour
{
    public float turnSpeed = 50f;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed);
    }
}