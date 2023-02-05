using System.Collections;
using System.Collections.Generic;
using Script.Runtime.Pawn;
using UnityEngine;

public class HeadController : MonoBehaviour
{
    private InsectController _interactedInsect;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _interactedInsect = col.GetComponent<InsectController>();
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _interactedInsect = null;
        }
    }

    public InsectController GetInteractedInsect()
    {
        return _interactedInsect;
    }
}
