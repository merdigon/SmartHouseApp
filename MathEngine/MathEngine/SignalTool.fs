module SignalTool

let countDistanceForWifiRouter fadeMargin transmitterPower antenaGainTransmitter signalStrenght deviceAtennaGain  : double =
    let fspl = transmitterPower + antenaGainTransmitter + deviceAtennaGain - fadeMargin - signalStrenght
    10.0 ** ((fspl + 27.55 - 67.75) / 20.0)
    