using Script.Runtime.Pawn;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateScript : MonoBehaviour
{
    public GameObject _gate;
    public GameObject _gateOpenPos;
    public float _gateOpenSpeed;
    public gateScript _anotherGate;
    Vector3 _gateFirstPos;
    public enum Penginjak // your custom enumeration
    {
        Ant,
        GrassHopper,
        Beetle
    };
    public Penginjak _penginjak;
    // Start is called before the first frame update
    public bool _gateIsOpened;
    void Start()
    {
       _gateFirstPos = _gate.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(_gateIsOpened==true)//kalo pintu kebuka
        {
            _gate.transform.position = Vector3.Lerp(_gate.transform.position, _gateOpenPos.transform.position, _gateOpenSpeed * Time.deltaTime);
        }
        else//kalo ketutup
        {
            _gate.transform.position = Vector3.Lerp(_gate.transform.position, _gateFirstPos, _gateOpenSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //insecttype
        if (other.gameObject.GetComponent<InsectController>() != null)
        {
            if (other.gameObject.GetComponent<InsectController>().Data.name == _penginjak.ToString())
            {
                _gateIsOpened = true;
                if(_anotherGate!=null)
                {
                    _anotherGate._gateIsOpened = true;
                }
            }
        }
        else if(other.tag=="rock"&&_penginjak.ToString()== "Beetle")
        {
            _gateIsOpened = true;
            if (_anotherGate != null)
            {
                _anotherGate._gateIsOpened = true;
            }
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<InsectController>() != null)
        {
            if (other.gameObject.GetComponent<InsectController>().Data.name == _penginjak.ToString())
            {
                _gateIsOpened = false;
                if (_anotherGate != null)
                {
                    _anotherGate._gateIsOpened = false;
                }
            }
        }
        else if (other.tag == "rock" && _penginjak.ToString() == "Beetle")
        {
            _gateIsOpened = false;
            if (_anotherGate != null)
            {
                _anotherGate._gateIsOpened = false;
            }
        }
    }
}
