using UnityEngine;

public class MuzikYoneticisi : MonoBehaviour
{
    // Bu, müzik objesinden sahnede sadece 1 tane olmasını sağlayacak
    private static MuzikYoneticisi instance;

    void Awake()
    {
        // Eğer sahnede henüz bir müzik yöneticisi yoksa...
        if (instance == null)
        {
            instance = this;
            // Unity'ye "Sahne değişse bile bu objeyi SAKIN SİLME" diyoruz.
            DontDestroyOnLoad(gameObject);
        }
        // Eğer zaten bir müzik çalıyorsa ve yanlışlıkla 2. bir müzik oluşmaya çalışırsa, yenisini yok et.
        else
        {
            Destroy(gameObject);
        }
    }
}