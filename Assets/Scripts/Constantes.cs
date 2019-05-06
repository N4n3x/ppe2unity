using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace apiModele
{
    class Constantes
    {
        public const string urlApi = "http://151.80.190.149:8005";
        public const string uriConnect = "/auth/sign_in";
        public const string uriGetVehicles = "/vehicles";
        public const string uriGetUsages = "/usages";
        public const string uriGetUsagesFutur = "/usages/now";
        public const string uriUsageById = "/usages/"; // + id
        public const string uriGetAvailableVehicles = "/usages/available/"; // + datetime start/datetime end
        public const string uriGetUserByEmail = "/users/";// + email
        public const string uriPostUsage = "/usages";
    }
}
