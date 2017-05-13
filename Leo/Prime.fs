module Prime

module RollingSieveGenerator =
    type SieveTable = System.Collections.Generic.Dictionary<int64, int64 list>
    let addOrUpdatePrime (lookup: SieveTable) nextLookup prime =
        if(lookup.ContainsKey(nextLookup))
            then lookup.[nextLookup] <-  prime :: lookup.[nextLookup]
            else lookup.[nextLookup] <- [prime]
    let movePrimeToNextLookup (lookup: SieveTable) number prime = 
        let nextLookup = prime + number
        addOrUpdatePrime lookup nextLookup prime      
    let isPrime (lookup:SieveTable) number =
        if(lookup.ContainsKey(number))
            then
                let primes = lookup.[number]
                primes |> Seq.iter (movePrimeToNextLookup lookup number)
                lookup.Remove(number) |> ignore
                false
            else 
                let primeSquare = number * number
                lookup.Add(primeSquare, [number])
                true
    let generatePrimes =
        let lookup = SieveTable()
        seq { 2L..System.Int64.MaxValue }
        |> Seq.filter (isPrime lookup)

let primeSeq = RollingSieveGenerator.generatePrimes

// BAD idea (slow!). Not all primes below n are likely prime factors of n
// let factors n =
//     primeSeq
//     |> Seq.takeWhile (fun p -> p <= n)
//     |> Seq.filter (fun p -> n % p = 0L)
//     |> List.ofSeq

let largestFactor num =
    let rec cut prime num =
        match num % prime = 0I with
        | true -> cut prime (num / prime)
        | false -> 
            if num <= prime then prime
            else cut (prime + 1I) num
    cut 2I num