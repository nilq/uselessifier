using UnityEngine;
using System.Collections;

public class RawSound : MonoBehaviour {
    
    private double sampling_frequency = 48000;

    void OnAudioFilterRead(float[] data, int channels)
    {
        
        for (var i = 0; i < data.Length; i = i + channels)
        {
            data[i] = FileLoader.NextFloat();
            // if we have stereo, we copy the mono data to each channel
            if (channels == 2) data[i + 1] = data[i];
        }
    }
}
