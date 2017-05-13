module Leo

let a001 below =
    [1.. (below - 1)]
    |> List.filter (fun n -> n % 3 = 0 || n % 5 = 0)
    |> List.sum