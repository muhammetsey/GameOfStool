using UnityEngine;
[CreateAssetMenu(fileName = "New Olay Karti", menuName = "Olay Karti")]
public class OlayKarti : ScriptableObject
{
    public Sprite kartResmi;

    [Header("YES (Kabul Et) Etkileri")]
    public float yesMilitary;
    public float yesMorale;
    public float yesTreasury;
    public float yesProsperity;

    [Header("NO (Reddet) Etkileri")]
    public float noMilitary;
    public float noMorale;
    public float noTreasury;
    public float noProsperity;
    
}
