namespace OrderCreation;

public enum StopTriggerMethod
{
    //
    // Riepilogo:
    //     Trade method uses default trigger behavior for Stop orders. Buy order and Stop
    //     Loss for Sell position will be triggered when Ask >= order price. Sell order
    //     and Stop Loss for Buy position will be triggered when Bid <= order price.
    Trade,
    //
    // Riepilogo:
    //     Opposite method uses opposite price for order triggering. Buy order and Stop
    //     Loss for Sell position will be triggered when Bid >= order price. Sell order
    //     and Stop Loss for Buy position will be triggered when Ask <= order price.
    Opposite,
    //
    // Riepilogo:
    //     Uses default prices for order triggering, but waits for additional confirmation
    //     - two consecutive prices should meet criteria to trigger order. Buy order and
    //     Stop Loss for Sell position will be triggered when two consecutive Ask prices
    //     >= order price. Sell order and Stop Loss for Buy position will be triggered when
    //     two consecutive Bid prices <= order price.
    DoubleTrade,
    //
    // Riepilogo:
    //     Uses opposite prices for order triggering, and waits for additional confirmation
    //     - two consecutive prices should meet criteria to trigger order. Buy order and
    //     Stop Loss for Sell position will be triggered when two consecutive Bid prices
    //     >= order price. Sell order and Stop Loss for Buy position will be triggered when
    //     two consecutive Ask prices <= order price.
    DoubleOpposite
}