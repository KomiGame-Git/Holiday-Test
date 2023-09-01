using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool MouseCursorSwitch { set; get; }
    // Start is called before the first frame update
    void Start()
    {
        this.MouseCursorSwitch = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (this.MouseCursorSwitch)
            {
                this.MouseCursorSwitch = false;
            }
            else
            {
                this.MouseCursorSwitch = true;
            }
        }

        if (this.MouseCursorSwitch)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void OnClickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
    UnityEngine.Application.Quit();
#endif
    }
}
