namespace AnnotatedStack

type Monoid<'m> =
    {
        Identity : 'm
        Append : 'm -> 'm -> 'm
    }

type Max<'a> =
    | NegInf
    | Max of 'a

module Max =

    let append ma mb =
        match ma, mb with
            | NegInf, a
            | a, NegInf -> a
            | Max a, Max b -> Max (max a b)

    let monoid : Monoid<Max<'a>> =
        {
            Identity = NegInf
            Append = append
        }

type Min<'a> =
    | PosInf
    | Min of 'a

module Min =

    let append ma mb =
        match ma, mb with
            | PosInf, a
            | a, PosInf -> a
            | Min a, Min b -> Min (min a b)

    let monoid : Monoid<Min<'a>> =
        {
            Identity = PosInf
            Append = append
        }
