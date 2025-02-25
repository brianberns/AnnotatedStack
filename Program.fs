namespace AnnotatedStack

module Program =

    Queue.windows Max.monoid 3 Max [1;4;2;8;9;4;4;6]
        |> printfn "%A"   // [Max 4; Max 8; Max 9; Max 9; Max 9; Max 6]

    Queue.windows Min.monoid 3 Min [1;4;2;8;9;4;4;6]
        |> printfn "%A"   // [Min 1; Min 2; Min 2; Min 4; Min 4; Min 4]
