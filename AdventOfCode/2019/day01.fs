namespace _2019

module Day01 =
    let fuelRequired mass =
        (mass / 3) - 2

    let rec fuelRequiredRec mass =
        let fuel = fuelRequired mass
        if (fuel > 0)
        then fuel + (fuelRequiredRec fuel)
        else 0
        

    let path = System.IO.Path.Combine(__SOURCE_DIRECTORY__, "day01.txt")
    let masses = Input.readIntsFromLines path
    let puzzle1 =
        masses
        |> List.map(fun(x) -> fuelRequired x)
        |> List.sum

    let puzzle2 =
        masses
        |> List.map(fun(x) -> fuelRequiredRec x)
        |> List.sum