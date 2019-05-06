using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace apiModele
{
    public class FormNewUsage : MonoBehaviour
    {
        public DateTimeController start;
        public DateTimeController end;
        public DropdownVehicle vehicle;
        public InputField purpose;
        public InputField description;
        public Text textResult;
        private User user;
        private int compare;
        private Usage usage;
        private bool isNewUsage;

        // Start is called before the first frame update
        void Start()
        {
            Debug.Log(PlayerPrefs.GetString("user"));
            user = JsonUtility.FromJson<User>(PlayerPrefs.GetString("user"));
            InitForm();
        }

        private void Update()
        {
            compare = DateTime.Compare(end.date, start.date);
            if(compare <= 0)
            {
                end.date = start.date.AddMinutes(30);
            }
        }

        public void InitForm()
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
                vehicle.vehicleSelected = usage.vehicle;
                isNewUsage = false;
                Debug.Log("!=null");
            }
        }

        public void SubmitForm()
        {
            usage = new Usage(start.date.ToString("yyyy/MM/dd hh:mm"),end.date.ToString("yyyy/MM/dd hh:mm"),vehicle.vehicleSelected,user,purpose.text,description.text);
            Debug.Log(usage.ToJson());
            ClassRequest reqNewUsage = new ClassRequest(Constantes.urlApi + Constantes.uriPostUsage, usage.ToJson());
            if (isNewUsage)
            {
                StartCoroutine(reqNewUsage.PostRequest(GetResult, user.token.token));
            }
            else
            {
                Debug.Log("Send put request");
            }
            
        }

        public void GetResult(string json)
        {
            Debug.Log(json);
            Usage usageAdded = JsonUtility.FromJson<Usage>(json);
            if(usageAdded.start != null)
            {
                textResult.text = "Réservation accepté";
            }
            else
            {
                textResult.text = "Echec de la réservation";
            }
        }
    }
}

