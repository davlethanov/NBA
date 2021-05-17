import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { Team } from 'src/app/team';

@Component({
  selector: 'app-add-edit-team',
  templateUrl: './add-edit-team.component.html',
  styleUrls: ['./add-edit-team.component.css']
})
export class AddEditTeamComponent implements OnInit {

  constructor(private service: SharedService) { }

  @Input() team : Team;

  @Output() onCloseModal = new EventEmitter();

  closeModal(){
    this.onCloseModal.emit();
  }

  id:string;
  name:string;
  city:string;

  ngOnInit() {
    this.id=this.team.id;
    this.name=this.team.name;
    this.city=this.team.city;
  }

  addTeam(){
    var team = {
      id : this.id,
      name : this.name,
      city : this.city
    };
    this.service.addTeam(team).subscribe(
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

  updateTeam(){
    var team = {
      id : this.id,
      name : this.name,
      city : this.city
    };
    this.service.updateTeam(team).subscribe(
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
