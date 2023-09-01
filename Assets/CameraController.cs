using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

using UnityEngine;

public delegate void FPS_TPS_ChangeEvent();

public class CameraController : MonoBehaviour
{
    private GameObject Player_1P { set; get; }

    private bool _FPS;
    private bool FPS
    {
        set
        {
            _FPS = value;
            this.Change_Event();
        }
        get
        {
            return _FPS;
        }
    }
    
    public event FPS_TPS_ChangeEvent Change_Event;

    // Start is called before the first frame update
    void Start()
    {
        this.Change_Event = this.Change;
        this.Player_1P = GameObject.FindGameObjectWithTag("1P");
        this.FPS = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            if (this.FPS)
            {
                this.FPS = false;
            }
            else
            {
                this.FPS = true;
            }
            
        }

    }

    void Change()
    {
        if (this.FPS)
        {
            gameObject.transform.position = this.Player_1P.transform.position + this.Player_1P.transform.forward * 2 + new Vector3(0f, 3f, 0f);
            gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else
        {
            gameObject.transform.position = this.Player_1P.transform.position + this.Player_1P.transform.forward * -10 + new Vector3(0f, 10f, 0f);
            gameObject.transform.localRotation = Quaternion.Euler(30f, 0f, 0f);
        }
    }


    
}
