using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Butonlara basıldığında çalışacak fonksiyon
    // Unity'de butondan buraya 1, 2, 3 gibi rakamlar göndereceğiz
    public void HanedanSecVeOyunaBasla(int hanedanNumarasi)
    {
        // Gelen numarayı köprümüze (hafızaya) kaydediyoruz
        OyunVerileri.secilenHanedanID = hanedanNumarasi;

        // 1 numaralı sahneyi (Oyun sahnemizi) yüklüyoruz
        SceneManager.LoadScene(1);
    }
}