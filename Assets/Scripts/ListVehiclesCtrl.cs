using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace apiModele
{
    public class ListVehiclesCtrl : MonoBehaviour
    {
        public GameObject ContentPanel;
        public GameObject ListItemPrefab;
        public ScrollRect ListView;
        private Vehicle[] vehicles;
        private ClassRequest request;

        void Start()
        {
            request = new ClassRequest(Constantes.urlApi + Constantes.uriGetAvailableVehicles + PlayerPrefs.GetString("usageStart") + "/" + PlayerPrefs.GetString("usageEnd"));
            Debug.Log(Constantes.urlApi + Constantes.uriGetAvailableVehicles + PlayerPrefs.GetString("usageStart") + "/" + PlayerPrefs.GetString("usageEnd"));
            StartCoroutine(request.GetRequest(initList));
            ListView.verticalNormalizedPosition = 1;
        }

        void initList(string json)
        {
            vehicles = JsonClass.ArrayFromJson<Vehicle>(json);

            foreach (Vehicle vehicle in vehicles)
            {
                GameObject newVehicle = Instantiate(ListItemPrefab) as GameObject;
                ListItemVehicle controller = newVehicle.GetComponent<ListItemVehicle>();
                controller.Registration.text = vehicle.registration;
                controller.Description.text = vehicle.description;
                controller.Range.text = vehicle.range.ToString();
                controller.Places.text = vehicle.place.ToString();
                controller.Energy.text = vehicle.energy;
                controller.Category.text = vehicle.Category.name;
                controller.vehicle = vehicle;
                newVehicle.transform.parent = ContentPanel.transform;
                newVehicle.transform.localScale = Vector3.one;
            }
        }
    }
}

