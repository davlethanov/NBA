import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { Team } from 'src/app/team';

@Component({
  selector: 'app-view-teams',
  templateUrl: './view-teams.component.html',
  styleUrls: ['./view-teams.component.css']
})
export class ViewTeamsComponent implements OnInit {
  
  constructor(private service:SharedService) { }

  teams: Team[];
  teamsWithoutFilter: Team[];
  
  team: Team;
  ModalTitle: string;
  ActivateAddEditTeam: boolean;

  nameFilter: string = "";

  ngOnInit() {
    this.ActivateAddEditTeam=false;
    this.refreshTeams();
  }

  refreshTeams(){
    this.service.getTeams().subscribe(
      result => {
        this.teams = result;
        this.teamsWithoutFilter = result;
      },
      error => {
        alert("Error! More information in console");
        console.log(error);
      }
    );
  }

  addClick(){
    this.team={
      id : "00000000-0000-0000-0000-000000000000",
      name : "",
      city : ""
    };
    this.ModalTitle="Add team";
    this.ActivateAddEditTeam=true;
  }

  editClick(item){
    this.team = item;
    this.ModalTitle="Edit team";
    this.ActivateAddEditTeam=true;
  }

  deleteClick(item){
    if(confirm('Are you sure??')){
      this.service.deleteTeam(item.id).subscribe(
        result => {
          this.refreshTeams();
        },
        error => {
          alert("Error! More information in console");
          console.log(error);
        }
      )
    }
  }

  closeClick(){
    this.ActivateAddEditTeam=false;
    this.refreshTeams();
  }

  onCloseModal(){
    let el: HTMLElement = document.getElementById('closeModalTeamBtn') as HTMLElement;
    el.click();
    this.refreshTeams();
  }

  sortResult(prop, asc){
    this.teams = this.teams.sort(function(a,b){
      if(asc){
          return (a[prop]>b[prop])?1 : ((a[prop]<b[prop]) ?-1 :0);
      }else{
        return (b[prop]>a[prop])?1 : ((b[prop]<a[prop]) ?-1 :0);
      }
    })
  }
}