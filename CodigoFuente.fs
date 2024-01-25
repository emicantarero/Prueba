open System
open System.Collections.Generic

let adivina (cadena_fija: string) intentos =
    let mutable i = 0
    let mutable adivina = ""

    while i < intentos do
        let mutable retroalimentacion = ""
        let cadenaSecretaChars = cadena_fija.ToCharArray()
        printfn "Adivina el número:"
        adivina <- Console.ReadLine()

        if adivina.Length.Equals(cadena_fija.Length) then
            let mutable cadena_fija_restante = cadena_fija
            let mutable adivina_restante = adivina
            for j = 0 to (cadena_fija.Length - 1) do
                if cadena_fija.[j] = adivina.[j] then 
                    retroalimentacion <- retroalimentacion.Insert(retroalimentacion.Length, "+")
                    cadena_fija_restante <- cadena_fija_restante.Remove(cadena_fija_restante.IndexOf(cadena_fija.[j].ToString()), 1)
                    adivina_restante <- adivina_restante.Remove(j, 1)
                    adivina_restante<-adivina_restante.Insert(0, "e")

            for j = 0 to (cadena_fija.Length - 1) do
                if cadena_fija_restante.Contains(adivina_restante.[j].ToString()) then 
                    retroalimentacion <- retroalimentacion.Insert(retroalimentacion.Length, "-")
                    cadena_fija_restante <- cadena_fija_restante.Remove(cadena_fija_restante.IndexOf(adivina_restante.[j].ToString()), 1)
                    adivina_restante <- adivina_restante.Remove(adivina_restante.IndexOf(adivina_restante.[j].ToString()), 1)
                    adivina_restante<-adivina_restante.Insert(0, "e")

            for j = 0 to (cadena_fija_restante.Length - 1) do
                    retroalimentacion <- retroalimentacion.Insert(retroalimentacion.Length, "x")

            if cadena_fija.Equals(adivina) then
                printfn "¡Felicidades! Adivinaste y has ganado."
                i <- intentos

            printfn "%s" retroalimentacion
            i <- i + 1
        else
            printfn "Ingresa un número de %d dígitos" cadena_fija.Length

    if i.Equals(intentos) && not(cadena_fija.Equals(adivina)) then
        printfn "Destruyendo Caja fuerte...."
        printfn "Perdiste, pero recuerda que:"
        printfn "Encontrarás muchas dificultades por delante... Ese es tu destino. No te desalientes, ¡ni aún en los momentos más difíciles!"
        printfn "The Legend of Zelda: Ocarina of Time"
let generarCadenaAleatoria (digitos: int) (rango: int) =
    let rnd = new Random()
    let cadena = System.Text.StringBuilder()

    for i = 0 to digitos - 1 do
        let digito = rnd.Next(0, rango + 1)
        cadena.Append(digito.ToString())

    cadena.ToString()

let menu () =
    printfn "Bienvenido al juego de adivinar números"
    printfn "Elige la dificultad:"
    printfn "1. Fácil"
    printfn "2. Intermedia"
    printfn "3. Difícil"

    let opcion = Console.ReadLine()

    match opcion with
    | "1" ->
        let cadena = generarCadenaAleatoria 4 7
        //printfn "%s" cadena
        let intentos = 10
        adivina cadena intentos
    | "2" ->
        let cadena = generarCadenaAleatoria 5 8
        let intentos = 15
        //printfn "%s" cadena
        adivina cadena intentos
    | "3" ->
        let cadena = generarCadenaAleatoria 6 9
        let intentos = 20
        //printfn "%s" cadena
        adivina cadena intentos
    | _ ->
        printfn "Opción inválida"

menu()

Console.ReadKey() |> ignore

