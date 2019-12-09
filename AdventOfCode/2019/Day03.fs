namespace _2019

module Day03 =
    type Direction =
        | Up
        | Down
        | Right
        | Left

    type Position = (int * int)

    type Leg = (Direction * int)

    //let merge (a : Map<Position, int>) (b : Map<Position, int>) =
    //    Map.fold (fun s k v ->
    //        match Map.tryFind k s with
    //        | Some v' -> Map.add k (min v, v') s
    //        | _ -> s) a b
    
    let merge (a : Map<'a, 'b>) (b : Map<'a, 'b>) (f : 'a -> 'b * 'b -> 'b) =
        Map.fold (fun s k v ->
            match Map.tryFind k s with
            | Some v' -> Map.add k (f k (v, v')) s
            | None -> Map.add k v s) a b
    
    let mergePosition (a : Map<Position, int>) (b : Map<Position, int>) =
        merge a b (fun _ (v, v') -> min v  v')

    let manhattanDistance (x, y) =
        abs x + abs y

    let rec walkLine direction distance x y (positions: Map<Position, int>) =
        match (direction, distance) with
        | _, 0 -> (positions, x, y)
        | Up, _ -> walkLine direction (distance - 1) x (y + 1) (positions.Add((x, y), (manhattanDistance (x, y))))
        | Down, _ -> walkLine direction (distance - 1) x (y - 1) (positions.Add((x, y), (manhattanDistance (x, y))))
        | Right, _ -> walkLine direction (distance - 1) (x + 1) y (positions.Add((x, y), (manhattanDistance (x, y))))
        | Left, _ -> walkLine direction (distance - 1) (x - 1) y (positions.Add((x, y), (manhattanDistance (x, y))))

    let rec walkPath legs x y (positions: Map<Position, int>) =
        match legs with 
        | [] -> positions
        | (direction, distance)::tail ->
            let (linePositions, x, y) =  walkLine direction distance x y Map.empty
            let a = mergePosition linePositions positions
            mergePosition a (walkPath tail x y Map.empty)

    let parseDirection char =
        match char with
        | 'U' -> Up
        | 'D' -> Down
        | 'R' -> Right
        | 'L' -> Left
        | _ -> raise (System.Exception())

    let parseLeg (leg: string) =
        Leg(parseDirection (leg.[0]), leg.[1..] |> int)

    let rec parseLegs legs =
        match legs with
        | [] -> []
        | head::tail -> parseLeg head::parseLegs tail
    let path = System.IO.Path.Combine(__SOURCE_DIRECTORY__, "day03.txt")

    let input = System.IO.File.ReadAllLines(path)

    //let input = [ "R8,U5,L5,D3";  "U7,R6,D4,L4" ]
    let wire1 = parseLegs (input.[0].Split(',') |> List.ofArray)
    let wire2 = parseLegs (input.[1].Split(',') |> List.ofArray)

    let positions1 = walkPath wire1 0 0 Set.empty
    let positions2 = walkPath wire2 0 0 Set.empty

    //let manhattanDistance (x, y) =
    //    abs x + abs y



    let intersect = Set.intersect positions1 positions2
    let puzzle1 = intersect |> List.ofSeq |> List.map manhattanDistance |> List.sort |> List.item 1

            

