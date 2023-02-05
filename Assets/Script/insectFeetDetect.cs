using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Script.Runtime.Pawn;

public class insectFeetDetect : MonoBehaviour
{
    public bool _readyToDetect;
    public InsectController _thisInsectController;
    // Start is called before the first frame update
    void Start()
    {
        _thisInsectController = gameObject.GetComponentInParent<InsectController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(_readyToDetect)
        {
            if(other.tag="player")
            //_thisInsectController._feetPos=
        }
    }
}
