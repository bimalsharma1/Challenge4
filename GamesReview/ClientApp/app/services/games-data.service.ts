import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, URLSearchParams, BaseRequestOptions }
    from '@angular/http';
import { Observable } from 'rxjs/Observable';

// Observable class extensions
import 'rxjs/add/observable/of';
import 'rxjs/add/observable/throw';

// Observable operators
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/debounceTime';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/filter';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/switchMap';

import { Rating } from "./../components/games/rating.model"


export interface IGamesDataService {
    getGames(url: string): Observable<any>
    updateGameDescription(url: string, param: any): Observable<any>
    addRating(url: string, itemcode: number, rating: number): Observable<any>
}

@Injectable()
export class GamesDataService  implements IGamesDataService {
   
    headers: Headers;
    options: RequestOptions;

    constructor(private http: Http) {
 
        this.headers = new Headers({
            'Content-Type': 'application/json',
            'Accept': 'application/json',
            'Access-Control-Allow-Credentials': 'true',
            'Access-Control-Allow-Origin': '*'
        });
        this.options = new RequestOptions({ headers: this.headers });
    }

    public getGames(url: string): Observable<any> {
        return this.http.get(url)
    }


    public updateGameDescription(url: string, param: any): Observable<any> {
        let body = JSON.stringify(param);
        return this.http
            .put(url, body, this.options)
            .map(this.extractData)
            .catch(this.handleError);
    }

    public addRating(url: string, itemcode: number, rating: number): Observable<any> {
        
        let data: Rating = new Rating()
        data.Code = itemcode
        data.Rating = rating
        let body = JSON.stringify(data);
        console.log(body)
        return this.http
            .post(url, JSON.stringify(data), this.options)
            .map(this.extractData);
    }

    private extractData(res: Response) {
        let body = res.json();
        return body || {};
    }

    private handleError(error: any) {
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg);
        return Observable.throw(errMsg);
    }
}