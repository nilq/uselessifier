using UnityEngine;
using System;  // Needed for Math

public class Sinus : MonoBehaviour
{
    // un-optimized version
    public double frequency = 880;
    public double gain = .8f;
    public double dampeningCoefficient;
    public double rampeningCoefficient;
    public double noiseGain;

    private double increment;
    private double phase;
    private double sampling_frequency = 48000;
    private double attenuation = 1;
    private System.Random r;

    bool isOn;

    void Awake()
    {
        r = new System.Random();
    }

    public void SetOn(bool setOn)
    {
        isOn = setOn;
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        double dampener = 1;
        double rampener = 0;

        if (!isOn)
            dampener = dampeningCoefficient;
        else
        {
            rampener = rampeningCoefficient;
        }
        // update increment in case frequency has changed
        increment = frequency * 2 * Math.PI / sampling_frequency;
        for (var i = 0; i < data.Length; i = i + channels)
        {
            phase = phase + increment;
            // this is where we copy audio data to make them “available” to Unity
            data[i] = (float)((gain * Math.Sin(phase) + (r.NextDouble()-0.5)*noiseGain) * attenuation);
            attenuation *= dampener;
            attenuation += rampener;
            attenuation = attenuation >= 1 ? 1 : attenuation;
            // if we have stereo, we copy the mono data to each channel
            if (channels == 2) data[i + 1] = data[i];
            if (phase > 2 * Math.PI) phase = 0;
        }
    }
}