using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace apiModele
{
    public class BtnSupprUsage : MonoBehaviour
    {
        public ListItemController item;
        private ClassRequest request;
        public void OnClick()
        {
            request = new ClassRequest(Constantes.urlApi + Constantes.uriUsageById + item.usage._id);
            StartCoroutine(request.DeleteRequest(Result));
        }

        private void Result(string json)
        {
            Debug.Log(json);
            SceneManager.LoadScene(1);
        }
    }
}

