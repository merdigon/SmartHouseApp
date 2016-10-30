module DotNetStruct

type GausianProbabilityDistribution(_um : double, _sigma : double) = 
    member this.Um = _um
    member this.Sigma = _sigma
    
    ///zastosowanie funkcji rozkładu prawdopodobieńst Gaussa
    member this.Probability(x : double) =
        let numerator = -(((x - this.Um))**2.0) / (2.0 * (this.Sigma**2.0))
        let denominator = sqrt (2.0 * System.Math.PI * (this.Sigma**2.0))
        exp (numerator) * (1.0 / denominator)
    

type Sphere(x : double, y : double, z : double, distance : double, guassian : GausianProbabilityDistribution) =
    member this.X = x
    member this.Y = y
    member this.Z = z
    member this.Distance = distance
    member this.Guassian = guassian
