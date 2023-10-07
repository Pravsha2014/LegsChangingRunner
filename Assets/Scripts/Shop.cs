using UnityEngine;
using System.Collections.Generic;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Skin> _skins;
    [SerializeField] private Player _player;
    [SerializeField] private SkinView _template;
    [SerializeField] private GameObject _itemContainer;

    private Wallet _wallet;

    private void Start()
    {
        _wallet = _player.gameObject.GetComponent<Wallet>();

        for (int i = 0; i < _skins.Count; i++)
        {
            AddItem(_skins[i]);
        }
    }

    private void AddItem(Skin skin)
    {
        var view = Instantiate(_template, _itemContainer.transform);
        view.OnButtonClicked += OnSellButtonClick;
        view.Render(skin);
    }

    private void OnSellButtonClick(Skin skin, SkinView view)
    {
        TrySellSkin(skin, view);
    }

    private void TrySellSkin(Skin skin, SkinView view)
    {
        if (skin.Price <= _wallet.Amount)
        {
            _player.BuySkin(skin);
            skin.Buy();
            view.OnButtonClicked -= OnSellButtonClick;
            view.OnButtonClicked += Equip;
        }
    }

    private void Equip(Skin skin, SkinView view)
    {
        _player.EquipSkin(skin);
    }
}
