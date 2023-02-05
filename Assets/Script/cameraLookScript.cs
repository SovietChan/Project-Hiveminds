using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraLookScript : MonoBehaviour
{
    public GameObject _lookTarget;
    public float _followSpeed;
    public float _cameraDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_lookTarget!=null)
        {
            if(_lookTarget!=null)
            {
                Vector3 cameraTargetPos = _lookTarget.transform.position;
                cameraTargetPos.z = transform.position.z;
                transform.position = Vector3.Lerp(transform.position, cameraTargetPos, _followSpeed * Time.deltaTime);
            }   
        }
    }
}
