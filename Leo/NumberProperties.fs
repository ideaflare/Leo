module NumberProperties

let isPalindrone n =
    let s = List.ofSeq (sprintf "%i" n)
    s = List.rev s
    
let rec digitCount n =
    match n / 10 with
    | 0 -> 1
    | x -> 1 + digitCount x

let digitCountByString n = (string n) |> Seq.length