namespace AnnotatedStack

type Monoid<'m> =
    {
        Identity : 'm
        Append : 'm -> 'm -> 'm
    }

[<AutoOpen>]
module Monoid =

    module Int =

        let addition =
            {
                Identity = 0
                Append = (+)
            }

        let multiplication =
            {
                Identity = 1
                Append = (*)
            }

    module List =

        let concat =
            {
                Identity = []
                Append = (@)
            }
