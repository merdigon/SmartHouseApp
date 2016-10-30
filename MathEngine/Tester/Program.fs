// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
open DotNetStruct

[<EntryPoint>]
let main argv =
    let squares = [| new Sphere(14.1,14.1,14.1, 14.1, new GausianProbabilityDistribution(14.1, 3.0));
                    new Sphere(34.1,34.1,14.1, 14.1, new GausianProbabilityDistribution(14.1, 3.0));
                    new Sphere(14.1,24.1,14.1, 14.1, new GausianProbabilityDistribution(14.1, 3.0))|]
    
    let pos, prob = DotNetInterface.iCountPosition squares
    let x,y,z = pos
    printfn "%f, %f, %f, %f" x y z prob
    let y = System.Console.ReadKey()
    0 // return an integer exit code
