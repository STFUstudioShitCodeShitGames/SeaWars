using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChiChacha : MonoBehaviour
{
    [SerializeField] private Holduning _levi;
    [SerializeField] private Holduning _pravi;
    [SerializeField] private Holduning _bumb;
    [SerializeField] private DraBumb _draBumb;
    [SerializeField] private float _wowBist;
    [SerializeField] private GameObject _paket;
    [SerializeField] private Rigidbody2D _bazs;

    [SerializeField] private TMP_Text _scoka;
    [SerializeField] private TMP_Text _ubiv;
    [SerializeField] private TMP_Text _bestUbiv;
    [SerializeField] private Button _stopka;

    private float ograchil;

    private int _scocha = 20;
    
    public static Vector2 ShirVert { get; private set; }
    [SerializeField] private Vozvrashalkin _vozvrashalkin;

    private void Awake()
    {
        _levi.Vozukaem += () => OnVazukaem(Vector2.left);
        _pravi.Vozukaem += () => OnVazukaem(Vector2.right);
        _bumb.DrapBumb += OnDrapBumb;

        ograchil = GetMiraUgli(Camera.main).x - 1.8f;
        _paket.SetActive(false);
        Pridushka(false);
        _scoka.SetText($"Bomb: {_scocha}");
    }

    private void OnVazukaem(Vector2 naprav)
    {
        var kuda = _bazs.position + naprav * Time.deltaTime * _wowBist;
        kuda.x = Mathf.Clamp(kuda.x, -ograchil, ograchil);
        _bazs.MovePosition(kuda);
    }

    public static Vector2 GetMiraUgli(Camera figamera)
    {
        var xyNotZ = new Vector2(figamera.pixelWidth, figamera.pixelHeight);
        ShirVert = figamera.ScreenToWorldPoint(xyNotZ);
        return ShirVert;
    }

    private void OnDrapBumb()
    {
        if (_scocha == 0)
            return;
        
        _scocha--;
        _scoka.SetText($"Bomb: {_scocha}");
        var draBumb = Instantiate(_draBumb, transform.position, Quaternion.identity);
        if (_scocha == 0)
            draBumb.Netu += KonecGami;
    }

    private void KonecGami()
    {
        Pridushka(true);
        _stopka.interactable = false;
        
        var ubiv = PlayerPrefs.GetInt("UbivcaSeichas");
        var ubivBest = ubiv;
        if (!PlayerPrefs.HasKey("UbivcaBest") || PlayerPrefs.GetInt("UbivcaBest") < ubiv)
            PlayerPrefs.SetInt("UbivcaBest", ubiv);
        else
            ubivBest = PlayerPrefs.GetInt("UbivcaBest");

        _paket.SetActive(true);
        
        _ubiv.text = $"Score: {ubiv}";
        _bestUbiv.text = $"Best score: {ubivBest}";
    }

    public void Pridushka(bool daNet)
    {
        _levi.HareDavid = daNet;
        _pravi.HareDavid = daNet;
        _bumb.HareDavid = daNet;
        
        _vozvrashalkin.Stape(daNet);
    }
}
