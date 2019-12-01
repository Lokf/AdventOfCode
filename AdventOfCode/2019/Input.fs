namespace _2019

module Input =
    let readInts filename =
        System.IO.File.ReadAllLines(filename) 
        |> Array.toList
        |> List.map int
