namespace Core.ViewModels

open System
open Core.Models

type MusicArtistViewModel(artist : MusicArtist) = 
    class
        member this.Name = artist.``foaf:name`` |> String.concat (" ")
        member this.NumberOfRecords = artist.``foaf:made`` |> Seq.length
    end
