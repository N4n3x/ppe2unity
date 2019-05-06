using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace apiModele
{
    public class DateTimeController : MonoBehaviour
    {
        public Text label, textDay;
        public Button btnUpDay, btnUpMonth, btnUpYear, btnUpHour, btnUpMinute, btnDownDay, btnDownMonth, btnDownYear, btnDownHour, btnDownMinute;
        public DateTime date;
        
        private void Start()
        {
            
        }

        private void Update()
        {
            textDay.text = date.ToString("dd/MM/yyyy HH:mm");
        }

        private void InitPicker(string stringDate = "")
        {
            if(stringDate != "")
            {
                date = DateTime.Parse(stringDate);
            }
            else
            {
                date = DateTime.Now;
            }
        }

        public void ForceUpdate(DateTime newDate)
        {
            textDay.text = newDate.ToString("dd/MM/yyyy HH:mm");
        }

        public void UpDay()
        {
            date = date.AddDays(1);
        }

        public void UpMonth()
        {
            date = date.AddMonths(1);
        }

        public void UpYear()
        {
            date = date.AddYears(1);
        }

        public void UpHour()
        {
            date = date.AddHours(1);
        }

        public void UpMinute()
        {
            if(date.Minute < 30)
            {
                date = date.AddMinutes(30 - date.Minute);
                Debug.Log(30 - date.Minute);
            }
            else
            {
                date = date.AddMinutes(30 - (date.Minute % 30));
                Debug.Log(30 - (date.Minute % 30));
            }
        }

        public void DownDay()
        {
            date = date.AddDays(-1);
        }

        public void DownMonth()
        {
            date = date.AddMonths(-1);
        }

        public void DownYear()
        {
            date = date.AddYears(-1);
        }

        public void DownHour()
        {
            date = date.AddHours(-1);
        }

        public void DownMinute()
        {
            if(date.Minute == 0 || date.Minute == 30)
            {
                date = date.AddMinutes(-30);
            }
            else if (date.Minute < 30)
            {
                date = date.AddMinutes(-date.Minute);
                Debug.Log(-30 + date.Minute);
            }
            else
            {
                date = date.AddMinutes(-date.Minute +30);
                Debug.Log(-30 + (date.Minute % 30));
            }
        }
    }
}

