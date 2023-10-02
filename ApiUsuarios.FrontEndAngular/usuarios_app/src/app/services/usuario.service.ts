import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environment/environment';
import { Usuario } from '../models/usuario.model';
import { retry } from 'rxjs';
import { Observable } from 'rxjs';


@Injectable({
    providedIn: 'root'
})
export class  UsuarioService
{
    constructor(
        private httpClient: HttpClient
    ) {

    }
    // GET
    getUsuarios(): Observable<Usuario[]> {
        return this.httpClient
            .get<Usuario[]>(environment.apiUsuarios + '/listar-usuarios')
            .pipe(retry(1));
    }

    //DELETE /api/contatos/{id}
    delete(idUsuario: string): Observable<Usuario> {
        return this.httpClient.delete<Usuario>
            (environment.apiUsuarios + idUsuario);
    }
}