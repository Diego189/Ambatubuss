using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]

/// <summary>
/// This class is used to clarify the properties of the sounds I introduce into the game.
/// Each sound has a name, volume, pitch, and the audio clip containing the sound
/// </summary>
public class Sound
{
    public string name; 

    public AudioClip clip;

    [Range(0f, 1f)] // Makes a slider in the Unity Editor
    public float volume;
    
    [Range(.1f, 3f)] 
    public float pitch;
    
    [HideInInspector]
    public AudioSource source;
}
