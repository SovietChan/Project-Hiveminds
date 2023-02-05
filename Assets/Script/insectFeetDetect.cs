using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Script.Runtime.Pawn;

public class insectFeetDetect : MonoBehaviour
{
    public bool _readyToDetect;
    public InsectController _thisInsectController;
    public Vector3 _feetPos;
    public GameObject _insectDiinjak;
    // Start is called before the first frame update
    void Start()
    {
        _thisInsectController = gameObject.GetComponentInParent<InsectController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (_readyToDetect)
        {
            if (other.tag == "Player")
            {
                _feetPos =  gameObject.transform.parent.transform.position- other.transform.position ;
                _insectDiinjak = other.gameObject;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (_readyToDetect)
        {
            if (other.tag == "Player")
            {
               _feetPos = Vector3.zero;
                _insectDiinjak = null;
            }

        }
    }
}
