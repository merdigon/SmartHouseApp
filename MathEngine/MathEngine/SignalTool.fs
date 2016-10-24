module SignalTool

let PATH_LOSS_EXPONENT = 5.0

let countDistanceForWifiRouter signalStrenght rsssiOnZeroDistance : double =
    10.0 ** ((signalStrenght - rsssiOnZeroDistance) / (-10.0 * PATH_LOSS_EXPONENT))