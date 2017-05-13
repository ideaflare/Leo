module TestLeo

open NUnit.Framework
open FsUnit

open Leo

[<Test>]
let ``Example Test`` () =
    a001 10 |> should equal 23