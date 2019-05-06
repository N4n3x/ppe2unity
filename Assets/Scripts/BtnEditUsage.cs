using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace apiModele
{
    public class BtnEditUsage : MonoBehaviour
    {
        public ListItemController item;
        public void EditUsage()
        {
            PlayerPrefs.SetString("usage", item.usage.ToJson());
            SceneManager.LoadScene(2);
            
        }
    }
}

