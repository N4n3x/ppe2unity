using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace apiModele
{
    public class FinaliseUsage : MonoBehaviour
    {
        public Text start, end, vehicle;
        public InputField purpose, description;
        private Usage usage;
        private ClassRequest request;

        private void Start()
        {
            usage = JsonUtility.FromJson<Usage>(PlayerPrefs.GetString("usage"));
            start.text = usage.start;
            end.text = usage.end;
            vehicle.text = usage.vehicle.registration;
            if(PlayerPrefs.GetInt("isNewUsage") == 0)
            {
                purpose.text = usage.purpose;
                description.text = usage.description;
            }
        }

        public void OnClick()
        {
            usage.purpose = purpose.text;
            usage.description = description.text;
            
            if (PlayerPrefs.GetInt("isNewUsage") == 1)
            {
                string json = usage.ToJson();
                json = json.Remove(1, 9); // supprime _id
                Debug.Log(usage.ToJson());
                request = new ClassRequest(Constantes.urlApi + Constantes.uriPostUsage, json);
                
                StartCoroutine(request.PostRequest(Result, PlayerPrefs.GetString("token")));
            }
            else
            {
                request = new ClassRequest(Constantes.urlApi + Constantes.uriPostUsage + "/" + usage._id, usage.ToJson());
                StartCoroutine(request.PutRequest(Result));
            }
            PlayerPrefs.DeleteKey("usage");
            PlayerPrefs.DeleteKey("startUsage");
            PlayerPrefs.DeleteKey("endUsage");
            PlayerPrefs.DeleteKey("isNewUsage");
        }

        public void Result(string json)
        {
            Debug.Log(json);
            SceneManager.LoadScene(1);
        }
    }
}

