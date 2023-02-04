using System;
using System.Collections.Generic;
using Script.Runtime.Pawn;
using UnityEngine;


namespace Script.Runtime
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private List<InsectController> _insects;

        private int _currentInsectIndex;

        private void Start()
        {
            for (int i = 0; i < _insects.Count; i++)
            {
                if (_insects[i].IsControlled)
                {
                    _currentInsectIndex = i;
                }
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Kepanggil");
                if (_currentInsectIndex > 0)
                {
                    _currentInsectIndex--;
                    _insects[_currentInsectIndex].ControlInsect(true);
                    _insects[_currentInsectIndex+1].ControlInsect(false);
                }
                else
                {
                    _insects[_currentInsectIndex].ControlInsect(false);
                    _currentInsectIndex = _insects.Count - 1;
                    _insects[_currentInsectIndex].ControlInsect(true);
                }
            }
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (_currentInsectIndex < _insects.Count)
                {
                    _currentInsectIndex++;
                    _insects[_currentInsectIndex].ControlInsect(true);
                    _insects[_currentInsectIndex-1].ControlInsect(false);
                }
                else
                {
                    _insects[_currentInsectIndex].ControlInsect(false);
                    _currentInsectIndex = 0;
                    _insects[_currentInsectIndex].ControlInsect(true);
                }
            }
        }
        
        
    }
}
