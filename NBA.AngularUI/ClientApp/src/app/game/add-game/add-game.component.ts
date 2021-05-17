import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Game } from 'src/app/game';
import { SharedService } from 'src/app/shared.service';
import { Team } from 'src/app/team';

@Component({
  selector: 'app-add-game',
  templateUrl: './add-game.component.html',
  styleUrls: ['./add-game.component.css']
})
export class AddGameComponent implements OnInit {

  constructor(private service: SharedService) { }

  @Input() game : Game;

  @Output() onCloseModal = new EventEmitter();

  closeModal(){
    this.onCloseModal.emit();
  }
  
  id: string;
  awayTeamId: string;
  awayTeamName: string;
  homeTeamId: string;
  homeTeamName: string;
  date: Date;
  awayTeamScore?: number;
  homeTeamScore?: number;

  teams: Team[]; 

  ngOnInit() {
    this.id = this.game.id;
    this.awayTeamId = this.game.awayTeamId;
    this.awayTeamName = this.game.awayTeamName;
    this.homeTeamId = this.game.homeTeamId;
    this.homeTeamName = this.game.homeTeamName;
    this.date = this.game.date;
    this.awayTeamScore = this.game.awayTeamScore;
    this.homeTeamScore = this.game.homeTeamScore;

    this.service.getTeams().subscribe(
      result => {
        this.teams=result;
      },
      error => {
        alert("Error! More information in console");
        console.log(error);
      }
    );
  }

  addGame(){
    var game = {
      id : this.id,
      awayTeamId: this.awayTeamId,
      awayTeamName: this.awayTeamName,
      homeTeamId: this.homeTeamId,
      homeTeamName: this.homeTeamName,
      date: this.date,
      awayTeamScore: this.awayTeamScore,
      homeTeamScore: this.homeTeamScore,
    };
    this.service.addGame(game).subscribe(
      result => {
        this.id = result as string;
        this.closeModal();
      },
      error => {
        alert("Error! More information in console");
        console.log(error);
      }
    );
  }

}
