namespace BlazingPizza.Services;

public class OrderState
{
    /// <summary>
    /// 注文ダイアログの表示の有無
    /// </summary>
    public bool ShowingConfigureDialog { get; private set; }

    /// <summary>
    /// ピザの設定
    /// </summary>
    public Pizza ConfiguringPizza { get; private set; }
    
    /// <summary>
    /// 注文
    /// </summary>
    public Order Order { get; private set; } = new Order();

    /// <summary>
    /// ピザ設定ダイアログを表示するメソッド
    /// </summary>
    /// <param name="special"></param>
    public void ShowConfigurePizzaDialog(PizzaSpecial special)
    {
        ConfiguringPizza = new Pizza()
        {
            Special = special,
            SpecialId = special.Id,
            Size = Pizza.DefaultSize,
            Toppings = new List<PizzaTopping>(),
        };

        ShowingConfigureDialog = true;
    }

    /// <summary>
    /// キャンセル時にピザダイアログを初期化するメソッド
    /// </summary>
    public void CancelConfigurePizzaDialog()
    {
        ConfiguringPizza = null;

        ShowingConfigureDialog = false;
    }

    /// <summary>
    /// ピザ設定確認ダイアログ
    /// </summary>
    public void ConfirmConfigurePizzaDialog()
    {
        Order.Pizzas.Add(ConfiguringPizza);
        ConfiguringPizza = null;

        ShowingConfigureDialog = false;
    }
}