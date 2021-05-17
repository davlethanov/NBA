import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Game } from 'src/app/game';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-edit-score',
  templateUrl: './edit-score.component.html',
  styleUrls: ['./edit-score.component.css']
})
export class EditScoreComponent implements OnInit {

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

  ngOnInit() {
    this.id = this.game.id;
    this.awayTeamId = this.game.awayTeamId;
    this.awayTeamName = this.game.awayTeamName;
    this.homeTeamId = this.game.homeTeamId;
    this.homeTeamName = this.game.homeTeamName;
    this.date = this.game.date;
    this.awayTeamScore = this.game.awayTeamScore;
    this.homeTeamScore = this.game.homeTeamScore;
  }

  editScore(){
    var score = {
      awayTeamScore: this.awayTeamScore,
      homeTeamScore: this.homeTeamScore,
    };
    this.service.setScore(this.id, score).subscribe(
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
