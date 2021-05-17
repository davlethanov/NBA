import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Inject } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  constructor(private http:HttpClient, 
    @Inject('BASE_URL') private baseUrl: string) 
  { }

  teamsApiAdding:string = "api/teams/";

  getTeams() : Observable<any[]>{
    return this.http.get<any>(this.baseUrl + this.teamsApiAdding);
  }

  addTeam(val : any){
    return this.http.post(this.baseUrl + this.teamsApiAdding, val);
  }

  updateTeam(val : any){
    return this.http.put(this.baseUrl + this.teamsApiAdding, val);
  }

  deleteTeam(val : any){
    return this.http.delete(this.baseUrl + this.teamsApiAdding + val);
  }

  playersApiAdding:string = "api/players/";

  getPlayers() : Observable<any[]>{
    return this.http.get<any>(this.baseUrl + this.playersApiAdding);
  }

  addPlayer(val : any){
    return this.http.post(this.baseUrl + this.playersApiAdding, val);
  }

  updatePlayer(val : any){
    return this.http.put(this.baseUrl + this.playersApiAdding, val);
  }

  deletePlayer(val : any){
    return this.http.delete(this.baseUrl + this.playersApiAdding + val);
  }

  gamesApiAdding:string = "api/games/";

  getGames() : Observable<any[]>{
    return this.http.get<any>(this.baseUrl + this.gamesApiAdding);
  }

  addGame(val : any){
    return this.http.post(this.baseUrl + this.gamesApiAdding, val);
  }

  setScore(id : string, val : any){
    return this.http.put(this.baseUrl + this.gamesApiAdding + id, val);
  }

  deleteGame(val : any){
    return this.http.delete(this.baseUrl + this.gamesApiAdding + val);
  }
}
