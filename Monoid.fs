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

    let inline monoid<'a when 'a : (static member Zero: 'a) and 'a : comparison> =
        {
            Identity = Max LanguagePrimitives.GenericZero<'a>
            Append = append
        }
