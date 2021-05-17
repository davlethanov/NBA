import { Component, OnInit } from '@angular/core';
import { Player } from 'src/app/player';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-view-players',
  templateUrl: './view-players.component.html',
  styleUrls: ['./view-players.component.css']
})
export class ViewPlayersComponent implements OnInit {

  constructor(private service:SharedService) { }

  players: Player[];

  player: Player;
  ModalTitle: string;
  ActivateAddEditPlayer: boolean;

  ngOnInit() {
    this.ActivateAddEditPlayer = false;
    this.refreshPlayers();
  }

  refreshPlayers(){
    this.service.getPlayers().subscribe(
      result => {
        this.players = result;
      },
      error => {
        alert("Error! More information in console");
        console.log(error);
      }
    );
  }

  addClick(){
    this.player={
      id : "00000000-0000-0000-0000-000000000000",
      firstName : "",
      secondName : "",
      birthDate: new Date(),
      teamId: null,
      teamName: null,
      teamNumber: null
    };
    this.ModalTitle="Add player";
    this.ActivateAddEditPlayer=true;
  }

  editClick(item){
    this.player = item;
    this.ModalTitle="Edit player";
    this.ActivateAddEditPlayer=true;
  }

  deleteClick(item){
    if(confirm('Are you sure??')){
      this.service.deletePlayer(item.id).subscribe(
        result => {
          this.refreshPlayers();
        },
        error => {
          alert("Error! More information in console");
          console.log(error);
        }
      )
    }
  }

  closeClick(){
    this.ActivateAddEditPlayer=false;
    this.refreshPlayers();
  }

  onCloseModal(){
    let el: HTMLElement = document.getElementById('closeModalPlayerBtn') as HTMLElement;
    el.click();
    this.refreshPlayers();
  }
}
