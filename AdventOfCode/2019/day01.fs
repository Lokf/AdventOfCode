namespace _2019

module Day01 =
    let fuelRequired mass =
        (mass / 3) - 2

    let path = System.IO.Path.Combine(__SOURCE_DIRECTORY__, "day01.txt")
    let masses = System.IO.File.ReadAllLines(path) |> Array.toList
    let puzzle1 =
        List.map int masses
        |> List.map(fun(x) -> fuelRequired x)
        |> List.sum
