module DotNetInterface
open DotNetStruct
open LocationEngine
open SignalTool

///obliczanie współrzędnej użytkownika na podstawie pomiarów sił sygnałów
let iCountPosition (source : Sphere[]) =
    countUserPosition source

let iCountDistanceForWifiRouter fadeMargin transmitterPower antenaGainTransmitter signalStrenght deviceAtennaGain  : double =
    countDistanceForWifiRouter fadeMargin transmitterPower antenaGainTransmitter signalStrenght deviceAtennaGain