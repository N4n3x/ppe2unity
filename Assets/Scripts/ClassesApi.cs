using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace apiModele
{
    /// <summary>
    /// Token d'autentification pour l'API
    /// </summary>
    [Serializable]
    public class Token
    {
        public string token;
    }
    /// <summary>
    /// Message d'erreur envoyé par l'API
    /// </summary>
    [Serializable]
    public class Message
    {
        public string message;
    }
    /// <summary>
    /// Catégorie d'un véhicule
    /// </summary>
    [Serializable]
    public class Category
    {
        public string name;
    }
    /// <summary>
    /// Rôle d'un utilisateur
    /// </summary>
    [Serializable]
    public class Role
    {
        public string name;
    }
    /// <summary>
    /// Utilisateur de l'application
    /// </summary>
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
        /// <summary>
        /// Constructeur de la classe User
        /// </summary>
        /// <param name="userEmail">Email de l'utilisateur</param>
        /// <param name="userPassword">Mot de passe de l'utilisateur</param>
        public User(string userEmail, string userPassword)
        {
            email = userEmail;
            password = userPassword;
        }
        /// <summary>
        /// retourne l'objet au format JSON
        /// </summary>
        /// <returns>JSON</returns>
        public string ToJson()
        {
            return JsonUtility.ToJson(this);
        }
    }
    /// <summary>
    /// 
    /// </summary>
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

        public Usage(string inStart, string inEnd, Vehicle inVehicle, User inUser, string inPurpose = " ", string inDescrition = " ", bool inDisable = false, int inKm = 0)
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
