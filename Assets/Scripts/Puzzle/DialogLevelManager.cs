using System;
using System.Collections;
using Audio;
using UnityEngine;

namespace Architecture
{
    public class DialogLevelManager : Singleton<DialogLevelManager>
    {
        public event Action<float> onSetDialogLevel;

        [SerializeField]
        private float _maxDialogLevel;
        [SerializeField]
        private float _currentDialogLevel;

        [SerializeField]
        private float _barThickness;

        [SerializeField]
        private DialogLevelUI dialogLevelUI_Prefab;

        [SerializeField]
        private DialogLevelUISO dialogLevelUISO;

        public DialogLevelUI CurrentDialogLevelUI { get; private set; }

        private int _actionType;

        [SerializeField] private AudioCue _unlockAudio;
        [SerializeField] private AudioCue _loseUnlockAudio;
        private bool _canPlayAudio = true;


        private void Awake()
        {
            base.Awake();
            CurrentDialogLevelUI = Instantiate(dialogLevelUI_Prefab);
            CurrentDialogLevelUI.gameObject.SetActive(false);
        }
        
        private void OnEnable()
        {
            //TODO: _currentDialogLevel = currentNPC.relationshipLevel
            //TODO: _dialogLevelThresholds = currentNPC.relationshipLevelThresholds
            //TODO: SetDialogLevel(_currentDialogLevel);
            _currentDialogLevel = 0;
            CurrentDialogLevelUI.FaceImage.color = CurrentDialogLevelUI.DialogLevelUISO.neutralColor;
        }

        public void SetDialogLevel(float value)
        {
            if (value * 10f > _currentDialogLevel)
            {
                _actionType = 1;
            }
            else if (value * 10f < _currentDialogLevel)
            {
                _actionType = -1;
            }
            else
            {
                _actionType = 0;
            }
            _currentDialogLevel = Mathf.Clamp(value * 10f, 0f, _maxDialogLevel);
            AdjustDialogLevelUI();
        }

        private void AdjustDialogLevelUI()
        {
            LeanTween.value(CurrentDialogLevelUI.Bar.fillAmount, _currentDialogLevel / _maxDialogLevel, .5f).setOnUpdate(SetUI).setOnComplete(CheckforThreshold);
        }

        private void SetUI(float val)
        {
            CurrentDialogLevelUI.Bar.fillAmount = val + (_barThickness * .5f);
            CurrentDialogLevelUI.BarMask.fillAmount = val - (_barThickness * .5f);
            CurrentDialogLevelUI.ScalaMask.fillAmount = val - (_barThickness * .5f);

            if (_actionType > 0)
            {
                CurrentDialogLevelUI.FaceImage.overrideSprite = CurrentDialogLevelUI.DialogLevelUISO.positiveSprite;
                CurrentDialogLevelUI.FaceImage.color = CurrentDialogLevelUI.DialogLevelUISO.positiveColor;
            }
            else if (_actionType < 0)
            {
                CurrentDialogLevelUI.FaceImage.overrideSprite = CurrentDialogLevelUI.DialogLevelUISO.negativeSprite;
                CurrentDialogLevelUI.FaceImage.color = CurrentDialogLevelUI.DialogLevelUISO.negativeColor;
            }
            else
            {
                CurrentDialogLevelUI.FaceImage.overrideSprite = CurrentDialogLevelUI.DialogLevelUISO.neutralSprite;
                CurrentDialogLevelUI.FaceImage.color = CurrentDialogLevelUI.DialogLevelUISO.neutralColor;
            }
        }

        private void CheckforThreshold()
        {
            CurrentDialogLevelUI.FaceImage.overrideSprite = null;
            CurrentDialogLevelUI.FaceImage.color = CurrentDialogLevelUI.DialogLevelUISO.neutralColor;
            onSetDialogLevel?.Invoke(_currentDialogLevel);
        }

        public void PlayUnlockAudio()
        {
            Debug.Log("try play audio cue");
            if(!_canPlayAudio)
                return;
            _canPlayAudio = false;
            Debug.Log("play audio");
            _unlockAudio.PlayAudioCue();
            LeanTween.delayedCall(this.gameObject, 0.1f, () =>
            {
                _canPlayAudio = true;
            });
        }
        
        public void PlayLoseUnlockAudio()
        {
            Debug.Log("try play audio cue");
            if(!_canPlayAudio)
                return;
            _canPlayAudio = false;
            Debug.Log("play audio");
            _loseUnlockAudio.PlayAudioCue();
            LeanTween.delayedCall(this.gameObject, 0.1f, () =>
            {
                _canPlayAudio = true;
            });
        }
    }
}
