using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarScena : MonoBehaviour
{
    public void CambiarScenaClick(string scenaName)
    {
        SceneManager.LoadScene(scenaName);
    }

    public void SalirJuego()
    {
        Application.Quit();
    }
}
