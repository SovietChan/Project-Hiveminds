using System;
using System.Collections.Generic;
using Script.Runtime.Pawn;
using UnityEngine;
using UnityEngine.Serialization;


namespace Script.Runtime
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private List<InsectController> _allInsect;
        private List<InsectController> _infectedInsects;

        private int _currentInsectIndex;

        private void Start()
        {
            _infectedInsects = new List<InsectController>();
            for (int i = 0; i < _allInsect.Count; i++)
            {
                _allInsect[i].RegisterEvent(AddInfectedInsect);
                if (_allInsect[i].IsControlled)
                {
                    _currentInsectIndex = i;
                }
            }
        }

        private void AddInfectedInsect(InsectController insect)
        {
            
            _infectedInsects.Add(insect);
            _currentInsectIndex = _infectedInsects.Count - 1;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Kepanggil");
                if (_currentInsectIndex > 0)
                {
                    _currentInsectIndex--;
                    _infectedInsects[_currentInsectIndex].ControlInsect(true);
                    _infectedInsects[_currentInsectIndex+1].ControlInsect(false);
                }
                else if(_infectedInsects.Count > 0)
                {
                    _infectedInsects[_currentInsectIndex].ControlInsect(false);
                    _currentInsectIndex = _infectedInsects.Count - 1;
                    _infectedInsects[_currentInsectIndex].ControlInsect(true);
                }
            }
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (_currentInsectIndex < _infectedInsects.Count)
                {
                    _currentInsectIndex++;
                    _infectedInsects[_currentInsectIndex].ControlInsect(true);
                    _infectedInsects[_currentInsectIndex-1].ControlInsect(false);
                }
                else if(_infectedInsects.Count > 0)
                {
                    _infectedInsects[_currentInsectIndex].ControlInsect(false);
                    _currentInsectIndex = 0;
                    _infectedInsects[_currentInsectIndex].ControlInsect(true);
                }
            }
        }
        
        
    }
}
