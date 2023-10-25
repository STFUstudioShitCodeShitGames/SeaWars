using UnityEngine;
using UnityEngine.SceneManagement;

public class JumbaLunga : MonoBehaviour
{
    private int _bilbo;
    public void SetBilbo(int bilbo) => _bilbo = bilbo;

    private const int Bistruk = 120;
    
    private void Start()
    {
        Application.targetFrameRate = Bistruk;
    }

    public void Hingulag(bool hija)
    {
        if (hija)
        {
            Application.Quit();
            return;
        }

        SceneManager.LoadScene(_bilbo);
    }
}
