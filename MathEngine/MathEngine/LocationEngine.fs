module LocationEngine
open DotNetStruct

let SIZE_OF_MIN_PICK_IN_BOX = 0.5

///wyciąganie pierwszego elementu z krotki
let fst3 (c,_,_) = c
///wyciąganie drugiego elementu z krotki
let snd3 (_,c,_) = c
///wyciąganie trzeciego elementu z krotki
let trd3 (_,_,c) = c

///dla podanych sfer, zwraca krotkę zawierającą wielkość prostopadłościanu,
///w którym mieszczą się sfery, oraz wektor, który należy zastosować na współrzędnych, aby dostosować je do nowego układu współrzędnych
let countBoxSize(source : Sphere[]) =
    let normalize minV maxV =
        float(int (maxV - minV) + 1)

    let listOfXToMax = List.map (fun (x:Sphere) -> x.X + x.Distance)  <| (Array.toList source)
    let listOfYToMax = List.map (fun (x:Sphere) -> x.Y + x.Distance)  <| (Array.toList source)
    let listOfZToMax = List.map (fun (x:Sphere) -> x.Z + x.Distance)  <| (Array.toList source)
    let listOfXToMin = List.map (fun (x:Sphere) -> x.X - x.Distance)  <| (Array.toList source)
    let listOfYToMin = List.map (fun (x:Sphere) -> x.Y - x.Distance)  <| (Array.toList source)
    let listOfZToMin = List.map (fun (x:Sphere) -> x.Z - x.Distance)  <| (Array.toList source)
    let minX = List.min listOfXToMin
    let maxX = List.max listOfXToMax
    let minY = List.min listOfYToMin    
    let maxY = List.max listOfYToMax
    let minZ = List.min listOfZToMin
    let maxZ = List.max listOfZToMax
    ((normalize minX maxX, normalize minY maxY, normalize minZ maxZ),(minX,minY,minZ))

///oblicze dystans między punktem, a środkiem sfery
let countDistanceBetweenPointAndSphere x y z (sphere : Sphere) = 
    sqrt ((x - sphere.X)**2.0 + (y - sphere.Y)**2.0 + (z - sphere.Z)**2.0)

///oblicza prawdopodobieństwo dla danej współrzędnej i listy sfer
let rec countProbabilityForPointAndSpheres x y z (source : Sphere list) = 
    match source with
    | [] -> 0.0
    | head :: tail -> (head.Guassian.Probability <| countDistanceBetweenPointAndSphere (double x) (double y) (double z) head) + (countProbabilityForPointAndSpheres x y z tail)
                      //match (xw,yw,zw) with
                      //| (x, y, z) when x >= 22.0 &&  x <= 23.0 && y >= 26.0 && y <= 27.0 && z >= 14.0 && z <= 15.0 ->   let res = (head.Guassian.Probability <| countDistanceBetweenPointAndSphere (double x) (double y) (double z) head) + (countProbabilityForPointAndSpheres x y z tail)
                       //                                                                                                 res
                      //| (x, y, z) -> (head.Guassian.Probability <| countDistanceBetweenPointAndSphere (double x) (double y) (double z) head) + (countProbabilityForPointAndSpheres x y z tail)                                                              

///dla każdego punktu w osi X prostopadłościanu oblicza prawdopodobieństwo
let rec createXRow x y z (source : Sphere list) xIter normalizer =
    if xIter <= 0 then
        []
    else 
        ((x, y, z), (countProbabilityForPointAndSpheres x y z source)) :: createXRow (x-normalizer) y z source (xIter-1) normalizer

///dla każdego punktu w osi Y prostopadłościanu generuje oś X pradopobieńst
let rec createYRow x y z (source : Sphere list) xIter yIter normalizer =
    if yIter <= 0 then
        []
    else 
        createXRow x y z source xIter normalizer :: createYRow x (y-normalizer) z source xIter (yIter-1) normalizer

///dla każdego punktu w osi Y prostopadłościanu generuje oś X pradopobieńst
let rec createZRow x y z (source : Sphere list) xIter yIter zIter normalizer =
    if zIter <= 0 then
        []
    else 
        createYRow x y z source xIter yIter normalizer :: createZRow x y (z-normalizer) source xIter yIter (zIter-1) normalizer

