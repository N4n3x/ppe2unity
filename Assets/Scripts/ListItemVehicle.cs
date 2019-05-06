using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace apiModele
{
    public class ListItemVehicle : MonoBehaviour
    {
        public Text Registration, Description, Range, Energy, Category, Places;
        public Vehicle vehicle;
        private Usage usage;

        public void OnClick()
        {
            if(PlayerPrefs.GetInt("isNewUsage") == 1)
            {
                usage = new Usage(PlayerPrefs.GetString("usageStart"), PlayerPrefs.GetString("usageEnd"), vehicle, JsonUtility.FromJson<User>(PlayerPrefs.GetString("user")));
                PlayerPrefs.SetString("usage", usage.ToJson());
            }
            else
            {
                usage = JsonUtility.FromJson<Usage>(PlayerPrefs.GetString("usage"));
                usage.vehicle = vehicle;
                PlayerPrefs.SetString("usage", usage.ToJson());
            }
            SceneManager.LoadScene(4);
        }
    }
}

