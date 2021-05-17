import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { TeamComponent } from './team/team.component';
import { PlayerComponent } from './player/player.component';
import { GameComponent } from './game/game.component';
import { ViewTeamsComponent } from './team/view-teams/view-teams.component';
import { AddEditTeamComponent } from './team/add-edit-team/add-edit-team.component';
import { ViewPlayersComponent } from './player/view-players/view-players.component';
import { AddEditPlayersComponent } from './player/add-edit-player/add-edit-player.component';
import { SharedService } from './shared.service';
import { ViewGamesComponent } from './game/view-games/view-games.component';
import { AddGameComponent } from './game/add-game/add-game.component';
import { EditScoreComponent } from './game/edit-score/edit-score.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    TeamComponent,
    PlayerComponent,
    GameComponent,
    ViewTeamsComponent,
    AddEditTeamComponent,
    ViewPlayersComponent,
    AddEditPlayersComponent,
    ViewGamesComponent,
    AddGameComponent,
    EditScoreComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'team', component: TeamComponent },
      { path: 'player', component: PlayerComponent },
      { path: 'game', component: GameComponent },
    ])
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
