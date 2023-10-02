import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environment/environment';
import { UsuarioService } from './usuario.service';
import { Usuario } from '../models/usuario.model';
import { Component, OnInit } from '@angular/core';

@Injectable({
  providedIn: 'root',
})

export class PostService {
    constructor(private http: HttpClient) {}
    getAllPosts(): Observable<any> {
      return this.http.get(environment+ '/' + 'listar-usuarios');
    }
    
  }


