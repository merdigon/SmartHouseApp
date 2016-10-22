// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
open DotNetStruct

[<EntryPoint>]
let main argv =
    let squares = [| new Sphere(14.1,14.1,14.1, 14.1, new GausianProbabilityDistribution(14.1, 0.44));
                    new Sphere(14.1,34.1,34.1, 14.1, new GausianProbabilityDistribution(14.1, 0.44))|]
    
    let pos, prob = DotNetInterface.countPosition squares
    let x,y,z = pos
    printfn "%f, %f, %f, %f" x y z prob
    let y = System.Console.ReadKey()
    0 // return an integer exit code
