﻿using System;
using UnityEngine;
using UnityEngine.Audio;

public class KingSpeech : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private AudioSource _kingSpeech;

    private void Awake()
    {
        MessageBus.Instance.Subscribe<GameState>(OnGameStateChanged);
        OnGameStateChanged(GameState.TitleScreen);
    }

    private void OnGameStateChanged(GameState state)
    {
        if (state == GameState.TitleScreen)
        {
            _mixer.SetFloat("musicVol", -25f);
            _kingSpeech.Play();
        }
        else
        {
            _mixer.SetFloat("musicVol", -15f);
            _kingSpeech.Stop();
        }
    }
}