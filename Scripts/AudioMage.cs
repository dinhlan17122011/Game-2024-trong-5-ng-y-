using UnityEngine;

public class AudioMage : MonoBehaviour
{
    [SerializeField] private AudioSource backgroudAudio;
    [SerializeField] private AudioSource effectAudio;
    [SerializeField] private AudioClip backgroudClip;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip coinClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayBackGroudMusic();
    }
    private void PlayBackGroudMusic()
    {
        backgroudAudio.clip = backgroudClip;
        backgroudAudio.Play();
    }
    public void PlayCoinMusic()
    {
        effectAudio.PlayOneShot(coinClip);
    }
    public void PlayJumpMusic()
    {
        effectAudio.PlayOneShot(jumpClip);
    }
}
