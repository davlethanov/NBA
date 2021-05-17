import { Component, OnInit } from '@angular/core';
import { Game } from 'src/app/game';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-view-games',
  templateUrl: './view-games.component.html',
  styleUrls: ['./view-games.component.css']
})
export class ViewGamesComponent implements OnInit {

  private readonly emptyGuid: string = "00000000-0000-0000-0000-000000000000";

  constructor(private service: SharedService) { }

  games: Game[];

  game: Game;
  ModalTitle: string;
  ActivateAddGame: boolean;
  ActivateEditScore: boolean;

  ngOnInit() {
    this.ActivateAddGame = false;
    this.ActivateEditScore = false;
    this.refreshGames();
  }

  refreshGames(){
    this.service.getGames().subscribe(
      result => {
        this.games = result;
      },
      error => {
        alert("Error! More information in console");
        console.log(error);
      }
    );
  }

  addClick(){
    this.game={
      id: this.emptyGuid,
      awayTeamId: this.emptyGuid,
      awayTeamName: "",
      homeTeamId: this.emptyGuid,
      homeTeamName: "",
      date: new Date(),
      awayTeamScore: null,
      homeTeamScore: null,
    };
    this.ModalTitle="Add game";
    this.ActivateAddGame=true;
  }

  editScoreClick(item){
    this.game = item;
    this.ModalTitle="Edit score";
    this.ActivateEditScore=true;
  }

  deleteClick(item){
    if(confirm('Are you sure??')){
      this.service.deleteGame(item.id).subscribe(
        result => {
          this.refreshGames();
        },
        error => {
          alert("Error! More information in console");
          console.log(error);
        }
      )
    }
  }

  closeClick(){
    this.ActivateAddGame = false;
    this.ActivateEditScore = false;
    this.refreshGames();
  }

  onCloseModal(){
    let el: HTMLElement = document.getElementById('closeModalGameBtn') as HTMLElement;
    el.click();
    this.refreshGames();
  }
}
