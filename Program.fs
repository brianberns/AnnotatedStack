namespace AnnotatedStack

module Program =

    let test1 () =
        let stack =
            Stack.empty Int.addition String.length
                |> Stack.push "hello"
                |> Stack.push "world"
        printfn $"{stack.Contents}"

    let test2 () =
        let str, q =
            Queue.empty Int.addition String.length
                |> Queue.enqueue "one"
                |> Queue.enqueue "two"
                |> Queue.enqueue "three"
                |> Queue.dequeue
                |> Option.get
        printfn $"{str}, {q.Contents}"

    test2 ()
