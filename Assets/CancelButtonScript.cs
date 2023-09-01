using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CancelButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MessagaCancel()
    {
        GameObject.FindGameObjectWithTag("1P").GetComponent<Player_Bass>().MessageCancel();
    }
}
