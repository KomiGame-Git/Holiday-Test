using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Player_1P : Player_Bass
{
    public float Speed = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.transform.position = new Vector3(0f, 5f, 0f);
        //gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        gameObject.transform.SetPositionAndRotation(new Vector3(0f,5f,0f), Quaternion.Euler(0f, 0f, 0f));

        this.Instance();
    }

    // Update is called once per frame
    async void Update()
    {
        this.MoveControl();

        if(Input.GetKeyUp(KeyCode.Space))
        {
            try
            {
                this.TokenSet();
                this.CPU_List.Sort((GameObject a, GameObject b) => { return (int)(Vector3.Distance(gameObject.transform.position,a.transform.position) - Vector3.Distance(gameObject.transform.position, b.transform.position)); });
                this.CPU = this.CPU_List[0].GetComponent<CPU_Bass>();
                await this.CPU.ShowText(this.TextMeshProObject, this.MsgStar, this.MsgEnd, this.Token);
                //await this.CPU_bass.ShowTextDelegate(this.TextMeshProObject, this.MsgStar, this.MsgEnd, this.Token);
            }
            catch
            {
                
            }
            finally
            {
                this.TokenDispose();
            }
            
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            try
            {
                this.TokenSet();
                await this.Holiday.ShowText(this.TextMeshProObject, this.MsgStar, this.MsgEnd, this.Token);
            }
            catch
            {

            }
            finally
            {
                this.TokenDispose();
            }

        }

    }

    protected override void MoveControl()
    {
        float X_Rotation = Input.GetAxis("Mouse X");
        gameObject.transform.Rotate(0, X_Rotation, 0);

        float X_Unit_Scalar = Input.GetAxis("Horizontal");
        float Z_Unit_Scalar = Input.GetAxis("Vertical");

        Vector3 vector3 = gameObject.transform.forward * Z_Unit_Scalar + gameObject.transform.right * X_Unit_Scalar;
        Vector3 UnitVector3 = vector3.normalized;

        Vector3 destination = transform.position + this.Speed * Time.deltaTime * UnitVector3;

        gameObject.transform.position = destination;
    }

    
}
