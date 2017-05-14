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

let a004 (digits : int) =    
    let searchRange =
        let maxNum = (System.Math.Pow(10.0, (float digits)) |> int) - 1
        [1 .. maxNum]
        |> List.filter (fun n -> NumberProperties.digitCount n = digits)
    let palindromeOrZero (a,b) =
        let product = a * b
        if NumberProperties.isPalindrone product then product else 0
    List.allPairs searchRange searchRange
    |> List.filter (fun (a,b) -> NumberProperties.isPalindrone (a * b))
    |> List.maxBy palindromeOrZero
    |> (fun (a,b) -> a * b)