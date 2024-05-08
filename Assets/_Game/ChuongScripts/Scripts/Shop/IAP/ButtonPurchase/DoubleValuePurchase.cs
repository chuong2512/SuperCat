using TMPro;
using UnityEngine;

namespace ChuongCustom
{
    public abstract class DoubleValuePurchase : ButtonPurchase<IAPDoubleValueData>
    {
        [SerializeField] private TextMeshProUGUI price;
        [SerializeField] private TextMeshProUGUI firstValueTMP;
        [SerializeField] private TextMeshProUGUI secondValueTMP;
        protected int Value1;
        protected int Value2;

        protected override void SetupPurchaseData(IAPDoubleValueData iapData)
        {
            price.SetText(iapData.price);
            firstValueTMP.SetText(iapData.coin.ToString());
            secondValueTMP.SetText(iapData.heart.ToString());
            Value1 = iapData.coin;
            Value2 = iapData.heart;
        }
    }
}