///dla każdego punktu w osi Z prostopadłościanu generuje płaszczyznę pradopobieńst XY
let positionWithMaxProb acc ((x,y,z), d) =
    match acc with
    | ((xa, ya, za), da) when d > da -> ((x,y,z),d) 
    | ((xa, ya, za), da) -> ((xa,ya,za),da)

///wyciąga z listy współrzędnych X tą z największym prawdopobieństwem
let rec getPosWithBestProbabilityForX probBox =
    match probBox with
    | [] -> []
    | head :: tail -> (List.fold positionWithMaxProb ((0.0,0.0,0.0),0.0) head) :: (getPosWithBestProbabilityForX tail)

///zamienia listę współrzędnych Y z listami X na listę największych prawdopodobieństw wyciągniętych z listy X
let rec getPosWithBestProbabilityForY probBox =
    match probBox with
    | [] -> []
    | head :: tail -> (List.fold positionWithMaxProb ((0.0,0.0,0.0),0.0) (getPosWithBestProbabilityForX head)) :: (getPosWithBestProbabilityForY tail)

///zamienia listę współrzędnych Z z płaszczyznami XY na listę największych prawdopodobieństw wyciągniętych z płaszczyzn XY
///a potem wybiera z niej tą współrzędną z największym prawdopodobieństwem
///skrótem: wszystkie funkcję wewnątrz wyciągają współrzędną z największym prawpodobieństwem z prostopadłościana
let getPosWithBestProbability probBox =
    getPosWithBestProbabilityForY probBox |>
    List.fold (positionWithMaxProb) ((0.0,0.0,0.0),0.0)

///normalizuje wynik do wejściowego układu współrzędnych przy użyciu wektora normalizującego, obliczonego podczas wyznaczania prostopadłościanu
let normalizeBestPosition ((x,y,z),p) (xn,yn,zn) =
    ((x+xn,y+yn,z+zn), p)

let countNormalizerBoxSize (x, y, z) =
    ([x;y;z] |> List.max) / 20.0  
    
let rec getPreciseBestPosition (x,y,z) normalizedSpheres accuracy =
    match accuracy with
    | acc when acc < SIZE_OF_MIN_PICK_IN_BOX -> (x,y,z)
    | acc -> let box = createZRow (x + acc) (y + acc) (z + acc) normalizedSpheres 6 6 6 (acc / 3.0)
             getPreciseBestPosition (fst <| getPosWithBestProbability box) normalizedSpheres (acc / 3.0)

///oblicza współrzędną użytkownika, która ma najwieksze prawdopodobieństwo
///1. Wyznaczenie nowego układu współrzędnych (brak wartości ujemnych) oraz wielkość rozpatrywanego prostopadłościanu
///2. Wypełnienie prostopadłościanu prawdopodobieństwami
///3. Wybranie współrzędnej z największym prawdopobieństwem
///4. Normalizacja wyniku do wejściowego układu współrzędnych
let countUserPosition(source : Sphere[]) =
    let boxSize, boxNormalizer = countBoxSize source
    let boxSizeX, boxSizeY, boxSizeZ = boxSize

    let sphereNormalizer (x,y,z) (sphere : Sphere) =
        new Sphere(sphere.X - x, sphere.Y - y, sphere.Z - z, sphere.Distance, sphere.Guassian)

    let normalizedSpheres = List.map (fun (x : Sphere) -> sphereNormalizer boxNormalizer x) <| (Array.toList source)
    let normalizer = countNormalizerBoxSize boxSize
    let xIter = int((fst3 boxSize) / normalizer) + 1
    let yIter = int((snd3 boxSize) / normalizer) + 1
    let zIter = int((trd3 boxSize) / normalizer) + 1
    let boxWithProbabilities = createZRow (float(xIter) * normalizer) (float(yIter) * normalizer) (float(zIter) * normalizer) normalizedSpheres xIter yIter zIter normalizer
    let bestPosUnnormalized = getPosWithBestProbability boxWithProbabilities
    let bestPosition = getPreciseBestPosition (fst bestPosUnnormalized) normalizedSpheres normalizer
    let prop, prob = normalizeBestPosition (bestPosition, snd bestPosUnnormalized) boxNormalizer
    let specX, specY, specZ = prop
    ((specX, specY, specZ), prob)


    