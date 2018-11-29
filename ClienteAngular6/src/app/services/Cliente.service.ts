import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import * as _ from 'lodash';
import { Observable } from 'rxjs';
import { Registro } from '../modelos/Registro';


@Injectable()
export class ClienteService {
    baseURL: string;
    options: { headers: any; };
    EndPoint: any = "http://localhost:54397/api/Cliente/ValidarClientes";

    constructor(private http: HttpClient) {
    }

    ValidarClientes(entidad): Observable<Array<Registro>> {
        this.asignarOpcionesHeaders();
        return this.http.post<Array<Registro>>(this.EndPoint,entidad, this.options)
        
    }

    asignarOpcionesHeaders() {
        this.options = {
            headers: new HttpHeaders({
            })
        };
    }
}
