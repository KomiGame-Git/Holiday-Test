using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;

using UnityEngine;
using UnityEngine.UI;
using TMPro;


public abstract class Player_Bass : MonoBehaviour, IPlayer
{
    public CancellationTokenSource Source { get; set; }
    protected CancellationToken Token { set; get; }

    protected TextMeshProUGUI TextMeshProObject { set; get; }
    protected Image CommentImage { set; get; }
    protected GameObject CancelButton { set; get; }

    protected CPU_Bass CPU { set; get; }
    protected List<GameObject> CPU_List { set; get; } = new List<GameObject>();

    protected Holiday Holiday { set; get; }

    protected virtual void Instance()
    {
        this.TextMeshProObject = GameObject.FindGameObjectWithTag("Text").GetComponent<TextMeshProUGUI>();
        this.CommentImage = GameObject.FindGameObjectWithTag("Image").GetComponent<Image>();
        this.CancelButton = GameObject.FindGameObjectWithTag("CancelButton");
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("CPU"))
        {
            this.CPU_List.Add(obj);
        }

        this.CPU = this.CPU_List[0].GetComponent<CPU_Bass>();

        this.Holiday = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Holiday>();

        this.MsgEnd();
    }

    protected abstract void MoveControl();

    public void MsgStar()
    {
        this.TextMeshProObject.enabled = true;
        this.CommentImage.enabled = true;
        this.CancelButton.SetActive(true);
    }
    public void MsgEnd()
    {
        this.TextMeshProObject.enabled = false;
        this.CommentImage.enabled = false;
        this.CancelButton.SetActive(false);
    }

    public void MessageCancel()
    {
        try
        {
            this.Source.Cancel();
        }
        catch
        {
            Debug.Log("CancelÇ≥ÇÍÇÈÅBâÔòbÇ™Ç»Ç¢Ç≈Ç∑ÅB");
        }
    }

    public void SetCPU(CPU_Bass cpu)
    {
        this.CPU = cpu;
    }

    public void TokenSet()
    {
        this.Source = new CancellationTokenSource();
        this.Token = this.Source.Token;
    }

    public void TokenDispose()
    {
        this.Source.Dispose();
    }

}


public interface IPlayer
{
    public void MsgStar();

    public void MsgEnd();

    public void MessageCancel();

    public void SetCPU(CPU_Bass cpu);
}