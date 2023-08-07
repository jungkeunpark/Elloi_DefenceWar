using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenePartySet : MonoBehaviour
{
    public void Onclick()
    {
        SceneManager.LoadScene("PartySetScene");
    }
    
}
