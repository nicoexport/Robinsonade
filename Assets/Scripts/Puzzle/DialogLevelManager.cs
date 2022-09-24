using System;
using System.Collections;
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

        private DialogLevelUI _currentDialogLevelUI;

        private void Start()
        {
            _currentDialogLevelUI = Instantiate(dialogLevelUI_Prefab);

            //TODO: _currentDialogLevel = currentNPC.relationshipLevel
            //TODO: _dialogLevelThresholds = currentNPC.relationshipLevelThresholds
            //TODO: SetDialogLevel(_currentDialogLevel);
            _currentDialogLevel = 0;
            SetUI(_currentDialogLevel);

            // StartCoroutine(UpdateValue());
        }

        IEnumerator UpdateValue()
        {
            while (true)
            {
                yield return new WaitForSeconds(5f);
                SetDialogLevel(UnityEngine.Random.value * 100);
            }
        }

        public void SetDialogLevel(float value)
        {
            _currentDialogLevel = value * 10;
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
        }

        private void CheckforThreshold()
        {
            onSetDialogLevel?.Invoke(_currentDialogLevel);
        }
    }
}
