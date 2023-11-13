import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, catchError, of } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class CdbService {
  private url = 'https://localhost:7208/cdb/calcular';



  constructor(private httpClient: HttpClient) { }

  getPosts(request: CalculoCDBRequest): Observable<CalculoCDBResponse> {
    return this.httpClient.post<CalculoCDBResponse>(this.url, request, httpOptions)
    .pipe(catchError((error: any, caught: Observable<any>): Observable<any> => {
      console.error('There was an error!', error);
      return of();
  }))
  }

  private handleError(err: any) {

  }

}

export interface CalculoCDBRequest {
  ValorInicial: number | null;
  Meses: number | null;
}

export interface CalculoCDBResponse {
  tb: number;
  cdi: number;
  valorFinal: number;
  impostoAliquota: number;
  impostoValor: number;
  meses: any;
}
