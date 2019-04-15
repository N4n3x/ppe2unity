using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnDisconnect : MonoBehaviour
{
    public void DisconnectUser()
    {
        PlayerPrefs.DeleteKey("user");
        SceneManager.LoadScene(0);
    }
}
