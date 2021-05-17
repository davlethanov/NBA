import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Player } from 'src/app/player';
import { SharedService } from 'src/app/shared.service';
import { Team } from 'src/app/team';

@Component({
  selector: 'app-add-edit-player',
  templateUrl: './add-edit-player.component.html',
  styleUrls: ['./add-edit-player.component.css']
})
export class AddEditPlayersComponent implements OnInit {

  constructor(private service:SharedService) { 
    service.getTeams().subscribe(
      result => {
        this.teams = result;
      },
      error => {
        alert("Error! More information in console");
        console.log(error);
      }
    );
  }

  @Input() player : Player;

  @Output() onCloseModal = new EventEmitter();

  closeModal(){
    this.onCloseModal.emit();
  }

  id: string;
  firstName: string;
  secondName: string;
  birthDate: Date;
  teamId: string;
  teamName: string;
  teamNumber? : number;

  teams: Team[]; 

  ngOnInit() {
    this.id = this.player.id;
    this.firstName = this.player.firstName;
    this.secondName = this.player.secondName;
    this.birthDate = this.player.birthDate;
    this.teamId = this.player.teamId;
    this.teamName = this.player.teamName;
    this.teamNumber = this.player.teamNumber;
    
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

  addPlayer(){
    var player = {
      id : this.id,
      firstName : this.firstName,
      secondName : this.secondName,
      birthDate : this.birthDate,
      teamId : this.teamId,
      teamName : this.teamName,
      teamNumber : this.teamNumber,
    };
    this.service.addPlayer(player).subscribe(
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

  updatePlayer(){
    var player = {
      id : this.id,
      firstName : this.firstName,
      secondName : this.secondName,
      birthDate : this.birthDate,
      teamId : this.teamId,
      teamName : this.teamName,
      teamNumber : this.teamNumber,
    };
    this.service.updatePlayer(player).subscribe(
      result => {
        this.closeModal();
      },
      error => {
        alert("Error! More information in console");
        console.log(error);
      }
    );
  }
}
