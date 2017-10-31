type big = System.Numerics.BigInteger

let findSmallestMultiple max =

    let range = [1..max] |> List.map big
    let product = range |> List.reduce (*)

    let validDivisible n =
        range |> List.forall (fun p -> n % p = big.Zero)

    let big1 = big 1

    let rec sameOrSmaller n div =
        match n, div with
        | num, one when one = big1 -> num
        | _ ->
            let smaller = n / div
            if (validDivisible smaller) then (sameOrSmaller smaller div)
            else n

    range |> List.fold (fun p sub -> sameOrSmaller p sub) product


printfn "Test 10 (2520) : %A" (findSmallestMultiple 10)

printfn "Test 20 = %A" (findSmallestMultiple 20)
