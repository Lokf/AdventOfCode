namespace _2019

module Day02 =
    let add (program: int[]) position =
         Array.set program program.[position + 2] (program.[program.[position]] + program.[program.[position + 1]])
    
    let mul (program: int[]) position =
        Array.set program program.[position + 2] (program.[program.[position]] * program.[program.[position + 1]])
    
    let rec exec (program: int[]) index =
        if program.[index] = 1 
        then add program (index + 1)
             exec program (index + 4)
        else if program.[index] = 2
        then mul program (index + 1)
             exec program (index + 4)
        else
            program.[0]

    let path = System.IO.Path.Combine(__SOURCE_DIRECTORY__, "day02.txt")
    let input = Input.readIntsFromCsv path
                  |> List.toArray

    let puzzle1 = 
        let program = Array.copy input
        Array.set program 1 12
        Array.set program 2 2
        exec program 0

    let rec loop input noun verb =
        let program = Array.copy input
        Array.set program 1 noun
        Array.set program 2 verb
        let res = exec program 0
        if res = 19690720
        then 100 * noun + verb
        else if verb = 99
        then loop input (noun + 1) 0
        else loop input noun (verb + 1)

    let puzzle2 =
        loop input 0 0

