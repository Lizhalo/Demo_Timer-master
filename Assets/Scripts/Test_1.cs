﻿using UnityEngine;
using UnityEngine.UI;

public class Test_1 : MonoBehaviour
{
    string m_Mins = "0";
    string m_Sec = "0";
    float m_TempMins = 0;
    float m_TempSec = 0;
    bool m_IsTimed = true;
    bool m_IsCountDown = true;

    private void Awake()
    {
        //计时器
        //SetTimed("00:00");

        //倒计时
        SetTimed("10:00");
        string TimeStr = transform.GetComponent<Text>().text;
        string[] TimeStrSplit = TimeStr.Split(':');
        m_TempMins = float.Parse(TimeStrSplit[0]);
        m_TempSec = float.Parse(TimeStrSplit[1]);
        m_IsCountDown = false;
    }

    private void FixedUpdate()
    {
        if (m_IsCountDown)//计时器
        {
            if (m_IsTimed)
            {
                if (transform.GetComponent<Text>().text == "09:59")
                {
                    transform.GetComponent<Text>().text = "10:00";
                    m_Mins = "00";
                    m_Sec = "00";
                    m_TempMins = 0;
                    m_TempSec = 0;
                    m_IsTimed = false;
                }
                else
                {
                    if (m_TempSec >= 9)
                    {
                        m_Sec = (m_TempSec += 1).ToString();
                        if (m_TempSec == 60)
                        {
                            m_Sec = "00";
                            m_TempSec = 0;
                            m_TempMins += 1;
                        }
                    }
                    else
                    {
                        m_Sec = "0" + (m_TempSec += 1).ToString();
                    }
                    m_Mins = "0" + m_TempMins.ToString();
                    transform.GetComponent<Text>().text = m_Mins + ":" + m_Sec;
                }
            }
        }
        else//倒计时
        {
            if (m_IsTimed)
            {
                if (m_TempSec <= 10)
                {
                    if (m_TempSec == 0)
                    {
                        if (m_TempMins == 0)
                        {
                            transform.GetComponent<Text>().text = "00:00";
                            m_IsTimed = false;
                        }
                        else
                        {
                            m_TempSec = 60;
                            m_TempMins -= 1;
                            if (m_TempMins <= 10)
                            {
                                
                                m_Mins = "0" + m_TempMins.ToString();
                            }
                            else
                            {
                                m_Mins = m_TempMins.ToString();
                            }
                        }
                        m_Sec = m_TempSec.ToString();
                    }
                    else
                    {
                        m_Sec = "0" + (m_TempSec -= 1).ToString();
                    }
                }
                else
                {
                    m_Sec = (m_TempSec -= 1).ToString();
                }
                transform.GetComponent<Text>().text = m_Mins + ":" + m_Sec;
            }
        }
    }

    public void SetTimed(string time)
    {
        transform.GetComponent<Text>().text = time;
    }
}
