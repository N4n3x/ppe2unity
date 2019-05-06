using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace apiModele
{
    public class DropdownVehicle : MonoBehaviour
    {
        public DateTimeController start;
        public DateTimeController end;
        public Dropdown dropdownVehicle;
        private List<string> listVehicles = new List<string>();
        private Vehicle[] vehicles;
        public Vehicle vehicleSelected;
        public string[] selectedValue;
        private ClassRequest request;

        private void Start()
        {
            request = new ClassRequest(Constantes.urlApi + Constantes.uriGetAvailableVehicles + start.date.ToString("yyyy-MM-dd hh:mm") + "/" + end.date.ToString("yyyy-MM-dd hh:mm"));
            StartCoroutine(request.GetRequest(PopulateDropdown));
        }

        public void OnDropdownChange(int index)
        {
            selectedValue = listVehicles[index].Split(' ');
            vehicleSelected = Array.Find<Vehicle>(vehicles, e => e.registration == selectedValue[1]);
        }

        private void PopulateDropdown(string json)
        {
            vehicles = JsonClass.ArrayFromJson<Vehicle>(json);
            foreach(Vehicle vehicle in vehicles)
            {
                listVehicles.Add(vehicle.description + " " + vehicle.registration);
            }
            dropdownVehicle.AddOptions(listVehicles);
            selectedValue = listVehicles[0].Split(' ');
            vehicleSelected = Array.Find<Vehicle>(vehicles, e => e.registration == selectedValue[1]);
        }

        public void ChangeVehicleSelected(Vehicle newVehicle)
        {
            dropdownVehicle.value = listVehicles.IndexOf(newVehicle.description + " " + newVehicle.registration);
        }

        public void UpdateDropdown()
        {
            request = new ClassRequest(Constantes.urlApi + Constantes.uriGetAvailableVehicles + start.date.ToString("yyyy-MM-dd hh:mm") + "/" + end.date.ToString("yyyy-MM-dd hh:mm"));
            StartCoroutine(request.GetRequest(PopulateDropdown));
        }
    }
}

