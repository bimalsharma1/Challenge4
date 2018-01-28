import { Component, Inject, OnInit, OnDestroy, Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable'
import { Subscription } from 'rxjs/Subscription';
import { of } from 'rxjs/observable/of';
import { IntervalObservable } from 'rxjs/observable/IntervalObservable'; 
import { IGamesDataService } from "./../../services/games-data.service"
import { Game } from "./game.model"

@Component({
    selector: 'games',
    templateUrl: './games.component.html',
    styleUrls: ['./games.component.css']
})
export class GamesComponent implements OnInit {
    public games: Game[]
    isEditing: boolean
    newDescription: string
    baseUrl: string
    user: {};
    subscription: Subscription;
    public alive: boolean
    //http://localhost:54621/api/Games
    //http://gamesreviewapi20180128095219.azurewebsites.net

    constructor(private router: Router, private http: Http, @Inject('BASE_URL') baseUrl: string, private gamesDataService: IGamesDataService) {
        this.baseUrl =  baseUrl
        this.alive = true;
        this.isEditing = false
    }

    ngOnInit() {
        let url = this.baseUrl + 'api/Games'
        this.gamesDataService.getGames(url).subscribe((data) => {
            this.games = data.json();
        })
            
    }
 
    ngOnDestroy() {
        
        //this.subscription.unsubscribe()
    }

    saveDescription(itemCode: string, description: string): void {
        this.isEditing = !this.isEditing
        let url = this.baseUrl + 'api/Games/' + itemCode + "/" + description
        this.gamesDataService.updateGameDescription(url, description)
            .subscribe(result => console.log(result),
                error => console.log(" error message from api" + error.toString())
            );
            
    }

    addRating(itemCode: number, rating: number): void {
        let url = this.baseUrl + 'api/Games/' + itemCode.toString() + "/" + rating

        this.gamesDataService.addRating(url, itemCode, rating)
            .subscribe(result => console.log("message from api" + result),
            error => console.log("error message from api" + error));
    }
  
    toggleEditMode(event:any): void {
        this.isEditing = !this.isEditing
        console.log(this.isEditing)
    }


}