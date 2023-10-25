using TMPro;
using UnityEngine;

public class UbivcaSetter : MonoBehaviour
{
    [SerializeField] private TMP_Text _ubvcaTxt;

    private void Start()
    {
        var gav = 0;

        if (PlayerPrefs.HasKey("UbivcaBest"))
            gav = PlayerPrefs.GetInt("UbivcaBest");

        _ubvcaTxt.SetText($"Best score: {gav}");
    }
}