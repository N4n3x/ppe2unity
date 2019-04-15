using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using TMPro;
using apiModele;

namespace apiModele
{
    public class Connexion : MonoBehaviour
    {
        public TMP_InputField email;
        public TMP_InputField mdp;

        private void Awake()
        {
            if (PlayerPrefs.GetString("user") != "")
            {
                //Debug.Log(PlayerPrefs.GetString("user"));
                SceneManager.LoadScene(1);
            }
            else
            {
                Debug.Log("non connecté");
            }
        }

        public void ConnexionApi()
        {
            User curUser = new User(email.text, mdp.text);
            //string userJson = curUser.UserToJson();
            StartCoroutine(curUser.ConnectUser(SetUser));
        }

        private void SetUser(bool isConnect, string userJson)
        {
            if (isConnect)
            {
                PlayerPrefs.SetString("user", userJson);
                SceneManager.LoadScene(1);
            }
            else
            {
                Debug.Log("Echec connexion");
            }
            
        }

        //public void Cnx()
        //{
        //    StartCoroutine( ConnexionApi());
        //}
    }
}

