using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

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
        public string _id;
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

        //public IEnumerator ConnectUser(Action<bool, string> Callback)
        //{
        //    ClassRequest testConn = new ClassRequest(Constantes.urlApi + Constantes.uriConnect, ToJson());
        //    yield return testConn.PostRequest(Debug.Log);
        //    password = null;
        //    // Debug.Log(testConn.json);
        //    token = JsonUtility.FromJson<Token>(testConn.json);
            
        //    // Debug.Log(token);
        //    if (token.token is null)
        //    {
        //        Callback(false, "Identifiants incorrects");
        //    }
        //    else
        //    {
        //        ClassRequest getUser = new ClassRequest(Constantes.urlApi + Constantes.uriGetUserByEmail + email, ToJson());
        //        yield return getUser.PostRequest(Debug.Log);
                
        //        Callback(true, ToJson());
        //    }

        //}
    }

    [Serializable]
    public class Vehicle
    {
        public string _id;
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
        public string _id;
        public string start;
        public string end;
        public bool disable;
        public string description;
        public string purpose;
        public int km;
        public Vehicle vehicle;
        public User user;

        public Usage(string inStart, string inEnd,Vehicle inVehicle,User inUser, string inPurpose = " ", string inDescrition = " ", bool inDisable = false, int inKm = 0)
        {
            start = inStart;
            end = inEnd;
            vehicle = inVehicle;
            user = inUser;
            purpose = inPurpose;
            description = inDescrition;
            disable = inDisable;
            km = inKm;
        }

        public string ToJson()
        {
            return JsonUtility.ToJson(this);
        }
    }

}
