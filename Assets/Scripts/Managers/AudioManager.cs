using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public BGM musicBGM;
    public List<SFX> audioSFX;
    
    private void Awake()
    {
        SingletonManager.Register(this);
    }

    public void playMusic()
    {
        musicBGM.musicFile.Play();
    }

    public void playSFX(int index)
    {
        audioSFX[index].musicFile.Play();
    }

}
