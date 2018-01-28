import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { GamesComponent } from './components/games/games.component';
import { RateGamesComponent } from './components/rategames/rate-games.component';


import {  GamesDataService } from "./services/games-data.service"

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        GamesComponent,
        RateGamesComponent,
        HomeComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'games', component: GamesComponent },
            { path: 'rategames', component: RateGamesComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [GamesDataService]
})
export class AppModuleShared {
}
