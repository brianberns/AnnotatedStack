namespace AnnotatedStack

module Program =

    let windows monoid window annotate elems =

        let start, rest = List.splitAt window elems

        let startQ =
            List.fold
                (flip Queue.enqueue)
                (Queue.empty monoid annotate)
                start
    
        let rec go (q : Queue<_, _>) elems =
            q.Measure ::
                match elems with
                    | [] -> []
                    | a :: tail ->
                        go
                            (Queue.enqueue
                                a
                                (Queue.drop1 q))
                            tail

        go startQ rest

    windows Max.monoid 3 Max [1;4;2;8;9;4;4;6]
        |> printfn "%A"   // [Max 4; Max 8; Max 9; Max 9; Max 9; Max 6]
