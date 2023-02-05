using System.Collections;
using System.Collections.Generic;
using Script.Runtime.Pawn;
using UnityEngine;

public class HeadController : MonoBehaviour
{
    private InsectController _interactedInsect;
    private bool _isClimbable;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _interactedInsect = col.GetComponent<InsectController>();
        }
        if (col.CompareTag("Ground") || col.CompareTag("Player"))
        {
            _isClimbable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _interactedInsect = null;
        }
        if (col.CompareTag("Ground") || col.CompareTag("Player"))
        {
            _isClimbable = false;
        }
    }

    public InsectController GetInteractedInsect()
    {
        return _interactedInsect;
    }
    
    public bool GetIsClimbable()
    {
        return _isClimbable;
    }
}
