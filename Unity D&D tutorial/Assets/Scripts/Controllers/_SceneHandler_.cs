using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class _SceneHandler_ : MonoBehaviour
{

    public void GoToScene()
    {
        SceneManager.LoadScene("_BATTLEFIELD_");
    }
}
