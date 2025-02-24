namespace AnnotatedStack

module Program =

    let stack =
        Stack.empty Int.addition String.length
            |> Stack.push "hello"
            |> Stack.push "world"
    printfn $"{stack.Contents}"
