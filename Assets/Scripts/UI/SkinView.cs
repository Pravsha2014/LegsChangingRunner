using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkinView : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;

    private Skin _skin;

    public event UnityAction<Skin, SkinView> OnButtonClicked;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void Start()
    {
        _button = GetComponentInChildren<Button>();
        _price = GetComponentInChildren<TMP_Text>();
        _icon = GetComponentInChildren<Image>();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    public void Render(Skin skin)
    {
        _skin = skin;

        _icon.sprite = skin.Icon;

        if (skin.IsBuyed == false)
        {
            _price.text = skin.Price.ToString();
        }

        skin.OnEquipped += ChangeButtonLockStatus;
    }

    private void ChangeButtonLockStatus(bool isEquipped)
    {
        _button.interactable = isEquipped;
    }

    private void OnButtonClick()
    {
        OnButtonClicked?.Invoke(_skin, this);
    }
}
