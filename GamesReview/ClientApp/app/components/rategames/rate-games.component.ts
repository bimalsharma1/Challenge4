import { Component, Inject, OnInit, OnDestroy, Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import 'rxjs/add/operator/map';
import { Observable } from 'rxjs/Observable'
import { Subscription } from 'rxjs/Subscription';
import { of } from 'rxjs/observable/of';
import { IntervalObservable } from 'rxjs/observable/IntervalObservable'; 
import { GamesDataService } from "./../../services/games-data.service"
import { Game } from "./../../models/game.model"

@Component({
    selector: 'games',
    templateUrl: './rate-games.component.html',
    styleUrls: ['./rate-games.component.css']
})
export class RateGamesComponent implements OnInit {
    public games: Game[]
    isEditing: boolean
    newDescription: string
    baseUrl: string
    subscription: Subscription;

    constructor(private router: Router, private http: Http, @Inject('BASE_URL') baseUrl: string, private gamesDataService: GamesDataService) {
        this.baseUrl =  baseUrl
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

    addRating(itemCode: number, rating: number): void {
        let url = this.baseUrl + 'api/Games/' + itemCode.toString() + "/" + rating

        this.gamesDataService.addRating(url, itemCode, rating)
            .subscribe(result => console.log("message from api" + result),
            error => console.log("error message from api" + error));
    }
  


}