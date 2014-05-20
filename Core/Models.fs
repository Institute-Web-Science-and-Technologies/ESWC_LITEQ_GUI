namespace Core.Models

open Uniko.Liteq

type Store = RDFStore< @"C:\Users\Martin\Documents\Visual Studio 2012\Projects\ESWC_LITEQ_GUI\liteq_default.ini" >

type MusicArtist = Store.``mo:MusicArtist``.Intension