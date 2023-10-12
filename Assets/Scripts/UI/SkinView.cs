using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkinView : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Image _coinIcon;
    [SerializeField] private Sprite _checkMark;

    private Skin _skin;

    public event UnityAction<Skin, SkinView> OnButtonClicked;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
        _skin.OnEquipped -= ChangeButtonLockStatus;
    }

    public void Render(Skin skin)
    {
        _skin = skin;

        _icon.sprite = skin.Icon;

        if (skin.IsBuyed == false)
        {
            _price.text = skin.Price.ToString();
        }
        else
        {
            ChangeBuyedView();
            ChangeButtonLockStatus(skin.IsEquipped);
        }

        skin.OnEquipped += ChangeButtonLockStatus;
    }

    public void ChangeBuyedView()
    {
        _price.text = string.Empty;
        _coinIcon.sprite = _checkMark;
    }

    private void ChangeButtonLockStatus(bool isEquipped)
    {
        _button.interactable = !isEquipped;
    }

    private void OnButtonClick()
    {
        OnButtonClicked?.Invoke(_skin, this);
    }
}
