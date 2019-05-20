using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace apiModele
{
    public class ListController : MonoBehaviour
    {
        public GameObject ContentPanel;
        public GameObject ListItemPrefab;
        public ScrollRect ListView;
        private Usage[] usages;
        private ClassRequest request;

        // Start is called before the first frame update
        void Start()
        {
            request = new ClassRequest(Constantes.urlApi + Constantes.uriGetUsagesFutur);
            StartCoroutine(request.GetRequest(initList));
            ListView.verticalNormalizedPosition = 1;
        }

        void initList(string json)
        {
            usages = JsonClass.ArrayFromJson<Usage>(json);
            
            foreach(Usage usage in usages)
            {
                GameObject newUsage = Instantiate(ListItemPrefab) as GameObject;
                ListItemController controller = newUsage.GetComponent<ListItemController>();
                controller.usage = usage;
                controller.Start.text = System.DateTime.Parse(usage.start).ToString("dd/MM/yyyy HH:mm");
                controller.End.text = System.DateTime.Parse(usage.end).ToString("dd/MM/yyyy HH:mm");
                controller.Registration.text = usage.vehicle.registration.ToUpper();
                controller.Purpose.text = usage.purpose;
                controller.Description.text = usage.description;
                controller.User.text = usage.user.name;
                newUsage.transform.parent = ContentPanel.transform;
                newUsage.transform.localScale = Vector3.one;
            }
        }
    }

    
}

