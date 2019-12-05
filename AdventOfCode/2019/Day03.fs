﻿namespace _2019

module Day03 =
    type Direction =
        | Up
        | Down
        | Right
        | Left

    type Node = (int * int)

    type Leg = (Direction * int)

    let rec walkLine direction distance x y (nodes: Set<Node>) =
        match (direction, distance) with
        | _, 0 -> (nodes, x, y)
        | Up, _ -> walkLine direction (distance - 1) x (y + 1) (nodes.Add(x, y))
        | Down, _ -> walkLine direction (distance - 1) x (y - 1) (nodes.Add(x, y))
        | Right, _ -> walkLine direction (distance - 1) (x + 1) y (nodes.Add(x, y))
        | Left, _ -> walkLine direction (distance - 1) (x - 1) y (nodes.Add(x, y))

    let rec walkPath legs x y (nodes: Set<Node>) =
        match legs with 
        | [] -> nodes
        | (direction, distance)::tail ->
            let (lineNodes, x, y) =  walkLine direction distance x y Set.empty
            nodes + lineNodes + walkPath tail x y Set.empty

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
    let circuits = 
        System.IO.File.ReadAllLines(path)
            

