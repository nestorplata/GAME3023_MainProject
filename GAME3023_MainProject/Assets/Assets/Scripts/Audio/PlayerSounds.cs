using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(AudioSource))]
public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private List<TileRelatedSound> StepTileSounds;
    [SerializeField] private Tilemap BackGroundMap;
    [SerializeField] private AudioClip BasicFootStepSound;
    
    private AudioSource audioSource;
    private string SavedTilename;
    // Start is called before the first frame update

    [System.Serializable]

    public struct TileRelatedSound
    {
        public Sprite sprite;
        public AudioClip FootStepSoundClip;
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = BasicFootStepSound;
    }


    public void PlayFootStep()
    {
        var tpos = BackGroundMap.WorldToCell(transform.position);
        string TileBelow = BackGroundMap.GetSprite(tpos).name;
        if (SavedTilename!= TileBelow)
        {
            audioSource.clip = GetCorrespontingSound(TileBelow);
            SavedTilename = TileBelow;
        }
        audioSource.Play();
    }

   public AudioClip GetCorrespontingSound(string tile)
    {
        foreach (TileRelatedSound SoundStruct in StepTileSounds)
        {
            if (SoundStruct.sprite.name == tile)
            {
                return SoundStruct.FootStepSoundClip;
            }
        }
        return BasicFootStepSound;
    }

}
