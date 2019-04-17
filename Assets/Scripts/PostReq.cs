using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace apiModele
{
    public class JsonPostReq : MonoBehaviour
    {
        string url;
        string bodyJsonString;
        public string res;

        public JsonPostReq(string url,string bodyJsonString = " ")
        {
            this.url = url;
            this.bodyJsonString = bodyJsonString;
        }
        public IEnumerator PostRequest()
        {
            bool requestFinished = false;
            bool requestErrorOccurred = false;

            var request = new UnityWebRequest(this.url, "POST");
            byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(this.bodyJsonString);
            request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            
            yield return request.SendWebRequest();
            requestFinished = true;

            if (request.isNetworkError)
            {
                Debug.Log("Something went wrong, and returned error: " + request.error);
                requestErrorOccurred = true;
            }
            else
            {
                //Debug.Log("Response: " + request.downloadHandler.text);
                res = request.downloadHandler.text;
                if (request.responseCode == 201)
                {
                    Debug.Log("Request finished successfully! New User created successfully.");
                }
                //else if (request.responseCode == 401)
                //{
                //    Debug.Log("Error 401: Unauthorized. Resubmitted request!");
                //    StartCoroutine(PostRequest(GenerateRequestURL(lastRequestURL, lastRequestParameters, "POST"), bodyJsonString));
                //    requestErrorOccurred = true;
                //}
                else
                {
                    Debug.Log("Request failed (status:" + request.responseCode + ").");
                    requestErrorOccurred = true;
                }

                if (!requestErrorOccurred)
                {
                    yield return null;
                    // process results
                }
            }
        }
    }
}

