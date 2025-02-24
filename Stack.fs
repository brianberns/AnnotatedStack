namespace AnnotatedStack

type Stack<'m, 'a> =
    {
        Monoid : Monoid<'m>
        Annotate : 'a -> 'm
        Size : int
        Contents : List<'m * 'a>
    }

    member this.Measure =
        match this.Contents with
            | [] -> this.Monoid.Identity
            | (m, _) :: _ -> m

module Stack =

    let empty monoid annotate =
        {
            Monoid = monoid
            Annotate = annotate
            Size = 0
            Contents = List.empty
        }

    let push a stack =
        {
            stack with
                Size = stack.Size + 1
                Contents =
                    let m =
                        stack.Monoid.Operation
                            (stack.Annotate a)
                            stack.Measure
                    (m, a) :: stack.Contents
        }

    let pop stack =
        match stack.Contents with
            | [] -> None
            | (_, a) :: tail ->
                let stack' =
                    {
                        stack with
                            Size = stack.Size - 1
                            Contents = tail
                    }
                Some (a, stack')

    let reverse stack =
        List.fold
            (flip push)
            (empty stack.Monoid stack.Annotate)
            (List.map snd stack.Contents)
