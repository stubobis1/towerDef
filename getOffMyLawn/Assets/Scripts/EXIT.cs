using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EXIT : MonoBehaviour
{
    public void ExitGame()

    {
        Debug.Log("EXIT");
        Application.Quit();
    }
}
