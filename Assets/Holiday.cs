using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using UnityEngine;
using TMPro;

public class Holiday : MonoBehaviour
{
    static readonly HttpClient client = new HttpClient();

    private GameObject Player { set; get; }


    // Start is called before the first frame update
    void Start()
    {
        this.Player = GameObject.FindGameObjectWithTag("1P");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    async Task<bool> HolidayCheck()
    {
        bool ret = false;

        try
        {
            string url = @"http://www8.cao.go.jp/chosei/shukujitsu/syukujitsu.csv";
            using Stream stream = await client.GetStreamAsync(url);
            using StreamReader streamReader = new StreamReader(stream, System.Text.Encoding.GetEncoding("shift-jis"));

            List<DateTime> holiday = new List<DateTime>();
            int s = 0;
            DateTime today = DateTime.Today;
            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
                if (s == 0) { s++; continue; }
                string[] ch = new string[2];
                ch = line.Split(',');

                DateTime date = DateTime.Parse(ch[0]);

                if (today.Year > date.Year)
                {
                    s++; continue;
                }
                holiday.Add(date);
                s++;
            }

            Debug.Log("�j���̃��X�g���擾�ł��܂����B");

            if(holiday.Contains(today))
            {
                ret = true;
            }

        }
        catch (Exception e)
        {
            Debug.LogError("�G���[���������܂����B�F" + e.ToString());
        }
        finally
        {
            
        }

        return ret;

    }


    public virtual async Task ShowText(TextMeshProUGUI TextMeshProObject, Action MessageStart, Action MessageEnd, CancellationToken Token)
    {
        MessageStart();
        try
        {

            bool _ret = await this.HolidayCheck();

            if (_ret)
            {
                TextMeshProObject.text = "�����͏j���ł��I�I";
            }
            else
            {
                TextMeshProObject.text = "�����͏j���ł͂���܂���B";
            }
            
            await Task.Delay(5000, Token);

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
        catch (Exception e)
        {
            TextMeshProObject.text = "�j�������f�ł��܂���ł����B";
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
