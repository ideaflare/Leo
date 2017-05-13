module TestLeo

open NUnit.Framework
open FsUnit

open Leo

[<Test>]
let ``->`` () =
    //a001 10 |> should equal 23
    a002 89 |> should equal 44