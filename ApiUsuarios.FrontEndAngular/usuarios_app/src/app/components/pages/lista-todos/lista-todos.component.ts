import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environment/environment';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Usuario } from 'src/app/models/usuario.model';
import { NgxSpinnerService } from 'ngx-spinner';


@Component({
  selector: 'app-lista-todos',
  templateUrl: './lista-todos.component.html',
  styleUrls: ['./lista-todos.component.css']
})

export class ListaTodosComponent  {

  // usuarios: Usuario[] = []; //lista de contatos exibida na consulta
  usuarios: Usuario[] = []; 
  mensagem: string = '';
  httpHeaders: HttpHeaders = new HttpHeaders();
  produtos: any[] = [];
  usuario: Usuario | null = null;
  
  page: number = 1;
  count: number = 0;
  tableSize: number = 7;
  tableSizes: any = [3, 6, 9, 12];


  constructor(
    private httpClient: HttpClient,
    private spinnerService: NgxSpinnerService,
    private router: Router
  ) {

    this.onInit();
  }

  onClickAtualizar(id: string) {
    this.router.navigate(['pages/atualizar-usuario', id]);
  }

  onInit(): void {
    this.spinnerService.show();

    this.httpClient.get(
      environment.apiUsuarios + '/' + 'listar-usuarios',
      { headers: this.httpHeaders } //enviando o token..
    )
      .subscribe({
        next: (data) => {
          this.usuarios = data as any[];
        },
        error: (e) => {
          console.log(e.error);
        }
      })
      .add(() => {
        this.spinnerService.hide();
      })
    
  }
  
  onDelete(IdUsuario: string): void {

    if (window.confirm('Deseja excluir o usuário?')) {
      this.spinnerService.show();

      this.httpClient.delete(
        environment.apiUsuarios + '/' + IdUsuario
      )
        .subscribe({
          next: (data: any) => {
            this.mensagem = data.mensagem;
            this.onInit();
          },
          error: (e) => {
            this.mensagem = e.error.mensagem;
          }
        })
        .add(
          () => {
            this.spinnerService.hide();
          }
        )
    }
  }

  onTableDataChange(event: any) {
    this.page = event;
    this.onInit();
  }

  onTableSizeChange(event: any): void {
    this.tableSize = event.target.value;
    this.page = 1;
    this.onInit();
  }

}
