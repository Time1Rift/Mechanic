using UnityEngine;

public class CompositeRootShopUI
{
    private ButtonClose _buttonClose;
    private ButtonWindowOpening _buttonShop;
    private ShelfActiveCubes _shelfActiveCubes;
    private Shop _shop;

    public CompositeRootShopUI(InfoShopUI info)
    {
        _buttonShop = new ButtonWindowOpening(info.ButtonShop, info.AudioSource, info.ShopScreen);
        _buttonClose = new ButtonClose(info.ButtonClose, info.AudioSource, info.ShopScreen);
        Wallet wallet = new Wallet(info.WalletText);
        PurchasedCellShops purchasedCellShops = new PurchasedCellShops();
        _shelfActiveCubes = new ShelfActiveCubes(info.Bolts, info.ActiveCubes, purchasedCellShops);
        _shop = new Shop(info.Bolts, info.CellShopSpawner, wallet, purchasedCellShops);
    }

    public void Start()
    {
        _shop.Start();
    }

    public void Enable()
    {
        _buttonClose.Enabled();
        _buttonShop.Enabled();
        _shelfActiveCubes.Enable();
    }

    public void Disable()
    {
        _buttonClose.Disable();
        _buttonShop.Disable();
        _shelfActiveCubes.Disable();
    }
}