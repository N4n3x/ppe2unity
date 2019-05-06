using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace apiModele
{
    public class ClassRequest
    {
        string url;
        string bodyJsonString;
        UnityWebRequest request;
        public string json;
        public bool finished;
        public bool errorOccurred;

        public ClassRequest(string url, string bodyJsonString = " ")
        {
            this.url = url;
            this.bodyJsonString = bodyJsonString;
            finished = false;
            errorOccurred = false;
        }
        public IEnumerator PostRequest(Action<string> CallBack, string token = null)
        {
            request = new UnityWebRequest(this.url, "POST");
            byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(this.bodyJsonString);
            request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            if(token != null)
            {
                request.SetRequestHeader("autorisation", "JWT " + token);
            }

            yield return request.SendWebRequest();
            finished = true;

            if (request.isNetworkError)
            {
                Debug.Log("Something went wrong, and returned error: " + request.error);
                errorOccurred = true;
            }
            else
            {
                json = request.downloadHandler.text;
                if (request.responseCode == 200)
                {
                    Debug.Log("Request finished successfully! New User created successfully.");
                    yield return json;
                }
                else if (request.responseCode == 401)
                {
                    Debug.Log("Error 401: Unauthorized. Resubmitted request!");
                    //StartCoroutine(PostRequest(GenerateRequestURL(lastRequestURL, lastRequestParameters, "POST"), bodyJsonString));
                    errorOccurred = true;
                }
                else
                {
                    Debug.Log("Request failed (status:" + request.responseCode + ").");
                    errorOccurred = true;
                }

                if (!errorOccurred)
                {
                    yield return null;
                    // process results
                }
            }
            CallBack(json);

        }

        public IEnumerator GetRequest(Action<string> CallBack)
        {
            request = new UnityWebRequest(this.url, "GET");
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();
            finished = true;

            if (request.isNetworkError)
            {
                Debug.Log("Something went wrong, and returned error: " + request.error);
                errorOccurred = true;
            }
            else
            {
                
                if (request.responseCode == 200)
                {
                    Debug.Log("Request finished successfully! New User created successfully.");
                    json = request.downloadHandler.text;
                    yield return json;

                }
                else if (request.responseCode == 401)
                {
                    Debug.Log("Error 401: Unauthorized. Resubmitted request!");
                    //StartCoroutine(PostRequest(GenerateRequestURL(lastRequestURL, lastRequestParameters, "POST"), bodyJsonString));
                    errorOccurred = true;
                }
                else
                {
                    Debug.Log("Request failed (status:" + request.responseCode + ").");
                    errorOccurred = true;
                }

                if (!errorOccurred)
                {
                    yield return null;
                    // process results
                }
            }
            CallBack(json);
        }

        public IEnumerator PutRequest(Action<string> CallBack, string token = null)
        {
            request = new UnityWebRequest(this.url, "PUT");
            byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(this.bodyJsonString);
            request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");
            if (token != null)
            {
                request.SetRequestHeader("autorisation", "JWT " + token);
            }

            yield return request.SendWebRequest();
            finished = true;

            if (request.isNetworkError)
            {
                Debug.Log("Something went wrong, and returned error: " + request.error);
                errorOccurred = true;
            }
            else
            {
                json = request.downloadHandler.text;
                if (request.responseCode == 200)
                {
                    Debug.Log("Request finished successfully!");
                    yield return json;
                }
                else if (request.responseCode == 401)
                {
                    Debug.Log("Error 401: Unauthorized. Resubmitted request!");
                    //StartCoroutine(PostRequest(GenerateRequestURL(lastRequestURL, lastRequestParameters, "POST"), bodyJsonString));
                    errorOccurred = true;
                }
                else
                {
                    Debug.Log("Request failed (status:" + request.responseCode + ").");
                    errorOccurred = true;
                }

                if (!errorOccurred)
                {
                    yield return null;
                    // process results
                }
            }
            CallBack(json);

        }

        public IEnumerator DeleteRequest(Action<string> CallBack)
        {
            request = new UnityWebRequest(this.url, "DELETE");
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();
            finished = true;

            if (request.isNetworkError)
            {
                Debug.Log("Something went wrong, and returned error: " + request.error);
                errorOccurred = true;
            }
            else
            {

                if (request.responseCode == 200)
                {
                    Debug.Log("Request finished successfully! New User created successfully.");
                    json = request.downloadHandler.text;
                    yield return json;

                }
                else if (request.responseCode == 401)
                {
                    Debug.Log("Error 401: Unauthorized. Resubmitted request!");
                    //StartCoroutine(PostRequest(GenerateRequestURL(lastRequestURL, lastRequestParameters, "POST"), bodyJsonString));
                    errorOccurred = true;
                }
                else
                {
                    Debug.Log("Request failed (status:" + request.responseCode + ").");
                    errorOccurred = true;
                }

                if (!errorOccurred)
                {
                    yield return null;
                    // process results
                }
            }
            CallBack(json);
        }
    }
}

