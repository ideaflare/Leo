module LeoSeq

let fib =
    let rec f a b = seq {
        yield a
        yield! f b (a + b)
    }
    f 0 1