namespace Core.ViewModels

open System
open System.Threading
open System.Collections.ObjectModel
open ViewModelSupport
open Core.Models

type MainWindowViewModel() = 
    class
        inherit ViewModelBase()
        let mutable cancellationSource = new CancellationTokenSource()
        
        member this.Artists
            with get () = base.Get<ObservableCollection<MusicArtistViewModel>>("Artists")
            and set (value : ObservableCollection<MusicArtistViewModel>) = base.Set("Artists", value)
        
        member this.CancelGetArtists() = cancellationSource.Cancel()
        member this.Execute_GetArtists() = 
            System.Diagnostics.Debug.Print "Executing GetArtists()"
            this.Artists <- new ObservableCollection<MusicArtistViewModel>()
            this.CancelGetArtists()
//            let task = 
//                async { 
            System.Diagnostics.Debug.Print "Starting with Task"

            Core.Models.Store.NPQL().``mo:MusicArtist``.Extension
            |> Seq.map (fun artist -> new MusicArtistViewModel(artist))
            |> Seq.iter this.Artists.Add

            System.Diagnostics.Debug.Print "Finished with Task"
//                }
//            Async.StartImmediate(task, cancellationSource.Token)
    end