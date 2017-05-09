module Leo

let a001 below n =
    [1..n]
    |> List.filter (fun n -> n % 3 = 0)
    |> List.filter (fun n -> n % 5 = 0)
    |> List.sum