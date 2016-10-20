module LocationEngine
open DotNetStruct

//znormalizować Sphere w source

let normalize minV maxV =
    (+) 1 <| (int (maxV - minV))

let fst3 (c,_,_) = c
let snd3 (_,c,_) = c
let trd3 (_,_,c) = c

let countBoxSize(source : Sphere[]) =
    let listOfX = List.choose (fun (x:Sphere) -> Some(x.X))  <| (Array.toList source)
    let listOfY = List.choose (fun (x:Sphere) -> Some(x.Y))  <| (Array.toList source)
    let listOfZ = List.choose (fun (x:Sphere) -> Some(x.Z))  <| (Array.toList source)
    let minX = List.min listOfX
    let maxX = List.max listOfX
    let minY = List.min listOfY
    let maxY = List.max listOfY
    let minZ = List.min listOfZ
    let maxZ = List.max listOfZ
    ((normalize minX maxX, normalize minY maxY, normalize minZ maxZ),(minX,minY,minZ))

let countDistanceBetweenPointAndSphere x y z (sphere : Sphere) = 
    1.0;  //to do

let rec countProbabilityForPointAndSpheres x y z (source : Sphere list) = 
    match source with
    | [] -> 0.0
    | head :: tail -> (head.Guassian.Probability <| countDistanceBetweenPointAndSphere x y z head) + (countProbabilityForPointAndSpheres x y z tail)

let rec createXRow x y z (source : Sphere[]) =
    if x = 0 then
        []
    else 
        ((x, y, z), (countProbabilityForPointAndSpheres x y z (Array.toList source))) :: createXRow (x-1) y z source 

let rec createYRow x y z (source : Sphere[]) =
    if y = 0 then
        []
    else 
        createXRow x y z source :: createYRow x (y-1) z source 

let rec createZRow x y z (source : Sphere[]) =
    if z = 0 then
        []
    else 
        createYRow x y z source :: createZRow x y (z-1) source 
    
let countUserPosition(source : Sphere[]) =
    let boxSize, boxNormalizer = countBoxSize source
    let boxWithProbabilities = createZRow (fst3 boxSize) (snd3 boxSize) (trd3 boxSize) source
    fst 


    