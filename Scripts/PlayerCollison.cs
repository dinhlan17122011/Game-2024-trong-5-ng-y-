using UnityEngine;

public class PlayerCollison : MonoBehaviour
{
    private GameMage GameMage;
    private AudioMage audioMage;
    private void Awake()
    {
        GameMage = FindAnyObjectByType<GameMage>();
        audioMage = FindAnyObjectByType<AudioMage>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            audioMage.PlayCoinMusic();
            GameMage.AddScore(1);
            Debug.Log("OK");
        }
        else if (collision.CompareTag("Trap"))
        {
            GameMage.GameOver();
            Debug.Log("KKKKK");
        }
        else if (collision.CompareTag("Enemy"))
        {
            GameMage.GameOver();
            Debug.Log("KKKKK");
        }
        else if (collision.CompareTag("Key"))
        {
            Destroy(collision.gameObject);
            GameMage.GameWin();
            Debug.Log("WIN BẠN LÀ LAI BANH CỦA Saigon Phantom");
        }
    }
}
