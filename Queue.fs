namespace AnnotatedStack

type Queue<'m, 'a> =
    {
        Monoid : Monoid<'m>
        Front : Stack<'m, 'a>
        Back : Stack<'m, 'a>
    }

    member this.Size =
        this.Front.Size + this.Back.Size

    member this.Measure =
        this.Monoid.Append
            this.Front.Measure
            this.Back.Measure

    member this.Contents =
        this.Front.Contents @ this.Back.Contents

module Queue =

    let empty monoid annotate =
        {
            Monoid = monoid
            Front = Stack.empty monoid annotate
            Back = Stack.empty monoid annotate
        }

    let enqueue a q =
        {
            q with
                Back = Stack.push a q.Back
        }

    let rec dequeue q =
        match q.Front.Size, q.Back.Size with
            | 0, 0 -> None
            | 0, _ ->
                dequeue {
                    q with
                        Front = Stack.reverse q.Back
                        Back = q.Front
                }
            | _ ->
                Stack.pop q.Front
                    |> Option.map (fun (a, front) ->
                        a, { q with Front = front })

    let drop1 q =
        match dequeue q with
            | None -> q
            | Some (_, q') -> q'
