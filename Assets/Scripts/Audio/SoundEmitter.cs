using System;
using System.Collections;
using Scriptable;
using UnityEngine;

namespace Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundEmitter : MonoBehaviour
    {
        AudioSource _audioSource;

        void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.playOnAwake = false;
        }

        public event Action<SoundEmitter> OnSoundFinishedPlaying;

        public void PlayAudioClip(AudioClip audioClip, AudioConfigSo config, bool hasToLoop, Vector3 position = default)
        {
            _audioSource.clip = audioClip;
            config.ApplyConfigToAudioSource(_audioSource);
            _audioSource.transform.position = position;
            _audioSource.loop = hasToLoop;
            _audioSource.Play();

            if (hasToLoop) return;
            StartCoroutine(FinishedPlayingEnumerator(audioClip.length));
        }

        public void Resume()
        {
            _audioSource.Play();
        }

        public void Pause()
        {
            _audioSource.Pause();
        }

        public void Stop()
        {
            _audioSource.Stop();
        }

        public bool IsLooping()
        {
            return _audioSource.loop;
        }

        IEnumerator FinishedPlayingEnumerator(float clipLength)
        {
            yield return new WaitForSeconds(clipLength);
            OnSoundFinishedPlaying?.Invoke(this);
        }

        public float GetVolume()
        {
            return _audioSource.volume;
        }

        public void SetVolume(float volume)
        {
            _audioSource.volume = volume;
        }

        public bool IsPlaying()
        {
            return _audioSource.isPlaying;
        }
    }
}