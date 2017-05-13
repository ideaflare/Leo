module Leo
open LeoSeq
open Prime

let a001 below =
    [1.. (below - 1)]
    |> List.filter (fun n -> n % 3 = 0 || n % 5 = 0)
    |> List.sum

let a002 max =
    fib
    |> Seq.skip 2
    |> Seq.takeWhile (fun n -> n < max)
    |> Seq.filter (fun n -> n % 2 = 0)
    |> Seq.sum

let a003 n =
    Prime.largestFactor n
