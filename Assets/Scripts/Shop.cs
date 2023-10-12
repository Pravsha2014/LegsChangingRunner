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

    private void OnDisable()
    {
        for(int i = 0; i < _itemContainer.transform.childCount; i++)
        {
            _itemContainer.GetComponentInChildren<SkinView>().OnButtonClicked -= OnSellButtonClicked;
        }
    }

    private void AddItem(Skin skin)
    {
        var view = Instantiate(_template, _itemContainer.transform);
        view.OnButtonClicked += OnSellButtonClicked;
        view.Render(skin);
    }

    private void OnSellButtonClicked(Skin skin, SkinView view)
    {
        if (skin.IsBuyed)
            Equip(skin);
        else
            TrySellSkin(skin, view);
    }

    private void TrySellSkin(Skin skin, SkinView view)
    {
        if (skin.Price <= _wallet.Amount)
        {
            _player.BuySkin(skin);
            view.ChangeBuyedView();
        }
    }

    private void Equip(Skin skin)
    {
        _player.EquipSkin(skin);
    }
}
