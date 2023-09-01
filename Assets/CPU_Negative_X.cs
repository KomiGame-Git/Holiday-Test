using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using TMPro;
using UnityEngine;

public class CPU_Negative_X : CPU_Bass
{
    private GameObject Player { set; get; }

    // Start is called before the first frame update
    void Start()
    {
        this.Text = "こんにちは。　X-方向です。";
        this.Player = GameObject.FindGameObjectWithTag("1P");
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    public override async Task ShowText(TextMeshProUGUI TextMeshProObject, Action MessageStart, Action MessageEnd, CancellationToken Token)
    {
        MessageStart();
        try
        {
            TextMeshProObject.text = this.Text;

            await Task.Delay(10000, Token);

            Debug.Log("メッセージ終わり");
        }
        catch (TaskCanceledException)
        {
            TextMeshProObject.text = "キャンセルされました。";
            //Debug.LogException(e);
            await Task.Delay(1000);

            Debug.Log("メッセージ中断");
            throw;
        }
        catch (ObjectDisposedException)
        {
            TextMeshProObject.text = "指定された cancellationToken は既に破棄されています。";
            //Debug.LogException(e);
            await Task.Delay(1000);
            throw;
        }
        finally
        {
            MessageEnd();
        }
    }
}
