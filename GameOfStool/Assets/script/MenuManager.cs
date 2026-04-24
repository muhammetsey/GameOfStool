using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Intro ekranındaki "Select your dynasty..." butonuna bunu bağla
    public void MenuyeGec()
    {
        SceneManager.LoadScene(1); // Sahne 1: Hanedan Seçimi
    }

    // MainMenu ekranındaki hanedan bayraklarına bunu bağla
    public void HanedanSecVeOyunaBasla(int hanedanNumarasi)
    {
        OyunVerileri.secilenHanedanID = hanedanNumarasi;
        SceneManager.LoadScene(2); // Sahne 2: Asıl Oyun
    }
}