using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace apiModele
{
    public class ListController : MonoBehaviour
    {
        public GameObject ContentPanel;
        public GameObject ListItemPrefab;
        private Usage[] usages;
        private ClassRequest request;

        // Start is called before the first frame update
        void Start()
        {
            request = new ClassRequest(Constantes.urlApi + Constantes.uriGetUsages);
            StartCoroutine(request.GetRequest<Usage>());
            //usages = request.;
            
        }

        void initList()
        {
            //Debug.Log(usages.usages);
        }
    }

    
}

