using System;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
[RequireComponent(typeof(BoxCollider2D))]
public class Holduning : MonoBehaviour
{
    [SerializeField] private bool _unichtozhitel;
    
    [SerializeField] private Image _baza;
    [SerializeField] private Color _sev;
    [SerializeField] private Color _vstal;
    
    private BoxCollider2D _derzhalkaBaza;

    private RectTransform Batska => _bazaBatski == null ? GetComponent<RectTransform>() : _bazaBatski;
    
    private void OnEnable()
    {
        Peresobralsa();
    }

    private void OnRectTransformDimensionsChange()
    {
        Peresobralsa();
    }
    
    private RectTransform _bazaBatski;

    private void Peresobralsa()
    {
        Derzhalk.size = Batska.rect.size;
        Derzhalk.offset = Batska.rect.center;
    }

    public bool HareDavid { get; set; }

    public event Action Sev;
    private void OnMouseDown()
    {
        if (_unichtozhitel || HareDavid)
            return;
        
        _baza.color = _sev;
        Sev?.Invoke();
    }

    private void OnMouseUp()
    {
        if (_unichtozhitel || HareDavid)
            return;
        
        _baza.color = _vstal;
    }

    public event Action Vozukaem;
    private void OnMouseDrag()
    {
        if (_unichtozhitel || HareDavid)
            return;
        
        Vozukaem?.Invoke();
    }

    public event Action DrapBumb;
    private void OnMouseUpAsButton()
    {
        if (_unichtozhitel || HareDavid)
            return;
        
        DrapBumb?.Invoke();
    }

    private BoxCollider2D Derzhalk => _derzhalkaBaza == null ? GetComponent<BoxCollider2D>() : _derzhalkaBaza;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_unichtozhitel)
            return;
        
        Destroy(other.gameObject);
    }
}