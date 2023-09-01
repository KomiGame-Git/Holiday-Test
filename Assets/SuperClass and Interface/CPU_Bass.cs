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
        this.Text = "CPU�̐e�N���X�ł�";
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    /// <summary>
    /// Action�^���g���ăf���Q�[�g���ԐړI�g�p
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
            TextMeshProObject.text = "�L�����Z������܂����B";
            Debug.LogException(e);
            await Task.Delay(1000);
            throw;
        }
        catch (ObjectDisposedException e)
        {
            TextMeshProObject.text = "�w�肳�ꂽ cancellationToken �͊��ɔj������Ă��܂��B";
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
    /// �f���Q�[�g�𒼐ڎg�p
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
            TextMeshProObject.text = "�L�����Z������܂����B";
            Debug.LogException(e);
            await Task.Delay(1000);
            throw;
        }
        catch (ObjectDisposedException e)
        {
            TextMeshProObject.text = "�w�肳�ꂽ cancellationToken �͊��ɔj������Ă��܂��B";
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
