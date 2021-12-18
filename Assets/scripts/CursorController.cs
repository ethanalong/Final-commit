using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class CursorController : MonoBehaviour
{
    public float Speed = 10.0f;

    public int h = 5;

    public string hunterTag = "Hunter";

    public GameObject hunterPrefab;
    public GameObject highLight;
    private GameObject[] _hunters;
    public GameObject _selectedHunter;
    public GameObject boo;
    private List<GameObject> loh;

    private RectTransform rect;

    private Transform _sr;

    public Camera Player2Camera0;
    public Camera Player2Camera1;

    /*    HunterController cont ;
        BoxCollider coll;
        Rigidbody g;
    */

    public static CursorController instence;

    private void Awake()
    {
        instence = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        _hunters = GameObject.FindGameObjectsWithTag("Hunter");
        loh = new List<GameObject>(_hunters);
        loh.Remove(boo);

        /*        _selectedHunter = loh[h];
                cont = _selectedHunter.GetComponent<HunterController>();
                 coll = _selectedHunter.GetComponent<BoxCollider>();
                 g = _selectedHunter.GetComponent<Rigidbody>();*/
    }

    public bool _isSelected = false;

    public void Rebirth()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        _selectedHunter = loh[h];
        HunterController cont = _selectedHunter.GetComponent<HunterController>();
        if (0 < h && h <= 11 && Input.GetButtonDown("LB2") && cont.enabled == false)
        {
            //Debug.Log("Input.GetButtonDown 614444");
            h = h - 1;
            return;
        }
        if (0 <= h && h < 11 && Input.GetButtonDown("RB2") && cont.enabled == false)
        {
            //Debug.Log("Input.GetButtonDown 6");
            h = h + 1;
            return;
        }
        if (h >= 11 && Input.GetButtonDown("RB2") && cont.enabled == false)
        {
            h = 0;
            return;
        }
        if (h <= 0 && Input.GetButtonDown("LB2") && cont.enabled == false)
        {
            h = 11;
            return;
        }
        BoxCollider coll = _selectedHunter.GetComponent<BoxCollider>();
        Rigidbody g = _selectedHunter.GetComponent<Rigidbody>();
        BoxCollider[] collt = _selectedHunter.GetComponentsInChildren<BoxCollider>();
        highLight.transform.SetParent(_selectedHunter.transform);
        highLight.transform.localPosition = new Vector3(0, 0, 0);
        highLight.transform.localRotation = new Quaternion(0, 0, 0, 0);
        /*Behaviour halo = (Behaviour)loh[h].GetComponent("Halo");
        halo.enabled = true;*/

        if (_isSelected)
        {
            if (Input.GetButtonDown("South2") || Global.instence.isRebirth)//hit north agn, abandon and respawn the hunter
            {
                //Debug.Log("Input.GetButtonDown 61");
                //HunterController contN = _selectedHunter.GetComponent<HunterController>();
                //Destroy(_selectedHunter);
                //GameObject newHunter = Instantiate(hunterPrefab, resp.position, resp.rotation);

                Global.instence.isRebirth = false;
                cont.enabled = false;
                coll.enabled = false;
                g.useGravity = false;
                for (int i = 0; i < collt.Length; i++)
                {
                    collt[i].enabled = false;
                }
                _isSelected = false;
                _selectedHunter.transform.SetParent(_sr);
                _selectedHunter.transform.localPosition = new Vector3(0, 0, 0);
                _selectedHunter.transform.localRotation = new Quaternion(0, 0, 0, 0);
                Player2Camera0.enabled = !Player2Camera0.enabled;
                Player2Camera1.enabled = !Player2Camera1.enabled;
                Rebirth();
            }
        }
        else
        {
            _sr = _selectedHunter.transform.parent;

            if (Input.GetButtonDown("South2"))//hit north and controll the hunter
            {
                //Debug.Log("Input.GetButtonDown 6144");
                _selectedHunter.transform.SetParent(null);
                cont.enabled = true;
                coll.enabled = true;
                for (int h = 0; h < collt.Length; h++)
                {
                    collt[h].enabled = true;
                }
                g.useGravity = true;
                _isSelected = true;
                Player2Camera0.enabled = !Player2Camera0.enabled;
                Player2Camera1.enabled = !Player2Camera1.enabled;
                Player2Camera1.transform.SetParent(_selectedHunter.transform);
                Player2Camera1.transform.localPosition = new Vector3(0, 3, -5);
                Player2Camera1.transform.localRotation = new Quaternion(0, 0, 0, 0);
            }
        }
    }
}