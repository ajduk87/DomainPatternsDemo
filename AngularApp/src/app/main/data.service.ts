import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs/internal/Observable';

@Injectable()
export class DataService {
    constructor(private httpClient: HttpClient) {}
    get(endpoint: string): Observable<any> {
        return this.httpClient.get(environment.baseUrl + endpoint);
    }
}
