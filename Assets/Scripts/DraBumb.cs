    using System;
    using UnityEngine;

    public class DraBumb : MonoBehaviour
    {
        [SerializeField] private float _schikumb;
        [SerializeField] private Rigidbody2D _papaTela;
        
        private void FixedUpdate()
        {
            _papaTela.MovePosition(_papaTela.position + Vector2.down * Time.deltaTime * _schikumb);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var vraginal = other.GetComponent<Vrazhina>();
            if (!vraginal)
                return;
            
            if (vraginal.Smert)
                return;
            
            vraginal.Potopil();
            Destroy(gameObject);
        }

        public event Action Netu;
        
        private void OnDestroy()
        {
            Netu?.Invoke();
        }
    }
