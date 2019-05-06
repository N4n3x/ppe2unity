using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace apiModele
{
    public class SelectDateNewUsage : MonoBehaviour
    {
        public DateTimeController start;
        public DateTimeController end;
        private int compare;
        private Usage usage;
        private bool isNewUsage;

        private void Start()
        {
            InitForm();
        }
        // Update is called once per frame
        private void Update()
        {
            compare = DateTime.Compare(end.date, start.date);
            if (compare <= 0)
            {
                end.date = start.date.AddMinutes(30);
            }
            DateTime now = DateTime.Now;
            if (DateTime.Compare(start.date, now) < 0)
            {
                start.date = now;
            }
        }

        private void InitForm()
        {
            if (PlayerPrefs.GetString("usage") == "")
            {
                Debug.Log("null");
                isNewUsage = true;
            }
            else
            {
                usage = JsonUtility.FromJson<Usage>(PlayerPrefs.GetString("usage"));
                
                PlayerPrefs.SetString("usage", "");
                start.date = DateTime.Parse(usage.start);
                end.date = DateTime.Parse(usage.end);
                start.ForceUpdate(DateTime.Parse(usage.start));
                isNewUsage = false;
            }
        }

        public void Next()
        {
            if (isNewUsage)
            {
                PlayerPrefs.SetInt("isNewUsage", 1);
                PlayerPrefs.SetString("usageStart", start.date.ToString("yyyy-MM-dd hh:mm"));
                PlayerPrefs.SetString("usageEnd", end.date.ToString("yyyy-MM-dd hh:mm"));
                SceneManager.LoadScene(3);
            }
            else
            {
                PlayerPrefs.SetInt("isNewUsage", 0);
                PlayerPrefs.SetString("usageStart", start.date.ToString("yyyy-MM-dd hh:mm"));
                PlayerPrefs.SetString("usageEnd", end.date.ToString("yyyy-MM-dd hh:mm"));
                usage.start = start.date.ToString("yyyy-MM-dd hh:mm");
                usage.end = end.date.ToString("yyyy-MM-dd hh:mm");
                PlayerPrefs.SetString("usage", usage.ToJson());
                SceneManager.LoadScene(3);
            }
        }
    }
}

