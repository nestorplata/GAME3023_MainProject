using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.WSA;

[RequireComponent(typeof(AudioSource))]
public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private List<TileRelatedSound> StepTileSounds;
    [SerializeField] private Tilemap BackGroundMap;
    [SerializeField] private AudioClip BasicFootStepSound;


    private AudioSource audioSource;

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
        var sprite = BackGroundMap.GetSprite(tpos);

        foreach (TileRelatedSound SoundStruct in StepTileSounds)
        {
            if (SoundStruct.sprite.name == sprite.name)
            {
                Debug.Log(SoundStruct.sprite.name);
                audioSource.clip = SoundStruct.FootStepSoundClip;
                audioSource.Play();
                return;
            }
        }
        Debug.Log(sprite.name);
        audioSource.clip = BasicFootStepSound;
        audioSource.Play();



    }

}
