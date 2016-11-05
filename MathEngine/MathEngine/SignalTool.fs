module SignalTool

let countDistanceForWifiRouter fadeMargin transmitterPower antenaGainTransmitter signalStrenght deviceAtennaGain loses : double =
    let fspl = transmitterPower + antenaGainTransmitter + deviceAtennaGain - fadeMargin - signalStrenght - loses
    10.0 ** ((fspl + 27.55 - 67.75) / 20.0)
    