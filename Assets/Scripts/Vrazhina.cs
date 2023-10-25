using System;
using UnityEngine;

public class Vrazhina : MonoBehaviour
{
    [SerializeField] private Color _smertCvet;
    [SerializeField] private float _nelet;

    [SerializeField] private Rigidbody2D _babTka;
    [SerializeField] private SpriteRenderer _cvetok;

    public bool Smert { get; set; }
    public bool HareDvizh { get; set; }

    public Vector2 DestBegun { get; set; }

    private float _nehodit;

    private void Start()
    {
        _nehodit = ChiChacha.ShirVert.x - 1.8f;
    }

    private void FixedUpdate()
    {
        if (HareDvizh)
            return;

        Vector2 dviglo;

        if (Smert)
            dviglo = (Vector2)transform.right * (Time.deltaTime * _nelet);
        else
        {
            if (_babTka.position.x >= _nehodit)
            {
                _cvetok.flipX = true;
                DestBegun = Vector2.left;
            }
            
            if (_babTka.position.x <= -_nehodit)
            {
                _cvetok.flipX = false;
                DestBegun = Vector2.right;
            }
            
            dviglo = DestBegun * (Time.deltaTime * _nelet);
        }
        
        _babTka.MovePosition(_babTka.position + dviglo);
    }

    public void Potopil()
    {
        Smert = true;
        
        ZiznKonchena?.Invoke(this);
        
        _cvetok.color = _smertCvet;
        
        transform.rotation = Quaternion.Euler(0,0,-45f);
    }

    public event Action<Vrazhina> ZiznKonchena;
}