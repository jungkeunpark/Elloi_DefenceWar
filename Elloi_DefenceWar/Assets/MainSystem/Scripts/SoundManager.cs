using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}

public class SoundManager : MonoBehaviour
{
    static public SoundManager soundManager;

    private void Awake()
    {
        if (soundManager == null)
        {
            soundManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public Sound[] effectSounds;    // ȿ���� ����� Ŭ����
    public Sound[] bgmSounds;       // BGM ����� Ŭ����

    public AudioSource audioSource_BGMPlayer; // BGM �����.
    public AudioSource[] audioSource_MP3Player; // MP3 �����. ȿ������ ���ÿ� ������ ����� �� �����Ƿ� �迭�� ����

    public string[] playSoundName;  // ������� ȿ���� ���� �̸� �迭

    private void Start()
    {
        playSoundName = new string[audioSource_MP3Player.Length];
    }

    // ȿ������ ����ϴ� �Լ�
    public void PlaySE(string _name)
    {
        for (int i = 0; i < effectSounds.Length; i++)
        {
            // ������ ȿ������ �ִٸ�
            if(_name == effectSounds[i].name)
            {
                for(int j = 0; j < audioSource_MP3Player.Length; j++)
                {
                    // ����ǰ� ���� ���� mp3 �����
                    if (audioSource_MP3Player[j].isPlaying == false)
                    {
                        audioSource_MP3Player[j].clip = effectSounds[i].clip;
                        audioSource_MP3Player[j].Play();
                        playSoundName[j] = effectSounds[i].name;
                        return;
                    }
                }
            }
        }
    }

    // BGM�� ����ϴ� �Լ�
    public void PlayBGM(string _name)
    {
        for(int i = 0; i < bgmSounds.Length; i++)
        {
            if(_name == bgmSounds[i].name)
            {
                audioSource_BGMPlayer.clip = bgmSounds[i].clip;
                audioSource_BGMPlayer.Play();
                return;
            }
        }
    }

    // BGM ����
    public void StopBGM()
    {
        audioSource_BGMPlayer.Stop();
    }

    // ��� ȿ���� ����
    public void StopAllSE()
    { 
        for(int i = 0; i < audioSource_MP3Player.Length; i++)
        {
            audioSource_MP3Player[i].Stop();
        }
    }

    // ȿ���� ����
    public void StopSE(string _name)
    {
        // ������ ȿ������ �ִٸ� ����
        for(int i = 0; i < audioSource_MP3Player.Length; i++)
        {
            if (playSoundName[i] == _name)
            {
                audioSource_MP3Player[i].Stop();
                break;
            }
        }
    }
}
