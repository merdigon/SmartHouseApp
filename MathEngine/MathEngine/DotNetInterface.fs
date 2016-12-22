module DotNetInterface
open DotNetStruct
open LocationEngine
open SignalTool

///obliczanie współrzędnej użytkownika na podstawie pomiarów sił sygnałów
let iCountPosition (source : Sphere[]) =
    countUserPosition source

let iCountDistanceForWifiRouter transmitterPower antenaGainTransmitter signalStrenght deviceAtennaGain loses  : double =
    countDistanceForWifiRouter transmitterPower antenaGainTransmitter signalStrenght deviceAtennaGain loses

let iCountDistanceBetweenTwoPoints (x1:double) (y1:double) (z1:double) (x2:double) (y2:double) (z2:double) : double =
    sqrt ((x1 - x2)**2.0 + (y1 - y2)**2.0 + (z1 - z2)**2.0)