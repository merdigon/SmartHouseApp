module DotNetInterface
open DotNetStruct
open LocationEngine

///obliczanie współrzędnej użytkownika na podstawie pomiarów sił sygnałów
let countPosition (source : Sphere[]) =
     countUserPosition source