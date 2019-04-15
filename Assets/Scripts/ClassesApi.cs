using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace apiModele
{
    [Serializable]
    public class Token
    {
        public string token;
    }

    [Serializable]
    public class Message
    {
        public string message;
    }

    [Serializable]
    public class Category
    {
        public string name;
    }

    [Serializable]
    public class Role
    {
        public string name;
    }

    [Serializable]
    public class User
    {
        public string name;
        public string email;
        public string hash_password;
        public bool disable;
        public Role role;
        public Token token;
        public string password;

        public User(string userEmail, string userPassword)
        {
            email = userEmail;
            password = userPassword;
        }

        public string ToJson()
        {
            return JsonUtility.ToJson(this);
        }

        public IEnumerator ConnectUser(Action<bool, string> Callback)
        {
            Debug.Log(Constantes.urlApi + Constantes.uriConnect);
            JsonPostReq testConn = new JsonPostReq(Constantes.urlApi + Constantes.uriConnect, ToJson());
            yield return testConn.PostRequest();
            password = null;
            Message message = JsonUtility.FromJson<Message>(testConn.res);
            //Message message = JsonClass.ArrayFromJson<Message>(testConn.res);

            if (message.message != null)
            {
                Callback(false, "Identifiants incorrects");
            }
            else
            {
                token = JsonUtility.FromJson<Token>(testConn.res);
                Callback(true, ToJson());
            }

        }
    }

    [Serializable]
    public class Vehicle
    {
        public string registration;
        public string description;
        public bool disable;
        public string energy;
        public int range;
        public int place;
        public Category Category;
    }

    [Serializable]
    public class Usage
    {
        public string start;
        public string end;
        public bool disable;
        public string description;
        public string purpose;
        public int km;
        public Vehicle vehicle;
        public User user;
    }


}
