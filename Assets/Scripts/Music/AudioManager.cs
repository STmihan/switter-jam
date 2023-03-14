using Gameplay.Controllers;
using Loops.GlobalLoop.States;
using Music.States;
using StateManagement;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using Utility;
using Random = UnityEngine.Random;

namespace Music
{
    public class AudioManager : MonoSingleton<AudioManager>
    {
        private const string MasterVolume = "MasterVolume";
        
        [SerializeField] private AudioClip _ambientClip;
        [SerializeField] private AudioClip _musicClip;
        [SerializeField] private AudioClip _setUnitClip;
        [SerializeField] private AudioClip _uiClickClip;
        [Space]
        [SerializeField] private AudioSource _musicSource;
        [SerializeField] private AudioSource _sfxSource;
        [Space]
        [SerializeField] private AudioMixerGroup _musicMixerGroup;

        private StateMachine<MusicData> _stateMachine;

        private bool _mute;

        protected override void OnCreate()
        {
            MusicData data = new MusicData
            {
                AmbientClip = _ambientClip,
                MusicClip = _musicClip,
                MusicSource = _musicSource
            };
            _stateMachine = new StateMachine<MusicData>(data, new EmptyState());
            SceneManager.sceneLoaded += OnSceneLoaded;
            PauseController.OnPauseChanged += OnPauseChanged;
        }
        
        public void PlayGameOverMusic() => _stateMachine.ChangeState(new AmbientMusicState());
        public void PlaySetUnitSound()
        {
            float musicSourcePitch = _sfxSource.pitch;
            _sfxSource.pitch = Random.Range(0.4f, 0.6f);
            _sfxSource.PlayOneShot(_setUnitClip);
            _sfxSource.pitch = musicSourcePitch;
        }

        public void PlayUIClickSound()
        {
            float musicSourcePitch = _sfxSource.pitch;
            _sfxSource.pitch = Random.Range(0.8f, 1.2f);
            _sfxSource.PlayOneShot(_uiClickClip);
            _sfxSource.pitch = musicSourcePitch;
        }

        public void Mute(bool on)
        {
            if (on)
            {
                _musicMixerGroup.audioMixer.SetFloat(MasterVolume, -80);
            }
            else
            {
                _musicMixerGroup.audioMixer.SetFloat(MasterVolume, 0);
            }
        }

        private void OnPauseChanged(bool obj)
        {
            if (obj)
            {
                _stateMachine.ChangeState(new AmbientMusicState());
            }
            else
            {
                _stateMachine.ChangeState(new FightMusicState());
            }
        }

        private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            switch (arg0.name)
            {
                case MenuState.SceneName:
                    _stateMachine.ChangeState(new AmbientMusicState());
                    break;
                case GameplayState.SceneName:
                    _stateMachine.ChangeState(new FightMusicState());
                    break;
            }
        }
    }
}