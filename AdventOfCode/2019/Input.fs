namespace _2019

module Input =
    let readIntsFromLines filename =
        System.IO.File.ReadAllLines(filename) 
        |> Array.toList
        |> List.map int

    let readIntsFromCsv filename =
        System.IO.File.ReadAllText(filename).Split(',')
        |> Array.toList
        |> List.map int