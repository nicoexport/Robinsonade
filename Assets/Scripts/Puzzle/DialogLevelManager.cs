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

        private DialogLevelUI _currentDialogLevelUI;

        private int _actionType;

        [SerializeField] private AudioCue _unlockAudio;
        
        private bool _canPlayAudio = true;
        

        private void OnEnable()
        {
            _currentDialogLevelUI = Instantiate(dialogLevelUI_Prefab);

            //TODO: _currentDialogLevel = currentNPC.relationshipLevel
            //TODO: _dialogLevelThresholds = currentNPC.relationshipLevelThresholds
            //TODO: SetDialogLevel(_currentDialogLevel);
            _currentDialogLevel = 0;
            _currentDialogLevelUI.FaceImage.color = _currentDialogLevelUI.DialogLevelUISO.neutralColor;
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
            LeanTween.value(_currentDialogLevelUI.Bar.fillAmount, _currentDialogLevel / _maxDialogLevel, .5f).setOnUpdate(SetUI).setOnComplete(CheckforThreshold);
        }

        private void SetUI(float val)
        {
            _currentDialogLevelUI.Bar.fillAmount = val + (_barThickness * .5f);
            _currentDialogLevelUI.BarMask.fillAmount = val - (_barThickness * .5f);
            _currentDialogLevelUI.ScalaMask.fillAmount = val - (_barThickness * .5f);

            if (_actionType > 0)
            {
                _currentDialogLevelUI.FaceImage.overrideSprite = _currentDialogLevelUI.DialogLevelUISO.positiveSprite;
                _currentDialogLevelUI.FaceImage.color = _currentDialogLevelUI.DialogLevelUISO.positiveColor;
            }
            else if (_actionType < 0)
            {
                _currentDialogLevelUI.FaceImage.overrideSprite = _currentDialogLevelUI.DialogLevelUISO.negativeSprite;
                _currentDialogLevelUI.FaceImage.color = _currentDialogLevelUI.DialogLevelUISO.negativeColor;
            }
            else
            {
                _currentDialogLevelUI.FaceImage.overrideSprite = _currentDialogLevelUI.DialogLevelUISO.neutralSprite;
                _currentDialogLevelUI.FaceImage.color = _currentDialogLevelUI.DialogLevelUISO.neutralColor;
            }
        }

        private void CheckforThreshold()
        {
            _currentDialogLevelUI.FaceImage.overrideSprite = null;
            _currentDialogLevelUI.FaceImage.color = _currentDialogLevelUI.DialogLevelUISO.neutralColor;
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
    }
}
