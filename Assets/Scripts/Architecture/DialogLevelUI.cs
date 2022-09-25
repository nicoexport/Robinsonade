using UnityEngine;
using UnityEngine.UI;

public class DialogLevelUI : MonoBehaviour
{
    [SerializeField]
    private Image _scala;
    [SerializeField]
    private Image _scalaMask;
    [SerializeField]
    private Image _bar;
    [SerializeField]
    private Image _barMask;
    [SerializeField]
    private DialogLevelUISO _dialogLevelUISO;
    [SerializeField]
    private Image _faceImage;

    public Image Scala { get => _scala; set => _scala = value; }
    public Image ScalaMask { get => _scalaMask; set => _scalaMask = value; }
    public Image Bar { get => _bar; set => _bar = value; }
    public Image BarMask { get => _barMask; set => _barMask = value; }
    public DialogLevelUISO DialogLevelUISO { get => _dialogLevelUISO; set => _dialogLevelUISO = value; }
    public Image FaceImage { get => _faceImage; set => _faceImage = value; }
}
