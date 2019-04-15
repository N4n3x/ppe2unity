using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace apiModele
{
    public class DisplayUsage : MonoBehaviour
    {
        User user;
        // Start is called before the first frame update
        private void Awake()
        {
            user = JsonUtility.FromJson<User>(PlayerPrefs.GetString("user"));
            Debug.Log(user.email);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

