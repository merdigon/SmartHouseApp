// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
open DotNetStruct

[<EntryPoint>]
let main argv =
    let squares = [| new Sphere(10.0,50.0,0.0, 82.22, new GausianProbabilityDistribution(82.22, 3.0));
                    new Sphere(80.0, 20.0, 0.0, 69.18, new GausianProbabilityDistribution(69.18, 3.0));
                    new Sphere(50.0, 80.0, 0.0, 39.9, new GausianProbabilityDistribution(39.9, 3.0))|]
    
    let pos, prob = DotNetInterface.iCountPosition squares
    let x,y,z = pos
    printfn "%f, %f, %f, %f" x y z prob
    let y = System.Console.ReadKey()
    0 // return an integer exit code
