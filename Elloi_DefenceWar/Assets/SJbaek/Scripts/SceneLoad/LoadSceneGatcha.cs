using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneGatcha : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("GatchaScene");
    }
}
