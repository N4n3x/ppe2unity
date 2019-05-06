using System;
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
        private User curUser;

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
            curUser = new User(email.text, mdp.text);
            //string userJson = curUser.UserToJson();
            StartCoroutine(UserLogin(SetUser));
        }

        private IEnumerator UserLogin(Action<bool, string> Callback)
        {
            Debug.Log(Constantes.urlApi + Constantes.uriGetUserByEmail + email.text);
            ClassRequest getUser = new ClassRequest(Constantes.urlApi + Constantes.uriGetUserByEmail + email.text);
            yield return getUser.GetRequest(Debug.Log);
            ClassRequest testConn = new ClassRequest(Constantes.urlApi + Constantes.uriConnect, curUser.ToJson());
            yield return testConn.PostRequest(Debug.Log);
            curUser.password = null;
            Debug.Log(getUser.json);
            curUser = JsonUtility.FromJson<User>(getUser.json);
            curUser.token = JsonUtility.FromJson<Token>(testConn.json);
            Debug.Log(curUser._id);
            if (curUser.token is null)
            {
                Callback(false, "Identifiants incorrects");
            }
            else
            {
                Callback(true, curUser.ToJson());
            }
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

