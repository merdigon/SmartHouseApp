module LocationEngine
open DotNetStruct

let SIZE_OF_PICK_IN_BOX = 0.5

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

///dla każdego punktu w osi X prostopadłościanu oblicza prawdopodobieństwo
let rec createXRow x y z (source : Sphere list) =
    if x <= 0.0 then
        []
    else 
        ((x, y, z), (countProbabilityForPointAndSpheres x y z source)) :: createXRow (x-SIZE_OF_PICK_IN_BOX) y z source 

///dla każdego punktu w osi Y prostopadłościanu generuje oś X pradopobieńst
let rec createYRow x y z (source : Sphere list) =
    if y <= 0.0 then
        []
    else 
        createXRow x y z source :: createYRow x (y-SIZE_OF_PICK_IN_BOX) z source 

///dla każdego punktu w osi Y prostopadłościanu generuje oś X pradopobieńst
let rec createZRow x y z (source : Sphere list) =
    if z <= 0.0 then
        []
    else 
        createYRow x y z source :: createZRow x y (z-SIZE_OF_PICK_IN_BOX) source

///dla każdego punktu w osi Z prostopadłościanu generuje płaszczyznę pradopobieńst XY
let positionWithMaxProb acc ((x,y,z), d) =
    match acc with
    | ((xa, ya, za), da) -> if d > da then ((x,y,z),d) else ((xa,ya,za),da)
    | _ -> ((x,y,z),d)

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

///oblicza współrzędną użytkownika, która ma najwieksze prawdopodobieństwo
///1. Wyznaczenie nowego układu współrzędnych (brak wartości ujemnych) oraz wielkość rozpatrywanego prostopadłościanu
///2. Wypełnienie prostopadłościanu prawdopodobieństwami
///3. Wybranie współrzędnej z największym prawdopobieństwem
///4. Normalizacja wyniku do wejściowego układu współrzędnych
let countUserPosition(source : Sphere[]) =
    let boxSize, boxNormalizer = countBoxSize source

    let sphereNormalizer (x,y,z) (sphere : Sphere) =
        new Sphere(sphere.X - x, sphere.Y - y, sphere.Z - z, sphere.Distance, sphere.Guassian)

    let normalizedSpheres = List.map (fun (x : Sphere) -> sphereNormalizer boxNormalizer x) <| (Array.toList source)
    let boxWithProbabilities = createZRow (fst3 boxSize) (snd3 boxSize) (trd3 boxSize) normalizedSpheres
    let bestPosUnnormalized = getPosWithBestProbability boxWithProbabilities
    normalizeBestPosition bestPosUnnormalized boxNormalizer


    