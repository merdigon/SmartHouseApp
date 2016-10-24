// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open NUnit.Framework
open FsUnit
open FsCheck

[<TestFixture>]
type TestClass() = 

    [<Test>]
    member this.When2IsAddedTo2Expect4() = 
        Assert.AreEqual(4, 2+2)

