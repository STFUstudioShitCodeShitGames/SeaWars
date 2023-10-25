using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Vozvrashalkin : MonoBehaviour
{
    [SerializeField] private Vrazhina[] _vrazhinas;
    [SerializeField] private TMP_Text _scokaUbiv;
    
    private Dictionary<float, Vrazhina> _actualkin = new();

    private float _jijaX;

    private int _ubiv;
    
    private void Start()
    {
        _scokaUbiv.SetText(_ubiv.ToString());
        PlayerPrefs.SetInt("UbivcaSeichas", _ubiv);
        var rifa = ChiChacha.ShirVert;

        _jijaX = rifa.x + 1f;

        var himY = -rifa.y + 2f;

        for (int fd = 0; fd < 4; fd++)
        {
            _actualkin.Add(himY, null);
            himY += 1.2f;
        }
        
        Chigivarok();
    }

    private void Chigivarok()
    {
        foreach (var hrY in _actualkin.Keys.ToList())
        {
            var vrazh = Rodilka(hrY);
            _actualkin[hrY] = vrazh;
            vrazh.ZiznKonchena += OnVrazhVmer;
        }
    }

    private void OnVrazhVmer(Vrazhina vrazhina)
    {
        _ubiv += Random.Range(100, 201);
        _scokaUbiv.SetText(_ubiv.ToString());
        PlayerPrefs.SetInt("UbivcaSeichas", _ubiv);
        
        vrazhina.ZiznKonchena -= OnVrazhVmer;
        var dver= _actualkin.FirstOrDefault(x => x.Value == vrazhina).Key;
        var vrazh = Rodilka(dver);
        vrazh.ZiznKonchena += OnVrazhVmer;
        _actualkin[dver] = vrazh;
    }

    private Vrazhina Rodilka(float hrY)
    {
        var kuda = Random.Range(0, 2) == 0 ? Vector2.right : Vector2.left;
        var jijaX = _jijaX * kuda.x;
        var gde = new Vector2(jijaX, hrY);
        var vrazh = Instantiate(_vrazhinas[Random.Range(0, _vrazhinas.Length)], gde, Quaternion.identity, transform);
        vrazh.DestBegun = kuda;
        return vrazh;
    }

    public void Stape(bool stape)
    {
        foreach (var actualkinValue in _actualkin.Values)
            actualkinValue.HareDvizh = stape;
    }
}
