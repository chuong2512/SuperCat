namespace ChuongCustom.Example
{
    public class CoinHeartPurchase : DoubleValuePurchase
    {
        protected override void Setup()
        {
            
        }

        protected override void OnPurchaseSuccess()
        {
            ToastManager.Instance.ShowMessageToast("Buy Success!!");
            
            Data.Player.Heart += Value2;
        }
    }
}