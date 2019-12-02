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
    let program = Input. readIntsFromCsv path

    let puzzle1 = 


