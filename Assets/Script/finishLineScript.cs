using Script.Runtime.Pawn;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishLineScript : MonoBehaviour
{
    public enum Penginjak // your custom enumeration
    {
        Ant,
        GrassHopper,
        Beetle
    };
    public Penginjak _penginjak;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //insecttype
        if (other.gameObject.GetComponent<InsectController>() != null)
        {
            //if (other.gameObject.GetComponent<InsectController>().Data.name == _penginjak.ToString())
            //{
            //    _gateIsOpened = true;
            //}
            Debug.Log("game selesai");
        }

    }
}
