using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Intro ekranındaki "Select your dynasty..." butonuna bu bağlı
    public void MenuyeGec()
    {
        // Sesin çalması için 1saniye bekleyip, sonra alttaki "SahneBireGec" fonksiyonunu çalıştırır
        Invoke("SahneBireGec", 1f);
    }

    private void SahneBireGec()
    {
        SceneManager.LoadScene(1); // Sahne 1: Hanedan Seçimi
    }

    // MainMenu ekranındaki hanedan bayraklarına bu bağlı
    public void HanedanSecVeOyunaBasla(int hanedanNumarasi)
    {
        OyunVerileri.secilenHanedanID = hanedanNumarasi;

        // Bayrak seçimi butonlarında da sesin tam çalması için 0.4 saniye bekletiyoruz
        Invoke("SahneIkiyeGec", 1f);
    }

    private void SahneIkiyeGec()
    {
        SceneManager.LoadScene(2); // Sahne 2: Asıl Oyun
    }
}