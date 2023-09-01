using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Threading.Tasks;

using UnityEngine;
using TMPro;

public delegate void messageMethod();

public class CPU_Bass : MonoBehaviour
{
    
    protected string Text { set; get; }
    
    // Start is called before the first frame update
    void Start()
    {
        this.Text = "CPUの親クラスです";
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    /// <summary>
    /// Action型を使ってデリゲートを間接的使用
    /// </summary>
    /// <param name="TextMeshProObject"></param>
    /// <param name="MessageStart"></param>
    /// <param name="MessageEnd"></param>
    public virtual async Task ShowText(TextMeshProUGUI TextMeshProObject, Action MessageStart, Action MessageEnd, CancellationToken Token)
    {
        MessageStart();
        try
        {
            TextMeshProObject.text = this.Text;

            await Task.Delay(2000, Token);

        }
        catch (TaskCanceledException e)
        {
            TextMeshProObject.text = "キャンセルされました。";
            Debug.LogException(e);
            await Task.Delay(1000);
            throw;
        }
        catch (ObjectDisposedException e)
        {
            TextMeshProObject.text = "指定された cancellationToken は既に破棄されています。";
            Debug.LogException(e);
            await Task.Delay(1000);
            throw;
        }
        finally
        {
            MessageEnd();
        }
        
    }

    /// <summary>
    /// デリゲートを直接使用
    /// </summary>
    /// <param name="TextMeshProObject"></param>
    /// <param name="MessageStart"></param>
    /// <param name="MessageEnd"></param>
    public virtual async Task ShowTextDelegate(TextMeshProUGUI TextMeshProObject,messageMethod MessageStart, messageMethod MessageEnd, CancellationToken Token)
    {
        MessageStart();
        try
        {
            TextMeshProObject.text = this.Text;

            await Task.Delay(2000, Token);

        }
        catch (TaskCanceledException e)
        {
            TextMeshProObject.text = "キャンセルされました。";
            Debug.LogException(e);
            await Task.Delay(1000);
            throw;
        }
        catch (ObjectDisposedException e)
        {
            TextMeshProObject.text = "指定された cancellationToken は既に破棄されています。";
            Debug.LogException(e);
            await Task.Delay(1000);
            throw;
        }
        finally
        {
            MessageEnd();
        }
    }

}
